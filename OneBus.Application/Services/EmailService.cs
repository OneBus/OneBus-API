using System.Net;
using System.Text;
using System.Net.Mime;
using System.Net.Mail;
using FluentValidation;
using OneBus.Domain.Models;
using OneBus.Domain.Settings;
using Microsoft.Extensions.Options;
using OneBus.Domain.Commons.Result;
using Microsoft.Extensions.Logging;
using OneBus.Application.Extensions;
using OneBus.Application.Interfaces.Services;

namespace OneBus.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IValidator<EmailModel> _validator;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> options, IValidator<EmailModel> validator, ILogger<EmailService> logger)
        {
            _emailSettings = options.Value;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<bool>> SendAsync(EmailModel emailModel, CancellationToken cancellationToken = default)
        {
            var validation = await _validator.ValidateAsync(emailModel, cancellationToken);

            if (!validation.IsValid)
                return validation.Errors.ToInvalidResult<bool>();

            AlternateView? htmlView = null;

            emailModel.Body = await ConfigureBodyAsync(emailModel, cancellationToken);

            if (emailModel.IsCid)
                htmlView = ConfigureCid(emailModel.Body);

            SmtpClient client = ConfigureClient();
            MailMessage message = ConfigureMessage(emailModel, htmlView);

            // Fire and Forget
            _ = Task.Run(() =>
            {
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao enviar e-mail para {Destinatarios}", string.Join(',', emailModel.To));
                }
            }, cancellationToken);

            return SuccessResult<bool>.Create(true);
        }

        private static async Task<string> ConfigureBodyAsync(EmailModel emailModel, CancellationToken cancellationToken)
        {
            string body = await File.ReadAllTextAsync(emailModel.BodyPath, cancellationToken);

            foreach (var item in emailModel.Variables)
                body = body.Replace(item.Key, item.Value);

            return body;
        }

        private SmtpClient ConfigureClient()
        {
            // Applying Stmp Client settings
            var client = new SmtpClient
            {
                UseDefaultCredentials = false,
                Host = _emailSettings.MailHost,
                Port = Convert.ToInt32(_emailSettings.MailPort),
                EnableSsl = _emailSettings.MailEnableSsl.ToLower().Equals("true"),
                Timeout = 90000, //1,5min 

                //Applying credentials
                Credentials = new NetworkCredential(_emailSettings.MailUser, _emailSettings.MailPassword)
            };

            return client;
        }

        private static MailMessage ConfigureMessage(EmailModel emailModel, AlternateView? htmlView)
        {
            // Applying message settings
            MailMessage message = new()
            {
                From = new MailAddress(emailModel.From, emailModel.FromName, Encoding.UTF8),
                IsBodyHtml = true,
                Body = emailModel.Body,
                Priority = MailPriority.Normal,
                Subject = emailModel.Subject,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8
            };

            // Adicionar o recurso ao corpo
            if (htmlView is not null)
                message.AlternateViews.Add(htmlView);

            // Adding email destination
            foreach (var destination in emailModel.To)
                message.To.Add(destination);

            // Adding attachment from local file path
            if (!string.IsNullOrEmpty(emailModel.FilePath))
                message.Attachments.Add(new Attachment(emailModel.FilePath, emailModel.FileName));

            // Adding attachment from memory stream
            if (emailModel.FileStream is { Length: > 0 })
                message.Attachments.Add(new Attachment(emailModel.FileStream, emailModel.FileName));

            return message;
        }

        private static AlternateView ConfigureCid(string body)
        {
            // Criar o corpo alternativo em HTML
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

            // Carregar a imagem como recurso vinculado
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Images", "OneBusLogoEmail.png");
            LinkedResource image = new(imagePath, MediaTypeNames.Image.Png)
            {
                ContentId = "OneBusEmail",
                TransferEncoding = TransferEncoding.Base64
            };

            // Adicionar o recurso ao corpo
            htmlView.LinkedResources.Add(image);
            return htmlView;
        }
    }
}

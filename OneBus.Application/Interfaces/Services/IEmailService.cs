using OneBus.Domain.Commons.Result;
using OneBus.Domain.Models;

namespace OneBus.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<Result<bool>> SendAsync(EmailModel emailModel, CancellationToken cancellationToken = default);
    }
}

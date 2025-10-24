using FluentValidation;
using Mapster;
using OneBus.Application.DTOs.Login;
using OneBus.Application.DTOs.User;
using OneBus.Application.Extensions;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Models;

namespace OneBus.Application.Services
{
    public class UserService : BaseService<User, CreateUserDTO, ReadUserDTO, UpdateUserDTO, BaseFilter>,
        IUserService
    {
        private readonly ITokenService _tokenService;

        public UserService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IValidator<CreateUserDTO> createValidator,
            IValidator<UpdateUserDTO> updateValidator)
            : base(userRepository, createValidator, updateValidator)
        {
            _tokenService = tokenService;
        }

        public async Task<Result<TokenModel>> LoginAsync(
            LoginDTO loginDTO, CancellationToken cancellationToken = default)
        {
            if (loginDTO is null)
                return ErrorResult<TokenModel>.Create(ErrorUtils.InvalidParameter("Login"));

            var user = await _baseReadOnlyRepository.GetOneAsync(c => c.Email.ToLower() == loginDTO.Email.ToLower(),
                cancellationToken: cancellationToken);

            if (user is null)
                return NotFoundResult<TokenModel>.Create(ErrorUtils.EntityNotFound(nameof(loginDTO.Email)));

            if (!user.Password.Verify(loginDTO.Password, user.Salt))
                return InvalidResult<TokenModel>.Create(ErrorUtils.InvalidParameter("Senha"));

            var readUserDTO = user.Adapt<ReadUserDTO>();

            var tokenModel = _tokenService.Generate(readUserDTO);
            return SuccessResult<TokenModel>.Create(tokenModel);
        }

        protected override void UpdateFields(User entity, UpdateUserDTO updateDTO) { }
    }
}

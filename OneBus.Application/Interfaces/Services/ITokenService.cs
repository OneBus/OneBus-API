using OneBus.Application.DTOs.User;
using OneBus.Domain.Models;

namespace OneBus.Application.Interfaces.Services
{
    public interface ITokenService
    {
        TokenModel Generate(ReadUserDTO user);
    }
}

namespace OneBus.Application.Interfaces.Services
{
    public interface IUserTypeFeatureService
    {
        Task<bool> HasPermissionAsync(ulong userId, string featureCode, CancellationToken cancellationToken = default);
    }
}

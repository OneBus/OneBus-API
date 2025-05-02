using Microsoft.AspNetCore.Authorization;

namespace OneBus.API.Authorizations
{
    public class FeatureRequirement : IAuthorizationRequirement
    {
        public FeatureRequirement(byte featureCode)
        {
            FeatureCode = featureCode;
        }
        
        public byte FeatureCode { get; }
    }
}

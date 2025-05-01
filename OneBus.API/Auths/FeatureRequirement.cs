using Microsoft.AspNetCore.Authorization;

namespace OneBus.API.Auths
{
    public class FeatureRequirement : IAuthorizationRequirement
    {
        public FeatureRequirement(string featureCode)
        {
            FeatureCode = featureCode;
        }
        
        public string FeatureCode { get; }
    }
}

using Microsoft.AspNetCore.Authorization;

namespace OneBus.API.Authorizations
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

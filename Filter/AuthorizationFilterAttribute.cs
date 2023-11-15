using Microsoft.AspNetCore.Mvc.Filters;

namespace VSMDivineUser.Api.Filter
{
    public class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        #region ===[ Private Members ]=============================================================

        private readonly string _apiKey;
        private readonly string _apiKeySecondary;
        private readonly bool _canUseSecondaryApiKey;

        #endregion

        #region ===[ Constructor ]=================================================================

        public AuthorizationFilterAttribute(IConfiguration configuration)
        {
            _apiKey = configuration["SecretKeys:ApiKey"] ?? "04577BA6-3E32-456C-B528-E41E20D28D79";
            _apiKeySecondary = configuration["SecretKeys:ApiKeySecondary"] ?? "6D5D1ABA-4F78-4DD3-A69D-C2D15F2E259A,709C95E7-F59D-4CC4-9638-4CDE30B2FCFD";
            _canUseSecondaryApiKey = configuration["SecretKeys:UseSecondaryKey"] == "True";
        }

        #endregion

        #region ===[ Public Methods ]==============================================================

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKeyHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            var authController = new Controllers.AuthController();

            if (apiKeyHeader.Any())
            {
                var keys = new List<string>
                {
                    _apiKey
                };

                if (_canUseSecondaryApiKey)
                {
                    keys.AddRange(_apiKeySecondary.Split(','));
                }

                if (keys.FindIndex(x => x.Equals(apiKeyHeader, StringComparison.OrdinalIgnoreCase)) == -1)
                {
                    context.Result = authController.NotAuthorized();
                }
            }
            else
            {
                context.Result = authController.NotAuthorized();
            }
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Practice_MVC.Filters
{
    public class BookingNotAllowedFilter : Attribute, IAuthorizationFilter
    {
        private IConfiguration _configuration;

        public BookingNotAllowedFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var appSwitch = _configuration.GetSection("Information")
                .GetChildren().FirstOrDefault(x => x.Key == "BookingNotAllowed")?.Value;
            bool.TryParse(appSwitch, out var value);
            if (value)
            {
                context.Result = new ViewResult
                {
                    ViewName = "BookingNotAllowed"
                };
            }
        }
    }
}

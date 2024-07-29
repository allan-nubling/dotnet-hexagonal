using Microsoft.AspNetCore.Mvc;

namespace Application.API.Configurations.Attributes
{
    public class ApiV1RouteAttribute : RouteAttribute
    {
        public ApiV1RouteAttribute(string template) : base($"api/v1/{template}".ToLower())
        {
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace Application.API.v1.Controllers
{
    public class ApiV1RouteAttribute : RouteAttribute
    {
        public ApiV1RouteAttribute(string template) : base($"api/v1/{template}".ToLower())
        {
        }
    }
}
using System.Net.Mime;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.v1.Controllers
{
    [ApiController]
    [ApiV1Route("[controller]")]
    public class ExampleController : ControllerBase

    {
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SampleExceptionValue))]
        public ActionResult<ExampleResponse> Get([FromQuery] ExampleQueryRequest query)
        {

            throw new Exception("A generic error message!");
            throw new SampleException("A sample message", "E001");
            ExampleResponse response = new();
            return response;
        }


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ExampleResponse> Post(ExampleRequest dto)
        {

            Console.WriteLine("Post::TEST");
            ExampleResponse response = new();
            return response;
        }
    }
}
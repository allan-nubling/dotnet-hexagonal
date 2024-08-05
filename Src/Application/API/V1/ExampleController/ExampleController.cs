using System.Globalization;
using System.Net.Mime;
using Application.API.Configurations.Attributes;
using Domain.Exceptions;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.v1.Controllers
{
    [ApiController]
    [ApiV1Route("[controller]")]
    public class ExampleController(ExampleUseCase _exampleUseCase) : ControllerBase
    {
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseException))]
        public async Task<ActionResult<ExampleResponse>> Get([FromQuery] ExampleQueryRequest query)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            var result = await _exampleUseCase.Execute(new ExampleUseCaseInput() { Foo = query.Name, ShouldThrowAnError = query.ThrowError });
            ExampleResponse response = new() { TestString = result.Bar };
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
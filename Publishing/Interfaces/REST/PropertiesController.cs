using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MyApp.Namespace
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Available Properties for Rooms Endpoints")]
    public class PropertiesController : ControllerBase
    {
        [HttpGet()]
        [SwaggerOperation(
            Summary = "Test Hello World Endpoint",
            Description = "A simple test endpoint that returns 'Hello, World!'",
            OperationId = "TestHelloWorld")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a Hello World message")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Internal server error")]
        public async Task<IActionResult> TestHelloWorld()
        {

            return Ok(new { message = "Hello, World!"   });
        }
    }
}

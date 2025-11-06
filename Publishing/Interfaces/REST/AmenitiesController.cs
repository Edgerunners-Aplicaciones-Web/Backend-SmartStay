using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace MyApp.Namespace
{
[ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Available Amenities for Properties Room Endpoints")]

    public class AmenitiesController(
        IAmenitiesQueryService amenitiesQueryService,
        IAmenityCommandService amenityCommandService) : ControllerBase
    {
        [HttpGet()]
        [SwaggerOperation(
            Summary = "Get all amenities",
            Description = "Retrieves a list of all available amenities for properties.",
            OperationId = "GetAllAmenities")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of amenities")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No amenities found")]
        public async Task<IActionResult> GetAllAmenities()
        {
            var amenities = await amenitiesQueryService.Handle(new GetAllAmenitiesQuery());
            var amenityResources = amenities.Select(AmenityResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(amenityResources);
        }

        [HttpGet("{amenityId:int}")]
        [SwaggerOperation(
            Summary = "Get an amenity by ID",
            Description = "Retrieves a specific amenity by its unique identifier.",
            OperationId = "GetAmenityById")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the requested amenity")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Amenity not found")]
        public async Task<IActionResult> GetAmenityById(int amenityId)
        {
            var getAmenityByIdQuery = new GetAmenityByIdQuery(amenityId);
            var amenity = await amenitiesQueryService.Handle(getAmenityByIdQuery);
            if (amenity is null) return NotFound();
            var resource = AmenityResourceFromEntityAssembler.ToResourceFromEntity(amenity);
            return Ok(resource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new amenity",
            Description = "Create a new amenity",
            OperationId = "CreateAmenity")]
        [SwaggerResponse(StatusCodes.Status201Created, "The amenity was created", typeof(AmenityResource))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The amenity could not be created")]
        public async Task<IActionResult> CreateAmenity([FromBody] CreateAmenityResource resource)
        {
            var createAmenityCommand = CreateAmenityCommandFromResourceAssembler.ToCommandFromResource(resource);
            var amenity = await amenityCommandService.Handle(createAmenityCommand);
            if (amenity is null) return BadRequest();
            var amenityResource = AmenityResourceFromEntityAssembler.ToResourceFromEntity(amenity);
            return CreatedAtAction(nameof(GetAmenityById), new { amenityId = amenity.Id }, amenityResource);
        }
    }
}

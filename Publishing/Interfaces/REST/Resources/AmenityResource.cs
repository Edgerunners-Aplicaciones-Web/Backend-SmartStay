namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

/// <summary>
///     Amenity resource for REST API
/// </summary>
/// <param name="Id">
///     The unique identifier of the amenity
/// </param>
/// <param name="Name">
///     The name of the amenity
/// </param>
public record AmenityResource(int Id, string Name);
namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

/// <summary>
///     Create amenity resource for REST API
/// </summary>
/// <param name="Name">
///     The name of the amenity
/// </param>
public record CreateAmenityResource(string Name);
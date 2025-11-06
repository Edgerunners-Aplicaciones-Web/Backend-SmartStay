namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

/// <summary>
///     Command to create an amenity.
/// </summary>
/// <param name="Name">
///     The name of the amenity to create.
/// </param>
public record CreateAmenityCommand(string Name);
namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;

/// <summary>
///     Represents a query to get an amenity by id in the ACME Learning Center Platform.
/// </summary>
/// <param name="AmenityId">
///     The id of the amenity to get
/// </param>
public record GetAmenityByIdQuery(int AmenityId);
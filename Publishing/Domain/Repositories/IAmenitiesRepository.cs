using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;

/// <summary>
///     Represents the amenities repository in the ACME Learning Center Platform.
/// </summary>
public interface IAmenitiesRepository : IBaseRepository<Amenity>
{
}
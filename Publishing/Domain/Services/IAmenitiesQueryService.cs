using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Services;

public interface IAmenitiesQueryService
{
    Task<IEnumerable<Amenity>> Handle(GetAllAmenitiesQuery query);
    Task<Amenity?> Handle(GetAmenityByIdQuery query);

}

using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.QueryServices;

public class AmenitiesQueryService(IAmenitiesRepository amenitiesRepository)
    : IAmenitiesQueryService
{

    /// <inheritdoc />
    public async Task<IEnumerable<Amenity>> Handle(GetAllAmenitiesQuery query)
    {
        return await amenitiesRepository.ListAsync();
    }

    public async Task<Amenity?> Handle(GetAmenityByIdQuery query)
    {
        return await amenitiesRepository.FindByIdAsync(query.AmenityId);
    }


}
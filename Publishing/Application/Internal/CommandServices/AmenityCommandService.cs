using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using Cortex.Mediator;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;


public class AmenityCommandService(IAmenitiesRepository amenityRepository, IUnitOfWork unitOfWork)
    : IAmenityCommandService
{

    public async Task<Amenity?> Handle(CreateAmenityCommand command)
    {
        var amenity = new Amenity(command);
        await amenityRepository.AddAsync(amenity);
        await unitOfWork.CompleteAsync();

        // Return the created amenity
        return amenity;
    }
}
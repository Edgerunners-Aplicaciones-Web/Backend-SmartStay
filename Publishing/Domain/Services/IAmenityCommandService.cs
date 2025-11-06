using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Services;


public interface IAmenityCommandService
{

    public Task<Amenity?> Handle(CreateAmenityCommand command);
}
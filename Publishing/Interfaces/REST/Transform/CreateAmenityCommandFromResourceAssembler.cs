using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

public static class CreateAmenityCommandFromResourceAssembler
{
    public static CreateAmenityCommand ToCommandFromResource(CreateAmenityResource resource)
    {
        return new CreateAmenityCommand(resource.Name);
    }
}
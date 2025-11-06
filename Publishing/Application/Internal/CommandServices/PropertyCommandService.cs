using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;

public class PropertyCommandService(IPropertyRepository propertyRepository, IUnitOfWork unitOfWork)
    : IPropertyCommandService
{
    public async Task<Property?> Handle(CreatePropertyCommand command)
    {
        var property = new Property
        {
            Name = command.Name,
            Location = command.Location,
            Description = command.Description,
            BasePrice = command.BasePrice,
            Type = command.Type
        };

        await propertyRepository.AddAsync(property);
        await unitOfWork.CompleteAsync();

        return property;
    }
}

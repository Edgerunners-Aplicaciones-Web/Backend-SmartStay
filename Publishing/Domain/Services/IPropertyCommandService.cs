using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Services;

public interface IPropertyCommandService
{

    Task<Property?> Handle(CreatePropertyCommand command);
}
namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
public record CreatePropertyCommand(
    string Name,
    string Location,
    string Description,
    decimal BasePrice,
    string Type
);
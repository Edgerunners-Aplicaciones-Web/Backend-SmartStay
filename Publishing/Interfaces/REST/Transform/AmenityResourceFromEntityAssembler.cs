using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
///     Assembler class to convert Amenity to AmenityResource
/// </summary>
public static class AmenityResourceFromEntityAssembler
{
    /// <summary>
    ///     Convert Amenity to AmenityResource
    /// </summary>
    /// <param name="entity">
    ///     The <see cref="Amenity" /> entity
    /// </param>
    /// <returns>
    ///     The <see cref="AmenityResource" /> resource
    /// </returns>
    public static AmenityResource ToResourceFromEntity(Amenity entity)
    {
        return new AmenityResource(entity.Id, entity.Name);
    }
}
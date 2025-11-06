using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;

using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Persistence.EFC.Repositories;

public class PropertyRepository(AppDbContext context) : BaseRepository<Property>(context), IPropertyRepository;
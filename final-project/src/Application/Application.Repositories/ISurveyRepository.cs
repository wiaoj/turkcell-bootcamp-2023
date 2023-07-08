using Domain.Entities.Survey;

namespace Infrastructure.Persistence.Repositories;
public interface ISurveyRepository : IAsyncRepository<SurveyEntity> { }
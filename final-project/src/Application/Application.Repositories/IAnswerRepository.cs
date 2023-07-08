using Domain.Entities.Answer;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories;
public interface IAnswerRepository : IAsyncRepository<AnswerEntity> {
    Task<AnswerEntity> GetBySurveyId(string surveyId);
}
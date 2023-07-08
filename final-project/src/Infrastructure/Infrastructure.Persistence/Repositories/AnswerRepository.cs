using Application.Repositories;
using Domain.Entities.Answer;
using Infrastructure.Persistence.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repositories;
internal sealed class AnswerRepository : AsyncRepository<AnswerEntity>, IAnswerRepository {
    public AnswerRepository(
        IOptions<ConnectionStrings> mongoDbSettings,
        IMongoClient client) : base(mongoDbSettings, client) {
    }

    public Task<AnswerEntity> GetBySurveyId(String surveyId) {
        return this.Entities.Find(x => x.SurveyId == surveyId).FirstOrDefaultAsync();
    }
}
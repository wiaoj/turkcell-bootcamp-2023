using Domain.Entities.Survey;
using Infrastructure.Persistence.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repositories;
internal sealed class SurveyRepository : AsyncRepository<SurveyEntity>, ISurveyRepository {
    public SurveyRepository(
        IOptions<ConnectionStrings> mongoDbSettings,
        IMongoClient client) : base(mongoDbSettings, client) {
    }
}
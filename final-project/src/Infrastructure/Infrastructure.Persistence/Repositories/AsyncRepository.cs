using Domain.Entities;
using Domain.Entities.Answer;
using Infrastructure.Persistence.Extensions;
using Infrastructure.Persistence.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repositories;
internal abstract class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : Entity {
    private readonly IMongoCollection<TEntity> entities;
    protected IMongoCollection<TEntity> Entities => this.entities;

    protected AsyncRepository(IOptions<ConnectionStrings> mongoDbSettings,
                              IMongoClient client) {
        IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.MongoDb.DatabaseName);
        this.entities = database.GetCollection<TEntity>();
    }

    public Task CreateAsync(TEntity entity) {
        return this.entities.InsertOneAsync(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() {
        return await this.entities.Find(x => true).ToListAsync();
    }

    public Task<TEntity> GetAsync(string id) {
        return this.entities.Find<TEntity>(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task UpdateAsync(string id, TEntity entity) {
        return this.entities.ReplaceOneAsync(x => x.Id == id, entity);
    }

    public Task RemoveAsync(TEntity entity) {
        return this.entities.DeleteOneAsync(x => x.Id == entity.Id);
    }

    public Task RemoveAsync(string id) {
        return this.entities.DeleteOneAsync(x => x.Id == id);
    }
}
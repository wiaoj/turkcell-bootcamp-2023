using Domain.Entities;
using Humanizer;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Extensions;
public static class MongoExtensions {
    public static IMongoCollection<TEntity> GetCollection<TEntity>(this IMongoDatabase database) 
        where TEntity : Entity {
        return database.GetCollection<TEntity>(typeof(TEntity).Name.TrimEntity().Pluralize(), null);
    }
    
    public static IMongoCollection<TEntity> GetCollection<TEntity>(
        this IMongoDatabase database,
        MongoCollectionSettings settings) 
        where TEntity : Entity {
        return database.GetCollection<TEntity>(typeof(TEntity).Name.TrimEntity(), settings);
    }
}
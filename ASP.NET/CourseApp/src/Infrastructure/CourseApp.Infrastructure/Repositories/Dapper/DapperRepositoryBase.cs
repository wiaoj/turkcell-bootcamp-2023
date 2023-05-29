using System.Data.SqlClient;
using System.Data;
using CourseApp.Entities;
using CourseApp.Infrastructure.Extensions;
using Dapper;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace CourseApp.Infrastructure.Repositories.Dapper;
public abstract class DapperRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new() {
    private readonly IConfiguration configuration;

    protected IDbConnection connection => 
        new SqlConnection(this.configuration.GetConnectionString("MsSQLConnectionString"));

    protected IEntity Entity => new TEntity();

    public DapperRepositoryBase(IConfiguration configuration) {
        this.configuration = configuration;
    }


    protected String GetInsertQuery
        => 
     $"INSERT INTO {Entity.GetDatabaseTableName()} ({Entity.GetInsertColumns()}) VALUES ({Entity.GetInsertValues()})";


    protected String GetDeleteByIdQuery => $@"DELETE FROM {Entity.GetDatabaseTableName()} WHERE Id = @Id";
    protected String GetUpdateQuery => $@"
            UPDATE FROM {Entity.GetDatabaseTableName()} 
            SET
            {Entity.GetUpdateColumnsValues()}
            WHERE Id = @Id";


    protected String GetByIdQuery => $@"SELECT TOP 1 * FROM {Entity.GetDatabaseTableName()} WHERE Id = @Id";

    protected String GetAllQuery => $@"SELECT * FROM {Entity.GetDatabaseTableName()}";

    protected String GetByPredicateQuery => $@"SELECT * FROM {Entity.GetDatabaseTableName()}";

    public TEntity? Get(Int32 id) {
        IEnumerable<TEntity> categories = this.connection.Query<TEntity>(GetByIdQuery, new { id });
        return categories.FirstOrDefault();
    }

    public async Task<TEntity?> GetAsync(Int32 id) {
        IEnumerable<TEntity> categories = await this.connection.QueryAsync<TEntity>(GetByIdQuery, new { Id = id });

        return categories.FirstOrDefault();
    }

    public IList<TEntity?> GetAll() {
        return this.connection.Query<TEntity>(GetAllQuery).ToList();
    }

    public async Task<IList<TEntity?>> GetAllAsync() {
        IEnumerable<TEntity> entities = await this.connection.QueryAsync<TEntity>(GetAllQuery);
        return entities.ToList();
    }

    public IList<TEntity> GetAllWithPredicate(Expression<Func<TEntity, Boolean>> predicate) {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(TEntity entity) {
        Int32 affectedRows = await this.connection.ExecuteAsync(GetInsertQuery, entity);

        if(affectedRows <= 0)
            throw new Exception("Veritabanına eklenemedi");
    }

    public async Task DeleteAsync(Int32 id) {
        Int32 affectedRows = await this.connection.ExecuteAsync(GetDeleteByIdQuery, id);

        if(affectedRows <= 0)
            throw new Exception("Veritabanından silinemedi");
    }

    public async Task UpdateAsync(TEntity entity) {
        Int32 affectedRows = await this.connection.ExecuteAsync(GetUpdateQuery, entity);

        if(affectedRows <= 0)
            throw new Exception("Veritabanında güncelleme yapılamadı");
    }
}
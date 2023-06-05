using KidegaClone.Domain.Entities;
using System.Linq.Expressions;

namespace KidegaClone.Application.Common.Specification;
public abstract class IncludeSpecification<TEntity> where TEntity : Entity, new() {
    public List<Expression<Func<TEntity, Object>>> Includes { get; }

    public IncludeSpecification() {
        this.Includes = new();
    }

    protected void AddInclude(Expression<Func<TEntity, Object>> includeExpression) {
        this.Includes.Add(includeExpression);
    }

    protected void AddInclude(params Expression<Func<TEntity, Object>>[] includeExpressions) {
        this.Includes.AddRange(includeExpressions);
    }
}
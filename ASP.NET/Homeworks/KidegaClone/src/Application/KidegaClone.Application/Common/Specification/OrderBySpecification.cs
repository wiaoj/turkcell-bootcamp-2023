using KidegaClone.Domain.Entities;
using System.Linq.Expressions;

namespace KidegaClone.Application.Common.Specification;
public class OrderBySpecification<TEntity> : Specification<TEntity> where TEntity : Entity, new() {
    public List<Expression<Func<TEntity, Object>>> Orders { get; }

    public OrderBySpecification() {
        this.Orders = new();
    }

    protected void AddInclude(Expression<Func<TEntity, Object>> orderExpression) {
        this.Orders.Add(orderExpression);
    }

    protected void AddInclude(params Expression<Func<TEntity, Object>>[] orderExpression) {
        this.Orders.AddRange(orderExpression);
    }
}

using KidegaClone.Domain.Entities;
using System.Linq.Expressions;

namespace KidegaClone.Application.Common.Specification;
public sealed class BookIncludeSpecification : IncludeSpecification<BookEntity> {
    public BookIncludeSpecification(Expression<Func<BookEntity, Object>> includeExpression) {
        this.AddInclude(includeExpression);
    }

    public new void AddInclude(params Expression<Func<BookEntity, Object>>[] includeExpressions) {
        base.AddInclude(includeExpressions);
    }
}
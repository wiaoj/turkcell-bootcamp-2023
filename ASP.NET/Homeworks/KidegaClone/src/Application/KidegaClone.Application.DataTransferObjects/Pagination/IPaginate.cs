namespace KidegaClone.Application.DataTransferObjects.Pagination;
public interface IPaginate<TEntity> /*where TEntity : IResponse */{
    public PaginationInfo PaginationInfo { get; }
    public IEnumerable<TEntity> Items { get; }
}
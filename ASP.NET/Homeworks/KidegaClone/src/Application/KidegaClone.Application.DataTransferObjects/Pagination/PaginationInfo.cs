namespace KidegaClone.Application.DataTransferObjects.Pagination;
public sealed record PaginationInfo(Int32 Index, Int32 Size, Int64 Count) {
    public Int32 Pages => (Int32)Math.Ceiling(this.Count / (Double)this.Size);
    public Boolean HasPrevious => this.Index - 1 > default(Int32);
    public Boolean HasNext => this.Index + 1 <= this.Pages;
}
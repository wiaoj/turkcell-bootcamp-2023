namespace CourseApp.Mvc.Models;
public class PagingInfo {
    public Int32 TotalItems { get; set; }
    public Int32 ItemsPerPage { get; set; }
    public Int32 CurrentPage { get; set; }
    public Int32 TotalPage => (Int32)Math.Ceiling((Decimal)this.TotalItems / (Decimal)this.ItemsPerPage);
}
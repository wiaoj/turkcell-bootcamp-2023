using CourseApp.DataTransferObjects.Responses;

namespace CourseApp.Mvc.Models;
public class PaginationCourseModel {
    public IEnumerable<CourseDisplayResponse> Courses { get; set; }
    public PagingInfo PagingInfo { get; set; }
}
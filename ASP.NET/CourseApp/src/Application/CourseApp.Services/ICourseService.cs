using CourseApp.DataTransferObjects.Responses;

namespace CourseApp.Services;
public interface ICourseService {
    public CourseDisplayResponse GetCourse(Int32 id);
    public IEnumerable<CourseDisplayResponse> GetCourseDisplayResponses();
    public IEnumerable<CourseDisplayResponse> GetCoursesByCategory(Int32 categoryId);
}
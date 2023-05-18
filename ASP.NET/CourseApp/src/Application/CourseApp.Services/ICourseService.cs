using CourseApp.DataTransferObjects.Responses;

namespace CourseApp.Services;
public interface ICourseService {
    public IEnumerable<CourseDisplayResponse> GetCourseDisplayResponses();
}
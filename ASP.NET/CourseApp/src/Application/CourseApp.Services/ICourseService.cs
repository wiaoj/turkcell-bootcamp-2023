using CourseApp.DataTransferObjects.Requests;
using CourseApp.DataTransferObjects.Responses;

namespace CourseApp.Services;
public interface ICourseService {
    public Task CreateCourseAsync(CreateNewCourseRequest createNewCourseRequest);
    public CourseDisplayResponse GetCourse(Int32 id);
    public IEnumerable<CourseDisplayResponse> GetCourseDisplayResponses();
    public IEnumerable<CourseDisplayResponse> GetCoursesByCategory(Int32 categoryId);

    public Task UpdateCourseAsync(UpdateCourseRequest updateCourseRequest);
    public Task<Boolean> CourseIsExists(Int32 id);
    public Task<UpdateCourseRequest> GetCourseForUpdateAsync(Int32 id);
}
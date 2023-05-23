using AutoMapper;
using CourseApp.DataTransferObjects.Responses;
using CourseApp.Entities;
using CourseApp.Infrastructure.Repositories;
using CourseApp.Services.Extensions;

namespace CourseApp.Services;
public sealed class CourseService : ICourseService {
    private readonly ICourseRepository courseRepository;
    private readonly IMapper mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper) {
        this.courseRepository = courseRepository;
        this.mapper = mapper;
    }

    public CourseDisplayResponse GetCourse(Int32 id) {
        Course course = this.courseRepository.Get(id);
        return this.mapper.Map<CourseDisplayResponse>(course);
    }

    public IEnumerable<CourseDisplayResponse> GetCourseDisplayResponses() {
        IList<Course?> courses = this.courseRepository.GetAll();
        return courses.ConvertToDisplayResponses(this.mapper);
    }

    public IEnumerable<CourseDisplayResponse> GetCoursesByCategory(Int32 categoryId) {
        IEnumerable<Course> courses = this.courseRepository.GetCoursesByCategory(categoryId);
        return courses.ConvertToDisplayResponses(this.mapper);
    }
}
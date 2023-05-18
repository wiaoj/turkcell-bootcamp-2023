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

    public IEnumerable<CourseDisplayResponse> GetCourseDisplayResponses() {
        var courses = this.courseRepository.GetAll();
        return courses.ConvertToDisplayResponses(this.mapper);
    }
}
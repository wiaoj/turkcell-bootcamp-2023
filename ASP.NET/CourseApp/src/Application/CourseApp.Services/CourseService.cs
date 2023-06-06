using AutoMapper;
using CourseApp.DataTransferObjects.Requests;
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

    public async Task CreateCourseAsync(CreateNewCourseRequest createNewCourseRequest) {
        Course course = this.mapper.Map<Course>(createNewCourseRequest);
        await this.courseRepository.CreateAsync(course);
    }

    public async Task UpdateCourseAsync(UpdateCourseRequest updateCourseRequest) {
        Course course = this.mapper.Map<Course>(updateCourseRequest);
        await this.courseRepository.UpdateAsync(course);
    }

    public async Task<Boolean> CourseIsExists(Int32 id) {
        return await this.courseRepository.IsExistsAsync(id);
    }

    public async Task<UpdateCourseRequest> GetCourseForUpdateAsync(Int32 id) {
        Course? course = await this.courseRepository.GetAsync(id);
        return this.mapper.Map<UpdateCourseRequest>(course);
    }

    public async Task<IEnumerable<CourseDisplayResponse>> SearchByTitleAsync(String title) {
        IEnumerable<Course> courses = await this.courseRepository.GetCoursesByTitleAsync(title);
        return courses.ConvertToDisplayResponses(this.mapper);
    }

    public async Task<Int32> CreateCourseAndReturnIdAsync(CreateNewCourseRequest createNewCourseRequest) {
        Course course = this.mapper.Map<Course>(createNewCourseRequest);
        await this.courseRepository.CreateAsync(course);
        return course.Id;
    }

    public async Task DeleteAsync(Int32 id) {
        await this.courseRepository.DeleteAsync(id);
    }
}
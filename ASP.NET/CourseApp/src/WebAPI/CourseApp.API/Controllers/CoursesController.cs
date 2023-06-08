using CourseApp.API.Filters;
using CourseApp.DataTransferObjects.Requests;
using CourseApp.DataTransferObjects.Responses;
using CourseApp.Entities;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase {
    // Public API => REST: Respresentational (Temsili) State Transfer
    private readonly ICourseService courseService;

    public CoursesController(ICourseService courseService) {
        this.courseService = courseService;
    }

    [HttpGet]
    public IActionResult GetCourses() {
        IEnumerable<CourseDisplayResponse> courses = this.courseService.GetCourseDisplayResponses();
        return Ok(courses);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetCourse(Int32 id) {
        CourseDisplayResponse? course = this.courseService.GetCourse(id);

        if(course is null) {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> SearchCourseByTitle([FromQuery] String title) {
        IEnumerable<CourseDisplayResponse> courses = await this.courseService.SearchByTitleAsync(title);
        return Ok(courses);
    }

    [HttpGet("[action]/{categoryId:int}")]
    public IActionResult GetCoursesByCategory(Int32 categoryId) {
        IEnumerable<CourseDisplayResponse> courses = this.courseService.GetCoursesByCategory(categoryId);

        return Ok(courses);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNewCourseRequest request) {
        if(ModelState.IsValid is false) {
            return BadRequest(ModelState);
        }

        Int32 lastCourseId = await this.courseService.CreateCourseAndReturnIdAsync(request);
        return CreatedAtAction(nameof(GetCourse), routeValues: new { id = lastCourseId }, null);
    }

    [HttpPut("{id}")]
    [IsExists]
    public async Task<IActionResult> Update(Int32 id, UpdateCourseRequest request) {
        if(ModelState.IsValid is false)
            return BadRequest(ModelState);

        await this.courseService.UpdateCourseAsync(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [IsExists]
    public async Task<IActionResult> Delete(Int32 id) {
        await this.courseService.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("[action]")]
    [NotImplemented]
    public IActionResult NotImplemented() {
        throw new NotImplementedException();
    }
}
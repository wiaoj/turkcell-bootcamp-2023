using System.ComponentModel.DataAnnotations;

namespace CourseApp.DataTransferObjects.Requests;
public record UpdateCourseRequest(
    Int32 Id,
    [
        Required(ErrorMessage = "Kurs adını boş bırakmayınız"),
        MinLength(3, ErrorMessage = "En az üç harf")
     ] String Title,
    String? Description,
    DateTime? StartDate,
    DateTime? EndDate,
    Decimal? Price,
    Int32? TotalHours,
    Byte? Rating,
    Int32? CategoryId,
    String ImageUrl = "https://loremflickr.com/320/240");
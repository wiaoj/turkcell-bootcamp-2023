namespace CourseApp.DataTransferObjects.Responses;
public record CourseDisplayResponse(
    Int32 Id,
    String Title,
    String? Description,
    Decimal Price,
    Byte? Rating,
    String ImageUrl = "https://loremflickr.com/320/240");
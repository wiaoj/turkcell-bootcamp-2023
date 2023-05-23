namespace CourseApp.DataTransferObjects.Responses;
public record CategoryDisplayResponse(
    Int32 Id,
    String Name,
    String? Description);
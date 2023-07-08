using Application.DataTransferObjects.Responses.Questions;

namespace Application.DataTransferObjects.Responses.Surveys;
public sealed record SurveyDisplayResponse(
    string Id,
    string Title,
    string? Description,
    IEnumerable<QuestionDisplayResponse>? Questions) : IResponse;
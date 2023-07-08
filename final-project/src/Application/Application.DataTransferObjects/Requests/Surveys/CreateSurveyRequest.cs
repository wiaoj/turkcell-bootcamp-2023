using Application.DataTransferObjects.Requests.Questions;

namespace Application.DataTransferObjects.Requests.Surveys;
public sealed record CreateSurveyRequest(
    string Title,
    string? Description,
    IEnumerable<CreateQuestionRequest>? Questions) : IRequest;
namespace Application.DataTransferObjects.Requests.Answers;
public sealed record AnswerSurveyRequest(
    string SurveyId,
    IEnumerable<AnswerQuestionRequest> Questions) : IRequest;
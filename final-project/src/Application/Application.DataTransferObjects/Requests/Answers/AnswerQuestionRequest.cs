namespace Application.DataTransferObjects.Requests.Answers;
public sealed record AnswerQuestionRequest(
    string Id,
    IEnumerable<AnswerOptionRequest> Options) : IRequest;
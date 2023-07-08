namespace Application.DataTransferObjects.Responses.Answers;
public sealed record AnswerDisplayResponse(
    string Id,
    string SurveyId,
    int TotalVote,
    IEnumerable<AnswerQuestionDisplay> Questions) : IResponse;

public sealed record AnswerQuestionDisplay(
    string Id,
    string QuestionId,
    bool IsMultiSelect,
    int TotalVote,
    IEnumerable<AnswerQuestionOptionDisplay> Options);

public sealed record AnswerQuestionOptionDisplay(
    string Id,
    string OptionId,
    int VoteCount);
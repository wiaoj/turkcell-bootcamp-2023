namespace Application.DataTransferObjects.Responses.Answers;
public sealed record AnswerStatisticsResponse(
    string Id,
    string SurveyId,
    int TotalVote,
    IEnumerable<AnswerQuestionStatistics> Questions) : IResponse;

public sealed record AnswerQuestionStatistics(
    string Id,
    string QuestionId,
    int TotalVote,
    double Percentage,
    IEnumerable<AnswerQuestionOptionStatistics> Options) : IResponse;

public sealed record AnswerQuestionOptionStatistics(
    string Id,
    string OptionId,
    int VoteCount,
    double Percentage) : IResponse;
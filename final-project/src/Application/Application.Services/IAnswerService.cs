namespace Application.Services;
public interface IAnswerService {
    Task AnswerSurveyAsync(AnswerSurveyRequest answerSurveyRequest);
    Task<AnswerDisplayResponse> GetAnswerByIdAsync(string id);
    Task<IEnumerable<AnswerDisplayResponse>> GetAnswersAsync();
    Task<AnswerStatisticsResponse> GetAnswerStatisticsAsync(string id);
}
namespace Application.Services;
public interface ISurveyService {
    Task<string> CreateSurveyAsync(CreateSurveyRequest createSurveyRequest);
    Task<SurveyDisplayResponse> GetSurveyByIdAsync(string id);
    Task<IEnumerable<SurveyDisplayResponse>> GetSurveysAsync();
}
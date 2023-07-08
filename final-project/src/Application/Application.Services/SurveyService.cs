using Domain.Entities.Survey;

namespace Application.Services;
internal class SurveyService : ISurveyService {
    private readonly ISurveyRepository surveyRepository;

    public SurveyService(ISurveyRepository surveyRepository) {
        this.surveyRepository = surveyRepository;
    }

    public async Task<string> CreateSurveyAsync(CreateSurveyRequest createSurveyRequest) {
        List<QuestionEntity> questions = new();

        createSurveyRequest.Questions?.ToList().ForEach(question => {
            if(question.Type == "rating") {
                if(question.MinimumValueDescription is null || question.MaximumValueDescription is null)
                    throw new NotSupportedException(
                        "rating türünde minimum ve maksimum isimleri boş geçemezsin");

                RatingQuestionEntity ratingQuestion = new(question.Text,
                                                 question.MinimumValueDescription,
                                                 question.MaximumValueDescription);
                questions.Add(ratingQuestion);
                return;
            }

            questions.Add(question.MapTo<QuestionEntity>());
        });

        SurveyEntity survey = createSurveyRequest.MapTo<SurveyEntity>();
        survey.SetQuestions(questions);

        await this.surveyRepository.CreateAsync(survey);
        return survey.Id;
    }

    public async Task<SurveyDisplayResponse> GetSurveyByIdAsync(string id) {
        SurveyEntity survey = await this.surveyRepository.GetAsync(id);
        return survey.MapTo<SurveyDisplayResponse>();
    }

    public async Task<IEnumerable<SurveyDisplayResponse>> GetSurveysAsync() {
        IEnumerable<SurveyEntity> surveys = await this.surveyRepository.GetAllAsync();
        return surveys.MapTo<SurveyDisplayResponse>();
    }
}
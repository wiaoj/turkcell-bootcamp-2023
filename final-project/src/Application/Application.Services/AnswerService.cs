using Domain.Entities.Answer;
using Domain.Entities.Survey;

namespace Application.Services;
public sealed class AnswerService : IAnswerService {
    private readonly IAnswerRepository answerRepository;
    private readonly ISurveyRepository surveyRepository;

    public AnswerService(IAnswerRepository answerRepository,
                         ISurveyRepository surveyRepository) {
        this.answerRepository = answerRepository;
        this.surveyRepository = surveyRepository;
    }

    public async Task AnswerSurveyAsync(AnswerSurveyRequest answerSurveyRequest) {
        SurveyEntity surveyEntity = await this.surveyRepository.GetAsync(answerSurveyRequest.SurveyId)
            ?? throw new Exception("Anket bulunamadı");

        AnswerEntity? answerEntity = 
            await this.answerRepository.GetBySurveyId(answerSurveyRequest.SurveyId);

        bool isAnswerCreated = createNewAnswerEntityIfNull(ref answerEntity, surveyEntity);

        answerEntity!.AddVote();

        voteQuestion(answerSurveyRequest, answerEntity);

        if(isAnswerCreated)
            await this.answerRepository.CreateAsync(answerEntity);
        else
            await this.answerRepository.UpdateAsync(answerEntity.Id, answerEntity);
    }

    private static void voteQuestion(AnswerSurveyRequest answerSurveyRequest,
                                     AnswerEntity answerEntity) {
        answerEntity.Questions.ToList().ForEach(answerQuestion => {
            foreach(var answerQuestionRequest in answerSurveyRequest.Questions) {
                if(answerQuestion.QuestionId != answerQuestionRequest.Id)
                    continue;

                answerQuestion.AddVote();
                voteOption(answerQuestion, answerQuestionRequest, answerQuestion.IsMultiSelect);
            }
        });
    }

    private static void voteOption(QuestionAnswerEntity answerQuestion,
                                   AnswerQuestionRequest answerQuestionRequest,
                                   bool isMultiSelect) {

        foreach(var answerOption in answerQuestion.Options) {
            foreach(var answerOptionRequest in answerQuestionRequest.Options) {
                if(answerOption.OptionId != answerOptionRequest.Id)
                    continue;

                answerOption.AddVote();

                if(isMultiSelect is false) {
                    return;
                }
            }
        }
    }

    private bool createNewAnswerEntityIfNull(ref AnswerEntity? answerEntity,
                                             SurveyEntity surveyEntity) {
        if(answerEntity is not null)
            return false;

        answerEntity = new(surveyEntity.Id);
        answerEntity.AddQuestions(surveyEntity.Questions.MapTo<QuestionAnswerEntity>());
        return true;
    }

    public async Task<AnswerDisplayResponse> GetAnswerByIdAsync(string id) {
        AnswerEntity answer = await this.answerRepository.GetAsync(id);
        return answer.MapTo<AnswerDisplayResponse>();
    }

    public async Task<IEnumerable<AnswerDisplayResponse>> GetAnswersAsync() {
        IEnumerable<AnswerEntity> answers = await this.answerRepository.GetAllAsync();
        return answers.MapTo<AnswerDisplayResponse>();
    }

    public async Task<AnswerStatisticsResponse> GetAnswerStatisticsAsync(string id) {
        AnswerEntity answer = await this.answerRepository.GetAsync(id);

        List<AnswerQuestionStatistics> answerQuestionStatistics = new();

        answer.Questions.ForEach(question => {
            bool isQuestionNotVoted = false;
            if(question.TotalVote is default(int))
                isQuestionNotVoted = true;

            List<AnswerQuestionOptionStatistics> answerQuestionOptionStatistics = new();

            question.Options.ToList().ForEach(option => {

                var percentage = isQuestionNotVoted
                        ? 0 : (double)option.VoteCount / question.TotalVote * 100;

                AnswerQuestionOptionStatistics questionOptionStatistics =
                new(option.Id, option.OptionId, option.VoteCount, percentage);

                answerQuestionOptionStatistics.Add(questionOptionStatistics);
            });

            var percentage = isQuestionNotVoted
                        ? 0 : (double)question.TotalVote / answer.TotalVote * 100;

            AnswerQuestionStatistics questionStatistics =
            new(question.Id, question.QuestionId, question.TotalVote, percentage, answerQuestionOptionStatistics);

            answerQuestionStatistics.Add(questionStatistics);
        });

        AnswerStatisticsResponse answerStatistics = new(answer.Id, answer.SurveyId, answer.TotalVote, answerQuestionStatistics);

        return answerStatistics;
    }
}
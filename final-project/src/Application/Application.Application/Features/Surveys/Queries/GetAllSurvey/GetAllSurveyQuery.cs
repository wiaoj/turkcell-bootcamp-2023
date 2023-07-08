namespace Application.Application.Features.Surveys.Queries.GetAllSurvey;
public sealed record GetAllSurveyQuery() : IRequest<IEnumerable<SurveyDisplayResponse>> {
    private sealed class Handler : IRequestHandler<GetAllSurveyQuery, IEnumerable<SurveyDisplayResponse>> {
        private readonly ISurveyService surveyService;

        public Handler(ISurveyService surveyService) {
            this.surveyService = surveyService;
        }

        public Task<IEnumerable<SurveyDisplayResponse>> Handle(GetAllSurveyQuery request, CancellationToken cancellationToken) {
            return this.surveyService.GetSurveysAsync();
        }
    }
}
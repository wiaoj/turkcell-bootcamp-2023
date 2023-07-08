namespace Application.Application.Features.Surveys.Queries.GetSurvey;
public sealed record GetSurveyQuery(string Id) : IRequest<SurveyDisplayResponse> {
    private sealed class Handler : IRequestHandler<GetSurveyQuery, SurveyDisplayResponse> {
        private readonly ISurveyService surveyService;

        public Handler(ISurveyService surveyService) {
            this.surveyService = surveyService;
        }

        public Task<SurveyDisplayResponse> Handle(GetSurveyQuery request, CancellationToken cancellationToken) {
            return this.surveyService.GetSurveyByIdAsync(request.Id);
        }
    }
}
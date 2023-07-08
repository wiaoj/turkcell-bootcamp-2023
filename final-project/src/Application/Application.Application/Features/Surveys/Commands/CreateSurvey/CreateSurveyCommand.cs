namespace Application.Application.Features.Surveys.Commands.CreateSurvey;
public sealed record CreateSurveyCommand(CreateSurveyRequest CreateSurvey) : IRequest<string> {
    private sealed class Handler : IRequestHandler<CreateSurveyCommand, string> {
        private readonly ISurveyService surveyService;

        public Handler(ISurveyService surveyService) {
            this.surveyService = surveyService;
        }

        public Task<string> Handle(CreateSurveyCommand request, CancellationToken cancellationToken) {
            return this.surveyService.CreateSurveyAsync(request.CreateSurvey);
        }
    }
}
namespace Application.Application.Features.Answers.Commands.AnswerSurvey;
public sealed record AnswerSurveyCommand(AnswerSurveyRequest AnswerSurvey) : IRequest {
    private sealed class Handler : IRequestHandler<AnswerSurveyCommand> {
        private readonly IAnswerService answerService;

        public Handler(IAnswerService answerService) {
            this.answerService = answerService;
        }

        public Task Handle(AnswerSurveyCommand request, CancellationToken cancellationToken) {
            return this.answerService.AnswerSurveyAsync(request.AnswerSurvey);
        }
    }
}
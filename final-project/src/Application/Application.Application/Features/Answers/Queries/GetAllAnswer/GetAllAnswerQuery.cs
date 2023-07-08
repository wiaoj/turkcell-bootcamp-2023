namespace Application.Application.Features.Answers.Queries.GetAllAnswer;
public sealed record GetAllAnswerQuery() : IRequest<IEnumerable<AnswerDisplayResponse>> {
    private sealed class Handler : IRequestHandler<GetAllAnswerQuery, IEnumerable<AnswerDisplayResponse>> {
        private readonly IAnswerService answerService;

        public Handler(IAnswerService answerService) {
            this.answerService = answerService;
        }

        public Task<IEnumerable<AnswerDisplayResponse>> Handle(GetAllAnswerQuery request, CancellationToken cancellationToken) {
            return this.answerService.GetAnswersAsync();
        }
    }
}
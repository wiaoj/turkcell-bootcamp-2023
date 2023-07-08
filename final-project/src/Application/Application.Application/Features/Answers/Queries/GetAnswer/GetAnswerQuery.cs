namespace Application.Application.Features.Answers.Queries.GetAnswer;
public sealed record GetAnswerQuery(string Id) : IRequest<AnswerDisplayResponse> {
    private sealed class Handler : IRequestHandler<GetAnswerQuery, AnswerDisplayResponse> {
        private readonly IAnswerService answerService;

        public Handler(IAnswerService answerService) {
            this.answerService = answerService;
        }

        public Task<AnswerDisplayResponse> Handle(GetAnswerQuery request, CancellationToken cancellationToken) {
            return this.answerService.GetAnswerByIdAsync(request.Id);
        }
    }
}
namespace Application.Application.Features.Answers.Queries.GetAnswer;
public sealed record GetAnswerStatisticsQuery(string Id) : IRequest<AnswerStatisticsResponse> {
    private sealed class Handler : IRequestHandler<GetAnswerStatisticsQuery, AnswerStatisticsResponse> {
        private readonly IAnswerService answerService;

        public Handler(IAnswerService answerService) {
            this.answerService = answerService;
        }

        public Task<AnswerStatisticsResponse> Handle(GetAnswerStatisticsQuery request, CancellationToken cancellationToken) {
            return this.answerService.GetAnswerStatisticsAsync(request.Id);
        }
    }
}
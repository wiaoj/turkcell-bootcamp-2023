using Application.DataTransferObjects.Requests.Options;

namespace Application.DataTransferObjects.Requests.Questions;
public sealed record CreateQuestionRequest(
    string Text,
    bool? IsMultiSelect,
    string? Type,
    string? MinimumValueDescription,
    string? MaximumValueDescription,
    IEnumerable<CreateOptionRequest>? Options) : IRequest;
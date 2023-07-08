using Application.DataTransferObjects.Responses.Options;

namespace Application.DataTransferObjects.Responses.Questions;
public record QuestionDisplayResponse(
    string Id,
    string Text,
    string Type,
    bool IsMultiSelect,
    IEnumerable<OptionDisplayResponse> Options) : IResponse;
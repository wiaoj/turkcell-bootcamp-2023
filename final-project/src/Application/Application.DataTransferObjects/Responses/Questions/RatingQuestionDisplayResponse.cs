using Application.DataTransferObjects.Responses.Options;

namespace Application.DataTransferObjects.Responses.Questions;
public sealed record RatingQuestionDisplayResponse(
    string Id,
    string Text,
    string Type,
    string MinimumValueDescription,
    string MaximumValueDescription,
    IEnumerable<OptionDisplayResponse> Options)
    : QuestionDisplayResponse(Id, Text, Type, false, Options), IResponse;
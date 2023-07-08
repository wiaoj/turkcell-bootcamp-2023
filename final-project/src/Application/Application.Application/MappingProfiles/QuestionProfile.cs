using Application.DataTransferObjects.Requests.Questions;
using Application.DataTransferObjects.Responses.Options;
using Application.DataTransferObjects.Responses.Questions;
using Application.Services.Extensions;
using AutoMapper;
using Domain.Entities.Answer;
using Domain.Entities.Survey;

namespace Application.Application.MappingProfiles;
internal sealed class QuestionProfile : Profile {
    public QuestionProfile() {
        CreateMap<CreateQuestionRequest, QuestionEntity>();
        CreateMap<CreateQuestionRequest, RatingQuestionEntity>();

        CreateMap<QuestionEntity, QuestionDisplayResponse>()
            .ConstructUsing((src, ctx) => {
                if(src.Type == "rating" && src is RatingQuestionEntity ratingQuestion) {

                    return new RatingQuestionDisplayResponse(
                        src.Id,
                        src.Text,
                        src.Type,
                        ratingQuestion.MinimumValueDescription,
                        ratingQuestion.MaximumValueDescription,
                        src.Options.MapTo<OptionDisplayResponse>());
                }

                return new QuestionDisplayResponse(
                    src.Id,
                    src.Text,
                    src.Type,
                    src.IsMultiSelect,
                    src.Options.MapTo<OptionDisplayResponse>());
            });

        CreateMap<QuestionEntity, RatingQuestionDisplayResponse>();

        CreateMap<QuestionEntity, QuestionAnswerEntity>()
            .ForMember(
                destination => destination.Id,
                options => options.Ignore())
            .ForMember(
                destionation => destionation.QuestionId,
                source => source.MapFrom(x => x.Id));
    }
}
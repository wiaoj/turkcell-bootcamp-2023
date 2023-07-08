using AutoMapper;
using Domain.Entities.Answer;

namespace Application.Application.MappingProfiles;
internal sealed class AnswerProfile : Profile {
    public AnswerProfile() {
        CreateMap<AnswerSurveyRequest, AnswerEntity>()
            .ForMember(
            destionation => destionation.SurveyId,
            source => source.MapFrom(x => x.SurveyId))
            .ForMember(
            destionation => destionation.Questions,
            source => source.MapFrom(x => x.Questions)).ReverseMap();

        CreateMap<AnswerQuestionRequest, QuestionAnswerEntity>()
            .ForMember(
            destionation => destionation.QuestionId,
            source => source.MapFrom(x => x.Id))
            .ForMember(
            destionation => destionation.Options,
            source => source.MapFrom(x => x.Options)).ReverseMap();

        CreateMap<AnswerOptionRequest, OptionAnswerEntity>()
            .ForMember(
            destionation => destionation.OptionId,
            source => source.MapFrom(x => x.Id)).ReverseMap();


        CreateMap<AnswerEntity, AnswerDisplayResponse>();
        CreateMap<QuestionAnswerEntity, AnswerQuestionDisplay>();
        CreateMap<OptionAnswerEntity, AnswerQuestionOptionDisplay>();


        CreateMap<OptionAnswerEntity, AnswerQuestionOptionStatistics>();
        CreateMap<QuestionAnswerEntity, AnswerQuestionStatistics>();
        CreateMap<AnswerEntity, AnswerStatisticsResponse>();
    }
}
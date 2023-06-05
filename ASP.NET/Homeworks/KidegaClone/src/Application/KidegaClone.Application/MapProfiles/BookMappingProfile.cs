using AutoMapper;
using KidegaClone.Application.DataTransferObjects.Requests;
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.MapProfiles;
internal class BookMappingProfile : Profile {
    public BookMappingProfile() {
        CreateMap<BookEntity, BookDisplayResponse>()
            .ForMember(
                source => source.AuthorFullName,
                destination => destination.MapFrom(
                    entity => entity.Author!.FullName));

        CreateMap<GenreEntity, BookDetailGenre>();
        CreateMap<AuthorEntity, BookDetailAuthor>();
        CreateMap<BookEntity, BookDetailResponse>();


        CreateMap<CreateBookRequest, BookEntity>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(genreId => new GenreEntity { Id = genreId })));

        CreateMap<BookEntity, UpdateBookDetailsResponse>();

        CreateMap<UpdateBookRequest, BookEntity>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(genreId => new GenreEntity { Id = genreId })));
    }
}
using KidegaClone.Application.BusinessRules;
using KidegaClone.Application.Common;
using KidegaClone.Application.Common.Specification;
using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Requests;
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Application.Extensions;
using KidegaClone.Application.Repositories;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Services;
internal sealed class BookService : IBookService {
    private readonly IBookRepository bookRepository;
    private readonly IGenreRepository genreRepository;
    private readonly IBookBusinessRules bookBusinessRules;

    public BookService(IBookRepository bookRepository,
                       IGenreRepository genreRepository,
                       IBookBusinessRules bookBusinessRules) {
        this.bookRepository = bookRepository;
        this.genreRepository = genreRepository;
        this.bookBusinessRules = bookBusinessRules;
    }

    public async Task CreateBookAsync(CreateBookRequest createBookRequest) {
        BookEntity book = createBookRequest.MapTo<BookEntity>();

        book.Genres = book.Genres = await checkAndAddGenres(book.Genres);
        await this.bookRepository.CreateAsync(book);
        await this.bookRepository.SaveChangesAsync();
    }

    public async Task<IPaginate<BookDisplayResponse>> GetAllBooksAsync(PaginationRequest paginationRequest) {
        BookIncludeSpecification booksIncludeSpecification = new(x => x.Author!);
        IPaginate<BookEntity> paginatedBooks =
            await this.bookRepository.GetAllPaginatedAsync(paginationRequest, booksIncludeSpecification);
        return paginatedBooks.MapToPaginate<BookEntity, BookDisplayResponse>();
    }

    public async Task<UpdateBookDetailsResponse> GetBookDetailsByIdForUpdate(Guid id) {
        BookIncludeSpecification bookIncludeSpecification = new(book => book.Author!);
        bookIncludeSpecification.AddInclude(book => book.Category!, book => book.Genres!);

        BookEntity? book = await this.bookRepository.GetByIdAsync(id, bookIncludeSpecification);
        this.bookBusinessRules.IfBookIsNullThrow(book);
        return book!.MapTo<UpdateBookDetailsResponse>();
    }

    public async Task<BookDetailResponse> GetBookByIdWithAuthorAsync(Guid id) {
        BookEntity? book = await this.bookRepository.GetByIdWithAuthorAsync(id);
        this.bookBusinessRules.IfBookIsNullThrow(book);
        return book!.MapTo<BookDetailResponse>();
    }

    public async Task UpdateBookAsync(UpdateBookRequest updateBookRequest) {
        BookEntity? originalBook = await this.bookRepository.GetByIdAsync(updateBookRequest.Id);
        this.bookBusinessRules.IfBookIsNullThrow(originalBook);

        BookEntity book = updateBookRequest.MapTo<BookEntity>(originalBook!);

        book.Genres = await checkAndAddGenres(book.Genres);
        await this.bookRepository.CreateAsync(book);
        await this.bookRepository.SaveChangesAsync();
    }

    private async Task<ICollection<GenreEntity>> checkAndAddGenres(IEnumerable<GenreEntity> genres) {
        ICollection<GenreEntity> genress = new List<GenreEntity>();
        foreach(var genre in genres) {
            GenreEntity genreEntity = await this.genreRepository.GetByIdAsync(genre.Id)
                            ?? throw new Exception("Kitap türü bulunamadı dırırırı");
            genress.Add(genreEntity);
        }

        return genress;
    }

    public async Task DeleteBookAsync(DeleteBookRequest deleteBookRequest) {
        BookEntity? book = await this.bookRepository.GetByIdAsync(deleteBookRequest.Id);
        this.bookBusinessRules.IfBookIsNullThrow(book);
        await this.bookRepository.DeleteAsync(book!);
        await this.bookRepository.SaveChangesAsync();
    }
}
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Application.Extensions;
using KidegaClone.Application.Repositories;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Services;
internal sealed class AuthorService : IAuthorService {
    private readonly IAuthorRepository authorRepository;

    public AuthorService(IAuthorRepository authorRepository) {
        this.authorRepository = authorRepository;
    }

    public async Task<IEnumerable<AuthorSelectionResponse>> GetAllSelectionAuthorsAsync() {
        IEnumerable<AuthorEntity> authors = await this.authorRepository.GetAllAsync();
        return authors.MapTo<AuthorSelectionResponse>();
    }
}
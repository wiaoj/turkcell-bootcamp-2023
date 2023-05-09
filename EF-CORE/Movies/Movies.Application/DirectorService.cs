using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;
using Movies.Data.Repositories;
using Movies.Entities;

namespace Movies.Application;
public class DirectorService : IDirectorService {
    private readonly IDirectorRepository directorRepository;

    public DirectorService(IDirectorRepository directorRepository) {
        this.directorRepository = directorRepository;
    }

    public async Task<Int32> CreateNewDirectorAsync(CreateNewDirectorRequest createDirector) {
        Director director = new() {
            Name = createDirector.Name,
            LastName = createDirector.LastName,
            Info = createDirector.Info,
        };

        await this.directorRepository.CreateAsync(director);
        return director.Id;
    }

    public async Task<SingleDirectorResponse> GetDirectorAsync(Int32 id) {
        Director director = await this.directorRepository.GetByIdAsync(id);

        return new() {
            Name = director.Name,
            LastName = director.LastName,
            Info = director.Info
        };
    }

    public async Task<IEnumerable<DirectorListResponse>> GetDirectorsAsync() {
        IEnumerable<Entities.Director> directors = await this.directorRepository.GetAllAsync();
        IEnumerable<DirectorListResponse> responses = directors.Select(director => new DirectorListResponse {
            Id = director.Id,
            Name = director.Name,
            LastName = director.LastName,
            Info = director.Info
        });
        return responses;
    }

    public async Task UpdateDirectorAsync(UpdateDirectorRequest updateDirector) {
        Director director = new Director() {
            Id = updateDirector.Id,
            Name = updateDirector.Name,
            LastName = updateDirector.LastName,
            Info = updateDirector.Info
        };

        await this.directorRepository.UpdateAsync(director);
    }
}
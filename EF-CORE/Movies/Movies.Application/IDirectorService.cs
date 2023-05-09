using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;

namespace Movies.Application;
public interface IDirectorService {
    public Task<IEnumerable<DirectorListResponse>> GetDirectorsAsync();
    public Task<Int32> CreateNewDirectorAsync(CreateNewDirectorRequest createDirector);
    public Task<SingleDirectorResponse> GetDirectorAsync(Int32 id);
    public Task UpdateDirectorAsync(UpdateDirectorRequest updateDirector);
}
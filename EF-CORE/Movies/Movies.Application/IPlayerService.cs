using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;

namespace Movies.Application;
public interface IPlayerService {
    public Task<Int32> CreateNewPlayer(CreateNewPlayerRequest createNewPlayer);
    public Task<IEnumerable<PlayerListResponse>> GetPlayers();
    public Task UpdatePlayer(UpdatePlayerRequest updatePlayer);
}
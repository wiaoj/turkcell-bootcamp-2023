using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;
using Movies.Data.Repositories;
using Movies.Entities;

namespace Movies.Application;
public class PlayerService : IPlayerService {
    private readonly IPlayerRepository playerRepository;

    public PlayerService(IPlayerRepository playerRepository) {
        this.playerRepository = playerRepository;
    }

    public async Task<IEnumerable<PlayerListResponse>> GetPlayers() {
        IEnumerable<Player> players = await this.playerRepository.GetAllAsync();

        return players.Select(player => new PlayerListResponse {
            Id = player.Id,
            Name = player.Name,
            LastName = player.LastName
        });
    }

    public async Task<Int32> CreateNewPlayer(CreateNewPlayerRequest createNewPlayer) {
        Player player = new() {
            Name = createNewPlayer.Name,
            LastName = createNewPlayer.LastName
        };
        await this.playerRepository.CreateAsync(player);
        return player.Id;
    }

    public async Task UpdatePlayer(UpdatePlayerRequest updatePlayer) {
        Player player = new() {
            Id = updatePlayer.Id,
            Name = updatePlayer.Name,
            LastName = updatePlayer.LastName
        };
        await this.playerRepository.UpdateAsync(player);
    }
}

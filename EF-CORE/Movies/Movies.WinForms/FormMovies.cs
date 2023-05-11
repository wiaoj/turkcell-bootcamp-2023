using Movies.Application;
using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;
using Movies.Data.Data;
using Movies.Data.Repositories;
using System.Data;

namespace Movies.WinForms;
public partial class FormMovies : Form {
    public FormMovies() {
        this.InitializeComponent();
        MoviesDbContext moviesDbContext = new();
        EFPlayerRepository playerRepository = new(moviesDbContext);
        EFMovieRepository movieRepository = new(moviesDbContext);
        EFDirectorRepository directorRepository = new(moviesDbContext);

        this.playerService = new PlayerService(playerRepository);
        this.movieService = new MovieService(movieRepository);
        this.directorService = new DirectorService(directorRepository);
    }

    private readonly IPlayerService playerService;
    private readonly IMovieService movieService;
    private readonly IDirectorService directorService;

    private async void FormMovies_Load(Object sender, EventArgs e) {
        await this.fillDirectors();
        await this.fillPlayers();
    }

    private async Task fillPlayers() {
        IEnumerable<PlayerListResponse> players = await this.playerService.GetPlayers();
        var playerFullNames = players.Select(player => new {
            Id = player.Id,
            FullName = $"{player.Name} {player.LastName}"
        });
        this.listBoxPlayers.DataSource = playerFullNames.ToList();
        this.listBoxPlayers.DisplayMember = "FullName";
        this.listBoxPlayers.ValueMember = "Id";
    }

    private async Task fillDirectors() {
        IEnumerable<DirectorListResponse> directors = await this.directorService.GetDirectorsAsync();
        var directorFullNames = directors.Select(director => new {
            Id = director.Id,
            FullName = $"{director.Name} {director.LastName}"
        });

        this.comboBoxDirectors.DataSource = directorFullNames.ToList();
        this.comboBoxDirectors.DisplayMember = "FullName";
        this.comboBoxDirectors.ValueMember = "Id";
    }

    private async void buttonAdd_Click(Object sender, EventArgs e) {
        List<Int32> selectedPlayerIds = new();
        foreach(dynamic item in this.listBoxPlayers.SelectedItems) {
            selectedPlayerIds.Add(item.Id);
        }

        CreateNewMovieRequest createNewMovieRequest = new() {
            DirectorId = (Int32)this.comboBoxDirectors.SelectedValue!,
            Duration = Convert.ToInt32(this.textBoxDuration.Text),
            Name = this.textBoxTitle.Text,
            PublishDate = this.dateTimePickerPublishDate.Value
        };

        Int32 movieId = await this.movieService.CreateNewMovie(createNewMovieRequest);

        await this.movieService.AddPlayersToMovie(movieId, selectedPlayerIds);
    }
}

using Movies.Application;
using Movies.Application.DTOs.Responses;
using Movies.Data.Data;
using Movies.Data.Repositories;

namespace Movies.WinForms;

public partial class Form1 : Form {
    public Form1() {
        this.InitializeComponent();
    }
    MovieService movieService = null;

    private async void Form1_Load(Object sender, EventArgs e) {
        MoviesDbContext moviesDbContext = new();
        EFMovieRepository eFMovieRepository = new(moviesDbContext);
        movieService = new(eFMovieRepository);

        await fillMovies();
    }

    private async Task fillMovies() {
        IEnumerable<MovieListResponse> list = await this.movieService.GetAllMovies();
        dataGridViewMovies.DataSource = list.ToList();
    }

    private void buttonDirector_Click(Object sender, EventArgs e) {
        FormDirectors formDirectors = new();
        formDirectors.Show();
    }

    private void buttonPlayer_Click(Object sender, EventArgs e) {
        FormPlayers formPlayers = new();
        formPlayers.Show();
    }

    private async void buttonGetAllMovies_Click(Object sender, EventArgs e) {
        await fillMovies();
    }

    private void buttonAddMovie_Click(Object sender, EventArgs e) {
        FormMovies formMovies = new();
        formMovies.Show();
    }
}

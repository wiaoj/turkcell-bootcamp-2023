using Movies.Application;
using Movies.Application.DTOs.Responses;
using Movies.Data.Data;
using Movies.Data.Repositories;

namespace Movies.WinForms;

public partial class Form1 : Form {
    public Form1() {
        this.InitializeComponent();
    }

    private async void buttonGetMovies_Click(Object sender, EventArgs e) {
        MoviesDbContext moviesDbContext = new();
        EFMovieRepository eFMovieRepository = new(moviesDbContext);
        MovieService movieService = new(eFMovieRepository);

        IEnumerable<MovieListResponse> responses = await movieService.GetAllMovies();
        foreach(MovieListResponse item in responses) {
            this.listBoxMovies.Items.Add($"{item.Name} {item.Duration} dakika");
        }
    }
}

using Movies.Application;
using Movies.Application.DTOs.Responses;
using Movies.Data.Data;
using Movies.Data.Repositories;

namespace Movies.WinForms;

public partial class Form1 : Form {
    public Form1() {
        this.InitializeComponent();
    }

    private async void Form1_Load(Object sender, EventArgs e) {
        MoviesDbContext moviesDbContext = new();
        EFMovieRepository eFMovieRepository = new(moviesDbContext);
        MovieService movieService = new(eFMovieRepository);

        IEnumerable<MovieListResponse> list = await movieService.GetAllMovies();
        dataGridViewMovies.DataSource = list.ToList();
    }

    private void buttonDirector_Click(Object sender, EventArgs e) {
        FormDirectors formDirectors = new();
        formDirectors.Show();
    }
}

using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;
using Movies.Data.Repositories;
using Movies.Entities;

namespace Movies.Application;
public sealed class MovieService : IMovieService {
    private readonly IMovieRepository movieRepository;

    public MovieService(IMovieRepository movieRepository) {
        this.movieRepository = movieRepository;
    }

    public async Task<Int32> CreateNewMovie(CreateNewMovieRequest createNewMovie) {
        Movie movie = new() {
            DirectorId = createNewMovie.DirectorId,
            Duration = createNewMovie.Duration,
            Name = createNewMovie.Name,
            Poster = createNewMovie.Poster,
            PublishDate = createNewMovie.PublishDate,
            Rating = createNewMovie.Rating
        };

        await this.movieRepository.CreateAsync(movie);
        return movie.Id;
    }

    public async Task<IEnumerable<MovieListResponse>> GetAllMovies() {
        IEnumerable<Movie> movies = await this.movieRepository.GetAllAsync();
        IEnumerable<MovieListResponse> response = movies.Select(movie => new MovieListResponse {
            Duration = movie.Duration,
            Name = movie.Name,
            Id = movie.Id,
            Poster = movie.Poster,
            PublishDate = movie.PublishDate,
            Rating = movie.Rating,
        });
        return response;
    }

    public Task UpdateMovie(UpdateMovieRequest updateMovie) {
        throw new NotImplementedException();
    }
}
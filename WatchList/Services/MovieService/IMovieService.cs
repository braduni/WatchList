namespace WatchList.Services.MovieService
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie?> GetMovieById(int id);
        Task<List<Movie>> AddMovie(Movie request);
        Task<List<Movie>?> UpdateMovie(int id, Movie request);
        Task<List<Movie>?> DeleteMovie(int id);
    }
}
namespace WatchList.Services.Repository
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepository { get; }
        IGenreRepository GenreRepository { get; }
        Task SaveChangesAsync();
    }
}
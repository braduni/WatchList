namespace WatchList.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Thriller" },
                new Genre { Id = 2, Name = "Science Fiction" },
                new Genre { Id = 3, Name = "Fantasy" },
                new Genre { Id = 4, Name = "Mystery" },
                new Genre { Id = 5, Name = "Horror" },
                new Genre { Id = 6, Name = "Action" },
                new Genre { Id = 7, Name = "Adventure" },
                new Genre { Id = 8, Name = "Comedy" }   
                );      
        }
    }
}

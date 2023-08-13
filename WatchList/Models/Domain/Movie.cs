namespace WatchList.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
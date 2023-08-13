namespace WatchList.Models.Dtos
{
    public class MovieDtoWithoutGenres
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
    }
}

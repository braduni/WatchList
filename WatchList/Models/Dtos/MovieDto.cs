using System.ComponentModel.DataAnnotations;


namespace WatchList.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Director { get; set; } = string.Empty;

        public List<string> Genres { get; set; } = new List<string>();
    }
}
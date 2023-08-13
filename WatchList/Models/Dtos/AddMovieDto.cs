using System.ComponentModel.DataAnnotations;

namespace WatchList.Models.Dtos
{
    public class AddMovieDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Director { get; set; } = string.Empty;
        [Required]
        public List<string> Genres { get; set; } = new List<string>();
    }
}
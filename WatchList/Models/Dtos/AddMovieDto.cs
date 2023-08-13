using System.ComponentModel.DataAnnotations;

namespace WatchList.Models.Dtos
{
    public class AddMovieDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public List<string> Genres { get; set; }
    }
}
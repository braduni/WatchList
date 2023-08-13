using System.ComponentModel.DataAnnotations;

namespace WatchList.Models.Dtos
{
    public class AddGenreDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
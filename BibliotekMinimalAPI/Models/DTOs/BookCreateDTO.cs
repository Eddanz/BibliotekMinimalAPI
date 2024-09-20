using System.ComponentModel.DataAnnotations;

namespace BibliotekMinimalAPI.Models.DTOs
{
    public class BookCreateDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Author must be between 2 and 100 characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Genre must be between 2 and 100 characters.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(25, ErrorMessage = "Description must be at least 25 characters long.")]
        public string Description { get; set; }

        [Range(1000, 2100, ErrorMessage = "Publishing year must be between 1000 and 2100.")]
        public int PublishingYear { get; set; }

        public bool IsAvailable { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BibliotekMinimalAPI.Models.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int PublishingYear { get; set; }
        public bool IsAvailable { get; set; }
    }
}

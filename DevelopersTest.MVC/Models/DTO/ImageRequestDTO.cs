using System.ComponentModel.DataAnnotations;

namespace DevelopersTest.MVC.Models.DTO
{
    public class ImageRequestDTO
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }
    }
}

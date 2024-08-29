using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevelopersTest.MVC.Models.DTO
{
    public class TeacherInfoDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
    }
}

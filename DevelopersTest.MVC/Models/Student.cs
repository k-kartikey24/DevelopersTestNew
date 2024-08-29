using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevelopersTest.MVC.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public int RollNumber { get; set; }
    }
}

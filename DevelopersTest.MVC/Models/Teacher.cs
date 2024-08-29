using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevelopersTest.MVC.Models
{
    public class Teacher
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
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}

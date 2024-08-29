using System.ComponentModel.DataAnnotations;

namespace DevelopersTest.MVC.Models
{
    public class Subject
    {
            public Guid Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Class { get; set; }
            public ICollection<SubjectLanguage> SubjectLanguages { get; set; }
            public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        
    }
}

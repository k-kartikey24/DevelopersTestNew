namespace DevelopersTest.MVC.Models
{
    public class SubjectLanguage
    {
        public Guid Id { get; set; }
        public string Language { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}

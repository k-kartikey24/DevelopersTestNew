namespace DevelopersTest.MVC.Models.DTO
{
    public class FIlteredStudentDTO
    {
        public List<Student> Students { get; set; }
        public List<string> AvailableClasses { get; set; }
        public string SearchName { get; set; }
        public string FilterClass { get; set; }
    }
}

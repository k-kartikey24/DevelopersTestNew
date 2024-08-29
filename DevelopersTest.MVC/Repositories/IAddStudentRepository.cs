using DevelopersTest.MVC.Models;
using DevelopersTest.MVC.Models.DTO;

namespace DevelopersTest.MVC.Repositories
{
    public interface IAddStudentRepository
    {
        public Task<Student> AddStudentInfo(Student student);
        public Task<FIlteredStudentDTO> GetStudentInfo(string searchName, string filterClass);
    }
}

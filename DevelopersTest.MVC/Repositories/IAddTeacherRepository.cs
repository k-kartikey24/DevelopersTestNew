using DevelopersTest.MVC.Models;

namespace DevelopersTest.MVC.Repositories
{
    public interface IAddTeacherRepository
    {
        public Task<Teacher> AddTeacherInfo(Teacher student);
    }
}

using AutoMapper;
using DevelopersTest.MVC.CustomActionFilter;
using DevelopersTest.MVC.Data;
using DevelopersTest.MVC.Models;
using DevelopersTest.MVC.Models.DTO;
using DevelopersTest.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTest.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentInfoDbContext dbContext;
        private readonly IAddStudentRepository addStudent;
        private readonly IMapper mapper;

        public StudentController(StudentInfoDbContext dbContext, IAddStudentRepository addStudent, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.addStudent = addStudent;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateStudent(StudentInfoDTO student)
        {
            var studentDomain = mapper.Map<Student>(student);

            studentDomain=await addStudent.AddStudentInfo(studentDomain);

            var studentDTO = mapper.Map<StudentInfoDTO>(studentDomain);

            return View("CreateStudent");
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents(string studentName, string filterClass)
        {
            var studentDomain=await addStudent.GetStudentInfo(studentName, filterClass);

            return View(studentDomain);
        }


    }
}

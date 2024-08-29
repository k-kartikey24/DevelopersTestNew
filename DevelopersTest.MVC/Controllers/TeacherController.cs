using AutoMapper;
using DevelopersTest.MVC.CustomActionFilter;
using DevelopersTest.MVC.Data;
using DevelopersTest.MVC.Models;
using DevelopersTest.MVC.Models.DTO;
using DevelopersTest.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersTest.MVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly StudentInfoDbContext dbContext;
        private readonly IAddTeacherRepository addTeacher;
        private readonly IMapper mapper;

        public TeacherController(StudentInfoDbContext dbContext, IAddTeacherRepository addTeacher, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.addTeacher = addTeacher;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddNewTeacher()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddNewTeacher(TeacherInfoDTO teacherInfoDTO)
        {
            var teacherDomain = mapper.Map<Teacher>(teacherInfoDTO);
            teacherDomain=await addTeacher.AddTeacherInfo(teacherDomain);
            var teacherDto=mapper.Map<TeacherInfoDTO>(teacherDomain);
            return View(teacherDto);
        }

    }
}

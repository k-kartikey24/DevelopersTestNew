namespace DevelopersTest.MVC.Mapping;
using AutoMapper;
using DevelopersTest.MVC.Models;
using DevelopersTest.MVC.Models.DTO;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Student,StudentInfoDTO>().ReverseMap();
        CreateMap<Teacher, TeacherInfoDTO>().ReverseMap();

    }
}

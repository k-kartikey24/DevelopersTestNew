using DevelopersTest.MVC.Data;
using DevelopersTest.MVC.Models;
using DevelopersTest.MVC.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTest.MVC.Repositories
{
    public class SQLAddStudentRepository : IAddStudentRepository
    {
        private readonly StudentInfoDbContext dbContext;

        public SQLAddStudentRepository(StudentInfoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Student> AddStudentInfo(Student student)
        {
            if (student.ImageFile != null && student.ImageFile.Length > 0)
            {
                // Generate a unique file name
                var fileName = Path.GetFileNameWithoutExtension(student.ImageFile.FileName);
                var extension = Path.GetExtension(student.ImageFile.FileName);
                var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                var filePath = Path.Combine("Images", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await student.ImageFile.CopyToAsync(stream);
                }

                student.ImageUrl = $"/Images/{uniqueFileName}";
            }

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student; 
        }
        

        public async Task<FIlteredStudentDTO> GetStudentInfo(string searchName, string filterClass)
        {
            var studentInfo = dbContext.Students.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                studentInfo = studentInfo.Where(s => s.Name.Contains(searchName));
            }

            // Apply filter by class
            if (!string.IsNullOrEmpty(filterClass))
            {
                studentInfo = studentInfo.Where(s => s.Class == filterClass);
            }

            var model = new FIlteredStudentDTO
            {
                Students = await studentInfo.ToListAsync(),
                AvailableClasses = await dbContext.Students.Select(s => s.Class).Distinct().ToListAsync()
            };

            return model;
        }
    }
}

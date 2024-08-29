using DevelopersTest.MVC.Data;
using DevelopersTest.MVC.Models;

namespace DevelopersTest.MVC.Repositories
{
    public class SQLAddTeacherRepository : IAddTeacherRepository
    {
        private readonly StudentInfoDbContext dbContext;

        public SQLAddTeacherRepository(StudentInfoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Teacher> AddTeacherInfo(Teacher teacher)
        {
            if (teacher.ImageFile != null && teacher.ImageFile.Length > 0)
            {
                // Generate a unique file name
                var fileName = Path.GetFileNameWithoutExtension(teacher.ImageFile.FileName);
                var extension = Path.GetExtension(teacher.ImageFile.FileName);
                var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                var filePath = Path.Combine("Images", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await teacher.ImageFile.CopyToAsync(stream);
                }

                teacher.ImageUrl = $"/Images/{uniqueFileName}";
            }

            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
            return teacher;
        }
    }
}

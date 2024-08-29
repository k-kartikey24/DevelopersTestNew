using DevelopersTest.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTest.MVC.Data
{
    public class StudentInfoDbContext : DbContext
    {
        public StudentInfoDbContext(DbContextOptions<StudentInfoDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectLanguage> SubjectLanguages { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<StudentImages> StudentImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(ts => ts.TeacherId);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Subject)
                .WithMany(s => s.TeacherSubjects)
                .HasForeignKey(ts => ts.SubjectId);

            // Configuring one-to-many relationship between Subject and SubjectLanguage
            modelBuilder.Entity<SubjectLanguage>()
                .HasOne(sl => sl.Subject)
                .WithMany(s => s.SubjectLanguages)
                .HasForeignKey(sl => sl.SubjectId);
        }
    }
}

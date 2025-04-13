using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Subject)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.SubjectId);

            modelBuilder.Entity<SubjectTeacher>()
                .HasKey(st => new { st.SubjectId, st.TeacherId });

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Subject)
                .WithMany(s => s.SubjectTeachers)
                .HasForeignKey(st => st.SubjectId);

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany(t => t.SubjectTeachers)
                .HasForeignKey(st => st.TeacherId);
        }
    }
}
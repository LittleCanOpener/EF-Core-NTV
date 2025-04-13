using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class SubjectTeacherRepository : ISubjectTeacherRepository
    {
        private readonly SchoolDbContext _context;

        public SubjectTeacherRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubjectTeacher>> GetAllAsync()
        {
            return await _context.SubjectTeachers
                .Include(st => st.Subject)
                .Include(st => st.Teacher)
                .ToListAsync();
        }

        public async Task<SubjectTeacher?> GetByIdAsync(int subjectId, int teacherId)
        {
            return await _context.SubjectTeachers
                .Include(st => st.Subject)
                .Include(st => st.Teacher)
                .FirstOrDefaultAsync(st => st.SubjectId == subjectId && st.TeacherId == teacherId);
        }

        public async Task AddAsync(SubjectTeacher subjectTeacher)
        {
            _context.SubjectTeachers.Add(subjectTeacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int subjectId, int teacherId)
        {
            var subjectTeacher = await GetByIdAsync(subjectId, teacherId);
            if (subjectTeacher != null)
            {
                _context.SubjectTeachers.Remove(subjectTeacher);
                await _context.SaveChangesAsync();
            }
        }
    }
}
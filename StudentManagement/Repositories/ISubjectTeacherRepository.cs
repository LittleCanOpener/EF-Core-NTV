using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public interface ISubjectTeacherRepository
    {
        Task<List<SubjectTeacher>> GetAllAsync();
        Task<SubjectTeacher?> GetByIdAsync(int subjectId, int teacherId);
        Task AddAsync(SubjectTeacher subjectTeacher);
        Task DeleteAsync(int subjectId, int teacherId);
    }
}
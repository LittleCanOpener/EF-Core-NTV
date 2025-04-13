using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();
        Task<Subject?> GetByIdAsync(int id);
        Task AddAsync(Subject subject);
        Task UpdateAsync(Subject subject);
        Task DeleteAsync(int id);
    }
}
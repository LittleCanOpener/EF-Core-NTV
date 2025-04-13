using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public interface IMarkRepository
    {
        Task<List<Mark>> GetAllAsync();
        Task<Mark?> GetByIdAsync(int id);
        Task AddAsync(Mark mark);
        Task UpdateAsync(Mark mark);
        Task DeleteAsync(int id);
    }
}
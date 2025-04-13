using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly SchoolDbContext _context;

        public MarkRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mark>> GetAllAsync()
        {
            return await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .ToListAsync();
        }

        public async Task<Mark?> GetByIdAsync(int id)
        {
            return await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.MarkId == id);
        }

        public async Task AddAsync(Mark mark)
        {
            _context.Marks.Add(mark);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mark mark)
        {
            _context.Marks.Update(mark);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mark = await GetByIdAsync(id);
            if (mark != null)
            {
                _context.Marks.Remove(mark);
                await _context.SaveChangesAsync();
            }
        }
    }
}
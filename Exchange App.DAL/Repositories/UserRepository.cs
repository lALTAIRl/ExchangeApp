using Exchange_App.DAL.Data;
using Exchange_App.DAL.Entities;
using Exchange_App.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_App.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task CreateUserAsync(User user)
        {
            await _context.AddAsync(user);
            await Save();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Set<User>().AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Set<User>().FindAsync(id);
        }
    }
}

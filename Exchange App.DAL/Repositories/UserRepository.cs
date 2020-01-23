using Exchange_App.DAL.Data;
using Exchange_App.DAL.Entities;
using Exchange_App.DAL.Interfaces;
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

        public Task CreateNewsAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNewsAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetNewsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNewsAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}

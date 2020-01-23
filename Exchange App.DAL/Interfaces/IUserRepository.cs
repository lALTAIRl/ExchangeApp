using Exchange_App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_App.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetNewsByIdAsync(int id);

        Task CreateNewsAsync(User user);

        Task UpdateNewsAsync(User user);

        Task DeleteNewsAsync(User user);
    }
}

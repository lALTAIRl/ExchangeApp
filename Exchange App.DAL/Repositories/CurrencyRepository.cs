using Exchange_App.DAL.Data;
using Exchange_App.DAL.Entities;
using Exchange_App.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_App.DAL.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        protected readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public Task CreateNewsAsync(Currency currency)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNewsAsync(Currency currency)
        {
            throw new NotImplementedException();
        }

        public Task<Currency> GetNewsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNewsAsync(Currency currency)
        {
            throw new NotImplementedException();
        }
    }
}

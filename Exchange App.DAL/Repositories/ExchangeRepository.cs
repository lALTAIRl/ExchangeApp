using Exchange_App.DAL.Data;
using Exchange_App.DAL.Entities;
using Exchange_App.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_App.DAL.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        protected readonly ApplicationDbContext _context;

        public ExchangeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public Task CreateNewsAsync(Exchange exchange)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNewsAsync(Exchange exchange)
        {
            throw new NotImplementedException();
        }

        public Task<Exchange> GetNewsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

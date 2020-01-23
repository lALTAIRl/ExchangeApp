using Exchange_App.DAL.Data;
using Exchange_App.DAL.Entities;
using Exchange_App.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateExchangeAsync(Exchange exchange)
        {
            await _context.AddAsync(exchange);
            await Save();
        }

        public async Task<IEnumerable<Exchange>> GetAllExchangesAsync()
        {
            return await _context.Set<Exchange>().AsNoTracking().ToListAsync();
        }

        public async Task<Exchange> GetExchangeByIdAsync(int id)
        {
            return await _context.Set<Exchange>().FindAsync(id);
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task<IQueryable<Exchange>> SelectExchangeAsync(Func<Exchange, bool> predicate)
        {
            return await Task.Run(() =>
            {
                return _context.Set<Exchange>().AsNoTracking().Where(predicate).AsQueryable();
            });
        }
    }
}

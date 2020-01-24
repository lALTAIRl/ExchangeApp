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
    public class CurrencyRepository : ICurrencyRepository
    {
        protected readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCurrencyAsync(Currency currency)
        {
            await _context.AddAsync(currency);
            await Save();
        }

        public async Task DeleteCurrencyAsync(Currency currency)
        {
            _context.Remove(currency);
            await Save();
        }

        public async Task<IEnumerable<Currency>> GetAllCurrencyAsync()
        {
            return await _context.Set<Currency>().AsNoTracking().ToListAsync();
        }

        public async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            return await _context.Set<Currency>().FindAsync(id);
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task UpdateCurrencyAsync(Currency currency)
        {
            await Task.Run(() =>
            {
                _context.Entry(currency).State = EntityState.Modified;
            });
            await Save();
        }

    }
}

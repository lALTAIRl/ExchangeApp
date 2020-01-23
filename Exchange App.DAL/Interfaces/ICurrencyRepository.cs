using Exchange_App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_App.DAL.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllCurrencyAsync();

        Task<Currency> GetCurrencyByIdAsync(int id);

        Task CreateCurrencyAsync(Currency currency);

        Task UpdateCurrencyAsync(Currency currency);

        Task DeleteCurrencyAsync(Currency currency);
    }
}

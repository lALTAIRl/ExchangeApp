using Exchange_App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_App.DAL.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<Currency> GetNewsByIdAsync(int id);

        Task CreateNewsAsync(Currency currency);

        Task UpdateNewsAsync(Currency currency);

        Task DeleteNewsAsync(Currency currency);
    }
}

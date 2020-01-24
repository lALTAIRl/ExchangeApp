using Exchange_App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_App.DAL.Interfaces
{
    public interface IExchangeRepository
    {
        Task<IEnumerable<Exchange>> GetAllExchangesAsync();

        Task<Exchange> GetExchangeByIdAsync(int id);

        Task CreateExchangeAsync(Exchange exchange);

    }
}

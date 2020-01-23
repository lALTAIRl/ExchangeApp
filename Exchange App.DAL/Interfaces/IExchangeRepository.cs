﻿using Exchange_App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_App.DAL.Interfaces
{
    public interface IExchangeRepository
    {
        Task<Exchange> GetNewsByIdAsync(int id);

        Task CreateNewsAsync(Exchange exchange);

        Task DeleteNewsAsync(Exchange exchange);
    }
}

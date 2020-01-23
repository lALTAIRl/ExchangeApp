using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchange_App.DAL.Entities;
using Exchange_App.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exchange_App.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly IExchangeRepository _exchangeRepository;

        public ExchangeController(IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }

        public IActionResult StartTransaction()
        {
            return View();
        }

        public async Task<IActionResult> CreateExchange(Exchange exchange)
        {
            if (exchange.Client.AmountCurrencyUsedToday < 1000)
            {
                exchange.Client.AmountCurrencyUsedToday += exchange.AmountClientCurrency;
                exchange.AmountTargetCurrency = exchange.AmountClientCurrency * exchange.ClientCurrency.SellingPrice / exchange.TargetCurrency.PurchasePrice;
                await _exchangeRepository.CreateExchangeAsync(exchange);
                return RedirectPermanent("~/User/AddUser");
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> ViewAllTransactions()
        {
            return View(await _exchangeRepository.GetAllExchangesAsync());
        }

        public async Task<IActionResult> ViewTransaction(int id)
        {
            return View(await _exchangeRepository.GetExchangeByIdAsync(id));
        }

        public async Task<IActionResult> ViewUserTransactionsStatistic(User user)
        {
            return View(await _exchangeRepository.SelectExchangeAsync(e => e.Client == user));
        }
    }
}
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
        private readonly IUserRepository _userRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public ExchangeController(IExchangeRepository exchangeRepository, IUserRepository userRepository, ICurrencyRepository currencyRepository)
        {
            _exchangeRepository = exchangeRepository;
            _userRepository = userRepository;
            _currencyRepository = currencyRepository;
        }

        public async Task<IActionResult> StartTransaction(int id)
        {
            
            var client = await _userRepository.GetUserByIdAsync(id);
            ViewData["Id"] = client.Id;
            ViewData["Name"] = client.Name;
            ViewData["Surname"] = client.Surname;

            ViewData["Currency"] = await _currencyRepository.GetAllCurrencyAsync();
            return View();
        }

        public async Task<IActionResult> CreateExchange(Exchange exchange)
        {
            var clientCurrency = await _currencyRepository.GetCurrencyByIdAsync(exchange.ClientCurrency.Id);
            var targetCurrency = await _currencyRepository.GetCurrencyByIdAsync(exchange.TargetCurrency.Id);
            var user = await _userRepository.GetUserByIdAsync(exchange.Client.Id);
            exchange.Client = user;
            exchange.ClientCurrency = clientCurrency;
            exchange.TargetCurrency = targetCurrency;
            if ((exchange.Client.AmountCurrencyUsedToday + exchange.AmountClientCurrency) < 1000)
            {
                exchange.Client.AmountCurrencyUsedToday += exchange.AmountClientCurrency;
                exchange.AmountTargetCurrency = exchange.AmountClientCurrency * exchange.ClientCurrency.SellingPrice / exchange.TargetCurrency.PurchasePrice;

                 await _exchangeRepository.CreateExchangeAsync(exchange);
                 return RedirectToAction("ViewTransation", new { id = exchange.Id });
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
    }
}
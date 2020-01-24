using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchange_App.DAL.Entities;
using Exchange_App.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exchange_App.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IActionResult AddCurrency()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                await _currencyRepository.CreateCurrencyAsync(currency);
                return RedirectToAction("CurrencyList");
            }
        }

        public async Task<IActionResult> CurrencyList()
        {
            return View(await _currencyRepository.GetAllCurrencyAsync());
        }

        public async Task<IActionResult> ViewCurrency(int id)
        {
            return View(await _currencyRepository.GetCurrencyByIdAsync(id));
        }

        public async Task<IActionResult> EditCurrency(int id)
        {
            return View(await _currencyRepository.GetCurrencyByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCurrency(Currency currency)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                await _currencyRepository.UpdateCurrencyAsync(currency);
                return RedirectToAction("ViewCurrency", new { id = currency.Id });
            }
        }

        public async Task<IActionResult> DeleteCurrency(Currency currency)
        {
            await _currencyRepository.DeleteCurrencyAsync(currency);
            return RedirectToAction("CurrencyList");
        }
    }
}
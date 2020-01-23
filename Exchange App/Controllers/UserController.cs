using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchange_App.DAL.Entities;
using Exchange_App.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exchange_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userRepository.CreateUserAsync(user);
            return RedirectToAction("~/Exchange/StartTransaction");
        }

        public async Task<IActionResult> UserList()
        {
            return View(await _userRepository.GetAllUsersAsync());
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReWrite.UI.ApiServices;
using ReWrite.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReWrite.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly TokenApiService _service;
        public LoginController(TokenApiService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _service.Login(dto.Username, dto.Password);

            #region Keep Token In Session
            //if (string.IsNullOrEmpty(token))
            //{
            //    return RedirectToAction("Error", "Login");
            //}
            //else
            //{
            //    HttpContext.Session.SetString("myToken", token);
            //    HttpContext.Session.SetString("myUser", dto.Username);
            //    return RedirectToAction("Index", "Home");
            //}
            #endregion

            #region Keep Token In Cookie
            if (string.IsNullOrEmpty(token))
            {
                TempData["loginMessage"] = "Error ocured while logging in!";
                return RedirectToAction("Error", "Home");
            }
            else
            {
                CookieOptions myCookie = new CookieOptions();
                myCookie.Domain = "login";
                myCookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Append("token", token);
                TempData["loginMessage"] = "Logged in successfuly!";
                return RedirectToAction("Index", "Home");
            }
            #endregion
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginDTO dto)
        {
            var sonuc = await _service.Register(dto);
            TempData["registerMessage"]=sonuc;
            return RedirectToAction("Login");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

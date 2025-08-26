using Client.Models; // اگه LoginViewModel اینجاست
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ControlEndPoint.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient("UserService");

            var content = new StringContent(
                JsonSerializer.Serialize(new { email = model.Email, password = model.Password }),
                Encoding.UTF8,
                "application/json"
            );
            Console.WriteLine(content);
            var response = await client.PostAsync("users/login", content);

            // 🔎 دیباگ
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"StatusCode: {response.StatusCode}");
            Console.WriteLine($"Response Body: {responseString}");

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<LoginDto>(
                    responseString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (result != null && result.Success && !string.IsNullOrEmpty(result.Token))
                {
                    Response.Cookies.Append("jwt", result.Token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddHours(1)
                    });
                    // ذخیره در Session
                    HttpContext.Session.SetString("JWToken", result.Token);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Login failed. Please check your email and password.");
            return View(model);
        }
    }

    public class LoginDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}

////using ControlService.ControlDomain.Entities;
////using Endpoint.Control.Models;
//using Client.Dtos;
//using Client.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace ControlEndPoint.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        public AccountController(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }
//        [HttpGet]
//        public IActionResult Login(string returnUrl = null)
//        {
//            ViewData["ReturnUrl"] = returnUrl;
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Login(LoginViewModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);
//            var client = _httpClientFactory.CreateClient("UserService");
//            var response = await client.PostAsJsonAsync("users/login", model);

//            if (!response.IsSuccessStatusCode)
//            {
//                ModelState.AddModelError("", "Login failed!");
//                return View(model);
//            }

//            var result = await response.Content.ReadFromJsonAsync<ResultDto<string>>();

//            Response.Cookies.Append("jwt", result.Data, new CookieOptions
//            {
//                HttpOnly = true,
//                Secure = true,
//                Expires = DateTimeOffset.UtcNow.AddDays(1)
//            });

//            return RedirectToAction("Index", "Home");
//        }
//    }
//}

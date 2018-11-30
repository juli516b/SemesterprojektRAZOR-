using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semesterprojekt.UI.Models;
using Semesterprojekt.UI.Services;

namespace Semesterprojekt.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthApiClient _authApiClient;

        public HomeController(IAuthApiClient authApiClient)
        {
            _authApiClient = authApiClient;
        }
        // GET: Home
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ICollection<TrophyToShowDto> trophies = await PopulateTrophies();

            return View(trophies);
        }

        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _authApiClient.Login(user);

            return View();

        }
        private async Task<ICollection<TrophyToShowDto>> PopulateTrophies()
        {
            HttpClient httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient.BaseAddress = new Uri("https://localhost:44320/api/Trophies");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //GET method
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Trophies");
                if (response.IsSuccessStatusCode)
                {
                    ICollection<TrophyToShowDto> trophies = await response.Content.ReadAsAsync<ICollection<TrophyToShowDto>>();
                    return trophies;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

    }
}
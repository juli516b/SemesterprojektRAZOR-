using Semesterprojekt.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Semesterprojekt.UI.Services
{
    public class AuthApiClient : IAuthApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async void Login(LoginViewModel user)
        {
            using (_httpClient)
            {
                _httpClient.BaseAddress = new Uri("https://localhost:44320/api/users");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //GET method
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + "/login", user);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();

                }
            }
        }
    }
}

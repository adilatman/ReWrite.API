using Newtonsoft.Json;
using ReWrite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ReWrite.UI.ApiServices
{
    public class TokenApiService
    {
        HttpClient _client;
        public TokenApiService(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> Login(string username, string password)
        {
            string token = "";
            StringContent content = new StringContent(JsonConvert.SerializeObject(new LoginDTO()
            {
                Username=username,
                Password=password
            }));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var receivedToken = await _client.PostAsync("api/auth/login", content);
            if (receivedToken.IsSuccessStatusCode)
            {
                token = await receivedToken.Content.ReadAsStringAsync();
            }
            return token;
        }

        public async Task<string> Register(LoginDTO dto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var receivedStatusCode = await _client.PostAsync("api/auth/register", content);
            if (receivedStatusCode.IsSuccessStatusCode)
            {
                return "Registered successfuly!";
            }

            return "Error!";
        }
    }
}

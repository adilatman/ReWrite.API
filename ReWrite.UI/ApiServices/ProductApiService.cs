using Newtonsoft.Json;
using ReWrite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReWrite.UI.ApiServices
{
    public class ProductApiService
    {
        HttpClient _client;
        public ProductApiService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<ProductWithNamesDTO>> GetProducts(string token=null)
        {
            IQueryable<ProductWithNamesDTO> products = null;

            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Remove("Authorization");
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }

            var response = await _client.GetAsync("api/Product");
            if (response.IsSuccessStatusCode)
            {
                products = JsonConvert.DeserializeObject<List<ProductWithNamesDTO>>(await response.Content.ReadAsStringAsync()).AsQueryable();
            }
            return products;
        }
        public async Task<string> AddProduct(ProductDTO dto, string token=null)
        {
            if (string.IsNullOrEmpty(token))
            {
                return "Token yok";
            }
            var product = new StringContent(JsonConvert.SerializeObject(dto));
            product.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.DefaultRequestHeaders.Remove("Authorization");
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            string veri = "Error!";

            var response = await _client.PostAsync("api/addProduct", product);
            
            if (response.IsSuccessStatusCode)
            {
                veri = await response.Content.ReadAsStringAsync();
            }
            return veri;
        }
    }
}

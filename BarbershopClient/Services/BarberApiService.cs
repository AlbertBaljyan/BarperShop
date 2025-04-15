using BarbershopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BarbershopClient.Services
{
    public class BarberApiService
    {
        private readonly HttpClient _httpClient;

        public BarberApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BarberVM>> GetBarbersAsync()
        {
            var response = await _httpClient.GetAsync("api/barbers");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<BarberVM>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }

}

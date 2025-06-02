namespace GYM_PW.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using GYM_PW.Models.Business;

    public class IMachineApiService
    {
        private readonly HttpClient _httpClient;


        public IMachineApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7133/"); // Cambia la URL si tu API está en otro lado
        }

        public async Task<List<Machine>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Machine>>("api/machines");
        }

        public async Task<Machine?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Machine>($"api/machines/{id}");
        }

        public async Task<HttpResponseMessage> CreateAsync(Machine machine)
        {
            return await _httpClient.PostAsJsonAsync("api/machines", machine);
        }

        public async Task<HttpResponseMessage> UpdateAsync(int id, Machine machine)
        {
            return await _httpClient.PutAsJsonAsync($"api/machines/{id}", machine);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/machines/{id}");
        }
    }
}

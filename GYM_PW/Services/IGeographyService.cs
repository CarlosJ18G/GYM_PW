using GYM_PW.Models.Geography;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
namespace GYM_PW.Services
{
    public class IGeographyService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        string baseUrl;
        string username;
        public IGeographyService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            baseUrl = _config.GetValue<string>("ApiGeonamosConfig:Url");
            username = _config.GetValue<string>("ApiGeonamosConfig:Username");
        }

        public async Task<List<string>> GetCountriesAsync()
        {
            var url = $"{baseUrl}/countryInfoJSON?username={username}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonpais = JObject.Parse(responseBody);
            var paises = new List<string>();
            foreach (var pais in jsonpais["geonames"])
            {
                paises.Add(pais["countryName"]?.ToString());
            }
            return paises;
        }

        public async Task<List<string>> GetStatesByCountryAsync(string countryCode)
        {
            var url = $"{baseUrl}/searchJSON?country={countryCode}&featureClass=P&maxRows=1000&username={username}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseBody);
            var cities = new List<string>();
            foreach (var state in json["geonames"])
            {
                cities.Add(state["adminName1"]?.ToString());
            }
            return cities;
        }


        public async Task<List<string>> GetCitiesByStateAsync(string countryCode)
        {
            var url = $"{baseUrl}/searchJSON?country={countryCode}&featureClass=P&maxRows=1000&username={username}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(responseBody);
            var cities = new List<string>();
            foreach (var city in json["geonames"])
            {
                cities.Add(city["name"]?.ToString());
            }
            return cities;
        }

        public async Task<JsonNode> GetJson (string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var json = JsonObject.Parse(responseBody);
            return (JsonObject?)json;
        }
    }
}

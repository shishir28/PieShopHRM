using PieShopHRM.Shared;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using IdentityModel.Client;

namespace PieShopHRM.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenManager _tokenManager;

        public CountryDataService(HttpClient httpClient, TokenManager tokenManager)
        {
            _httpClient = httpClient;
            _tokenManager = tokenManager;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            _httpClient.SetBearerToken(await _tokenManager.RetrieveAccessTokenAsync());
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await _httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            _httpClient.SetBearerToken(await _tokenManager.RetrieveAccessTokenAsync());
            return await JsonSerializer.DeserializeAsync<Country>
                (await _httpClient.GetStreamAsync($"api/country{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}

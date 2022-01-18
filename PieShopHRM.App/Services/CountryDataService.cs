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
        private readonly TokenProvider _tokenProvider;


        public CountryDataService(HttpClient httpClient, TokenProvider tokenProvider)
        {
            _httpClient = httpClient;
            _tokenProvider = tokenProvider;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            _httpClient.SetBearerToken(_tokenProvider.AccessToken);
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await _httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            _httpClient.SetBearerToken(_tokenProvider.AccessToken);
            return await JsonSerializer.DeserializeAsync<Country>
                (await _httpClient.GetStreamAsync($"api/country{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}

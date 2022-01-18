using PieShopHRM.Shared;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using IdentityModel.Client;

namespace PieShopHRM.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {

        private readonly HttpClient _httpClient;
        private readonly TokenProvider _tokenProvider;


        public JobCategoryDataService(HttpClient httpClient, TokenProvider tokenProvider)
        {
            _httpClient = httpClient;
            _tokenProvider = tokenProvider;
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            _httpClient.SetBearerToken(_tokenProvider.AccessToken);
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
                (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
        {
            _httpClient.SetBearerToken(_tokenProvider.AccessToken);
            return await JsonSerializer.DeserializeAsync<JobCategory>
                (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}

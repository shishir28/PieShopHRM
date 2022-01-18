using IdentityModel.Client;
using PieShopHRM.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PieShopHRM.App.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenProvider _tokenProvider;


        public EmployeeDataService(HttpClient httpClient, TokenProvider tokenProvider)
        {
            _httpClient = httpClient;
            _tokenProvider = tokenProvider;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            _httpClient.SetBearerToken(_tokenProvider.AccessToken);

            var response = await _httpClient.PostAsync("api/employee", employeeJson);

            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());

            return null;
        }


        public async Task UpdateEmployee(Employee employee)
        {

            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
            _httpClient.SetBearerToken(_tokenProvider.AccessToken);

            await _httpClient.PutAsync("api/employee", employeeJson);

        }


        public async Task DeleteEmployee(int employeeId)
        {
            _httpClient.SetBearerToken(_tokenProvider.AccessToken);
            await _httpClient.DeleteAsync($"api/employee/{employeeId}");

        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            _httpClient.SetBearerToken(_tokenProvider.AccessToken);
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                    (await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            _httpClient.SetBearerToken(_tokenProvider.AccessToken);
            return await JsonSerializer.DeserializeAsync<Employee>
                (await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}

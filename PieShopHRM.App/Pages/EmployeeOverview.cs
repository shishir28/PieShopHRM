using Microsoft.AspNetCore.Components;
using PieShopHRM.App.Services;
using PieShopHRM.Shared;
namespace PieShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Countries = await CountryDataService.GetAllCountries();
            JobCategories = await JobCategoryDataService.GetAllJobCategories();
            Employees = await EmployeeDataService.GetAllEmployees();
            await base.OnInitializedAsync();
        }

        public IEnumerable<Employee> Employees { get; set; }

        private IEnumerable<Country> Countries { get; set; }

        private IEnumerable<JobCategory> JobCategories { get; set; }

    }
}

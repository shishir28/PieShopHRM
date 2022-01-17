using Microsoft.AspNetCore.Components;
using PieShopHRM.App.Services;
using PieShopHRM.Shared;

namespace PieShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
       

        protected  override async Task OnInitializedAsync()
        {
            Employees = await EmployeeDataService.GetAllEmployees();
            Employee = Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));
            await  base.OnInitializedAsync();
        }

        public IEnumerable<Employee> Employees { get; set; }

    }
}

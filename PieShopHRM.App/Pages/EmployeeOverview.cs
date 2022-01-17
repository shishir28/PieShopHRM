using Microsoft.AspNetCore.Components;
using PieShopHRM.App.Components;
using PieShopHRM.App.Services;
using PieShopHRM.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected AddEmployeeDialog AddEmployeeDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeDataService.GetAllEmployees();
            await base.OnInitializedAsync();
        }

        public IEnumerable<Employee> Employees { get; set; }

        protected void QuickAddEmployee() =>  AddEmployeeDialog.Show();

        public async void AddEmployeeDialog_OnDialogClose()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            StateHasChanged();
        }

    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
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

        [CascadingParameter]
        Task<AuthenticationState> authenticationTaskState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeDataService.GetAllEmployees();
            await base.OnInitializedAsync();
        }

        public IEnumerable<Employee> Employees { get; set; }

        protected async Task QuickAddEmployee()
        {
            var authenticationState = await authenticationTaskState; 

            if(authenticationState.User.Identity.Name=="Shishir")
            {
                AddEmployeeDialog.Show();
            }
            
        }

        public async void AddEmployeeDialog_OnDialogClose()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            StateHasChanged();
        }

    }
}

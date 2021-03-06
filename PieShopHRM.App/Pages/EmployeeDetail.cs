using Microsoft.AspNetCore.Components;
using PieShopHRM.App.Services;
using PieShopHRM.ComponentsLibrary.Map;
using PieShopHRM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
       

        protected  override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            MapMarkers = new List<Marker>
            {
                new Marker{ Description = $"{Employee.FirstName} {Employee.LastName}", ShowPopup = false, X = Employee.Latitude, Y= Employee.Longitude }
            };
            await  base.OnInitializedAsync();
        }

        public IEnumerable<Employee> Employees { get; set; }

    }
}

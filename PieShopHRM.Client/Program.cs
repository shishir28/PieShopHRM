using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PieShopHRM.App;
using PieShopHRM.App.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));
builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));


await builder.Build().RunAsync();

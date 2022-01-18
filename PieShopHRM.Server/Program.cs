using Microsoft.AspNetCore.Authentication.Cookies;
using PieShopHRM.App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));
builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/";
    });

builder.Services.AddScoped<TokenProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

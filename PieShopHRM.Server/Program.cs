using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PieShopHRM.App.Services;
using PieShopHRM.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));
builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(c => c.BaseAddress = new Uri("https://localhost:5003/"));


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

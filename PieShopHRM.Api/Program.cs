using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using PieShopHRM.Api;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var requireAuthenticationUserPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

builder.Services.AddControllers(config =>
{
    config.Filters.Add(new AuthorizeFilter(requireAuthenticationUserPolicy));
});

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5000";
        options.TokenValidationParameters.ValidateAudience = false;
    }); // we cant use AddIdentityServerAuthentication because of audience validation

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Services.MigrateDB();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("Open");

app.MapControllers();

app.Run();

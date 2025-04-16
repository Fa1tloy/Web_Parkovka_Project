
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web_Parkovka_Project.AutoMapper;
using Web_Parkovka_Project.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParckingBD")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

// Добавьте эту строку:
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
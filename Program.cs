
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web_Parkovka_Project.AutoMapper;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParckingBD")));

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseHttpsRedirection(); // 1. Перенаправление на HTTPS
app.UseStaticFiles();      // 2. Обслуживание статических файлов (CSS, JS, изображения)

app.UseRouting();          // 3. Маршрутизация

app.UseAuthentication();   // 4. Аутентификация (ДО авторизации!)
app.UseAuthorization();    // 5. Авторизация

app.MapRazorPages();       // 6. Маппинг Razor Pages

app.Run();

// Добавьте эту строку:
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
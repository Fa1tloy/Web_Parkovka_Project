
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Parkovka_Project.AutoMapper;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.Hubs;
using Web_Parkovka_Project.Migrations;
using Web_Parkovka_Project.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParckingBD")));
builder.Services.AddSignalR();

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

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.MapHub<ChatHub>("/chatHub");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();

 void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication("YourCookieAuthScheme")
        .AddCookie("YourCookieAuthScheme", options =>
        {
            options.LoginPath = "/Account/Login"; // путь к странице входа
            options.LogoutPath = "/Account/Logout"; // путь к странице выхода
            options.AccessDeniedPath = "/Account/AccessDenied"; // путь к странице доступа
        });
    services.AddControllersWithViews();
}
 void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    
    app.UseRouting();
    app.UseAuthentication(); // добавьте эту строку
    app.UseAuthorization(); // добавьте эту строку
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}

[Authorize]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
}

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> LoginAsync(Login model)
    {
        if (ModelState.IsValid)
        {
            // ¬аш код дл€ проверки учетных данных пользовател€
            // ≈сли учетные данные правильные:
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.User),
                // другие claims
            };
            var claimsIdentity = new ClaimsIdentity(claims, "YourCookieAuthScheme");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("YourCookieAuthScheme", claimsPrincipal);
            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("YourCookieAuthScheme");
        return RedirectToAction("Index", "Home");
    }
}

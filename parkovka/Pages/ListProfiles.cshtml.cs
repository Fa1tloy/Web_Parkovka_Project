using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.DTOs.User;

namespace Web_Parkovka_Project.Pages.Account
{
    [Authorize]
    public class ProfilesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProfilesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserResponseDTO> Users { get; set; } = new List<UserResponseDTO>();

        public async Task OnGetAsync()
        {
            Users = await _context.Users
                .Include(u => u.Vehicles)
                .Select(u => new UserResponseDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Patronymic = u.Patronymic,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Vehicles = u.Vehicles.Select(v => new VehicleDTO
                    {
                        Id = v.Id,
                        Make = v.Make,
                        Model = v.Model,
                        LicensePlate = v.LicensePlate
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.DTOs.User;
using Web_Parkovka_Project.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Web_Parkovka_Project.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public ProfileModel(
            UserManager<User> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public UserResponseDTO CurrentUser { get; set; }

        [BindProperty]
        public UpdateProfileDTO Input { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            CurrentUser = new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            Input = new UpdateProfileDTO
            {
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            // ????????? ????????? ???????????? ????????
            CurrentUser.Vehicles = await _context.Vehicles
                .Where(v => v.OwnerId == user.Id)
                .Select(v => new VehicleDTO
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    LicensePlate = v.LicensePlate
                })
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadCurrentUserData();
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = Input.Name;
            user.Surname = Input.Surname;
            user.Patronymic = Input.Patronymic;
            user.PhoneNumber = Input.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                await LoadCurrentUserData();
                return Page();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddVehicleAsync(string make, string model, string licensePlate)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var vehicle = new Vehicle
            {
                Make = make,
                Model = model,
                LicensePlate = licensePlate,
                OwnerId = user.Id
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        private async Task LoadCurrentUserData()
        {
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Vehicles = await _context.Vehicles
                    .Where(v => v.OwnerId == user.Id)
                    .Select(v => new VehicleDTO
                    {
                        Id = v.Id,
                        Make = v.Make,
                        Model = v.Model,
                        LicensePlate = v.LicensePlate
                    })
                    .ToListAsync()
            };
        }
    }
}

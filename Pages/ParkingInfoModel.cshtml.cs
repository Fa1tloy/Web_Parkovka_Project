using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.Models;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Pages
{
    public class ParkingInfoModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ParkingInfoModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParkingInfoViewModel ViewModel { get; set; }

        public void OnGet()
        {
            ViewModel = new ParkingInfoViewModel();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 1. Создаем/находим пользователя
            var user = _context.Users.FirstOrDefault(u => u.Email == ViewModel.UserEmail);
            if (user == null)
            {
                user = new User
                {
                    Name = ViewModel.UserName,
                    Surname = ViewModel.UserSurname,
                    Patronymic = ViewModel.UserPatronymic,
                    Email = ViewModel.UserEmail,
                    PhoneNumber = ViewModel.UserPhone,
                    UserName = ViewModel.UserEmail
                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            // 2. Создаем транспортное средство
            var vehicle = new Vehicle
            {
                Make = ViewModel.VehicleMake,
                Model = ViewModel.VehicleModel,
                LicensePlate = ViewModel.VehicleLicensePlate,
                OwnerId = user.Id
            };
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            // 3. Создаем парковочное место
            var parkingSpot = new ParkingSpot
            {
                Number = ViewModel.ParkingSpotNumber,
                IsOccupied = true,
                VehicleId = vehicle.Id
            };
            _context.ParkingSpots.Add(parkingSpot);
            _context.SaveChanges();

            return RedirectToPage("ParkingInfoSuccess");
        }
    }
}
/// Pages/ParkingForm.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Model;
using Web_Parkovka_Project.Data;

namespace Web_Parkovka_Project.Pages
{
    public class ParkingFormModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ParkingFormModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParkingSpot ParkingSpot { get; set; }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
            // Инициализация с обязательными полями
            ParkingSpot = new ParkingSpot
            {
                Number = 1, // Значение по умолчанию
                IsOccupied = true
            };

            Vehicle = new Vehicle
            {
                Make = "", // Пустая строка вместо null
                Model = "",
                LicensePlate = ""
            };

            User = new User
            {
                Name = "",
                Surname = "",
                Email = "",
                PhoneNumber = ""
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Сохраняем пользователя
                    _context.Users.Add(User);
                    await _context.SaveChangesAsync();

                    // Сохраняем транспортное средство
                    Vehicle.OwnerId = User.Id;
                    _context.Vehicles.Add(Vehicle);
                    await _context.SaveChangesAsync();

                    // Сохраняем парковочное место
                    ParkingSpot.VehicleId = Vehicle.Id;
                    _context.ParkingSpots.Add(ParkingSpot);
                    await _context.SaveChangesAsync();

                    // Создаем резервацию
                    var reservation = new Reservation
                    {
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddHours(1), // Пример: 1 час парковки
                        SpotId = ParkingSpot.Id
                    };
                    _context.Reservations.Add(reservation);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return RedirectToPage("/Success");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError(string.Empty, "Ошибка при сохранении данных: " + ex.Message);
                    return Page();
                }
            }
        }
    }
}
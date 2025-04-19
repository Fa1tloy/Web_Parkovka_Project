using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Data;
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
        public Vehicle Vehicle { get; set; }

        [BindProperty]
        public ParkingSpot ParkingSpot { get; set; }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
            // Initialize empty objects for new entry
            Vehicle = new Vehicle() { LicensePlate = "" , Make = "" , Model ="" };
            ParkingSpot = new ParkingSpot() { Number = 0 };
            User = new User() { Name = "", Surname = "", Patronymic = "", Email = "", PhoneNumber = "", Vehicles = new List<Vehicle>() };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if user with this email already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == User.Email);
            if (existingUser != null)
            {
                // Use existing user
                User = existingUser;
            }
            else
            {
                // Add new user
                _context.Users.Add(User);
                _context.SaveChanges();
            }

            // Set vehicle owner
            Vehicle.OwnerId = User.Id;
            _context.Vehicles.Add(Vehicle);
            _context.SaveChanges();

            // Set parking spot
            ParkingSpot.IsOccupied = true;
            ParkingSpot.VehicleId = Vehicle.Id;
            _context.ParkingSpots.Add(ParkingSpot);
            _context.SaveChanges();

            return RedirectToPage("ParkingInfoSuccessModel");
        }
    }
}
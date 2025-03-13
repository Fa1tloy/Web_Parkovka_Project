using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.Model;
using System;

namespace Web_Parkovka_Project.Pages
{
    public class ParkingInformationModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ParkingInformationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cars Car { get; set; }

        public void OnGet(int id)
        {
            if (id > 0)
            {
                Car = _context.Cars.FirstOrDefault(b => b.Id == id);
            }
            else
            {
                Car = new Cars() { Id = 0 , Number = "" , Colour = "", Model = "", Owner = new Owner { Email = "", Id = 0 , Name = "", Phone = ""}, OwnerId = 0};
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Car.Id == 0)
            {
                _context.Cars.Add(Car);
            }
            else
            {
                _context.Cars.Update(Car);
            }
            _context.SaveChanges();
            return RedirectToPage("Cars");
        }
    }
}
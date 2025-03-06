using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.Model;
using System;


namespace StudentLibrary.Pages
{
    public class CarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CarModel(ApplicationDbContext context)
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
                Car = new Cars() { Id = 0 , Number = "" , Model = "", Colour = "", OwnerId = 0 ,Owner   };
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Cars.Id == 0)
            {
                _context.Books.Add(Book);
            }
            else
            {
                _context.Books.Update(Book);
            }
            _context.SaveChanges();
            return RedirectToPage("Books");
        }
    }
}
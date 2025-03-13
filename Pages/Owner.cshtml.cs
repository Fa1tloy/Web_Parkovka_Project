using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Pages
{
    public class OwnerModel : PageModel
    {
      private readonly ApplicationDbContext _context;

      public OwnerModel(ApplicationDbContext context)
      {
            _context = context;
      }
        [BindProperty]
        public Owner Owner { get; set; }
        public void OnGet(int id)
        {
            if (id > 0)
            {
                Owner = _context.Owners.FirstOrDefault(o => o.Id == id);
            }
            else
            {
                Owner = new Owner() { Name = "", Email = "", Phone = ""};
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Owner.Id == 0)
            {
                _context.Owners.Add(Owner);
            }
            else
            {
                _context.Owners.Update(Owner);
            }
            _context.SaveChanges();
            return RedirectToPage("Owners");
        }
    }
}

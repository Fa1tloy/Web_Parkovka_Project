using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.Hubs;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Pages
{
    public class StudentModel(ApplicationDbContext context, IHubContext<ChatHub> hubContext) : PageModel
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IHubContext<ChatHub> _hubContext = hubContext;

        [BindProperty]
        public User User { get; set; }
        public void OnGet(int id)
        {
            if (id > 0)
            {
                User = _context.Users.FirstOrDefault(b => b.Id == id);
            }
            else
            {
                User = new User() { Name = "", Surname = "", Patronymic = "", Email = "", PhoneNumber = "", Vehicles = new List<Vehicle>() };
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (User.Id == 0)
            {
                _context.Users.Add(User);
            }
            else
            {
                _context.Users.Update(User);
            }
            _context.SaveChanges();
            return RedirectToPage("Users");
        }
    }
}

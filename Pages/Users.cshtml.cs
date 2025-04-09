using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Data;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Pages
{
    public class UsersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UsersModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<User> Users { get; set; }
        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}

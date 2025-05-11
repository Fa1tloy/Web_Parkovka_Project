using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Pages
{

    [Authorize]
    public class ChatModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        public string UserName { get; set; } = "Гость";

        public ChatModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGet()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                var user = await _userManager.GetUserAsync(User);
                UserName = user?.Name ?? "Гость";
            }
        }
    }
}

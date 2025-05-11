using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly List<string> ConnectedUsers = new List<string>();
        private readonly UserManager<User> _userManager;

        public ChatHub(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task OnConnectedAsync()
        {
            var user = await _userManager.GetUserAsync(Context.User);
            var userName = user?.Name ?? "Аноним";

            if (!ConnectedUsers.Contains(userName))
            {
                ConnectedUsers.Add(userName);
                await UpdateUserList();
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = await _userManager.GetUserAsync(Context.User);
            var userName = user?.Name ?? "Аноним";

            if (ConnectedUsers.Contains(userName))
            {
                ConnectedUsers.Remove(userName);
                await UpdateUserList();
            }
            await base.OnDisconnectedAsync(exception);
        }

        private async Task UpdateUserList()
        {
            await Clients.All.SendAsync("UserListUpdate", ConnectedUsers);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Receive", user, message);
        }
    }
}

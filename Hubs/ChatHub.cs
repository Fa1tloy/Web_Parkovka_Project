using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Receive(string user, string message)
        {
            await Clients.All.SendAsync("Receive", user, message);
        }
        public async Task SendMessage(string message, string user)
        {
            await Clients.All.SendAsync("Receive", message, user);
        }
        public async Task UpStudent()
        {
            await Clients.All.SendAsync("UpStudent");
        }
    }
}

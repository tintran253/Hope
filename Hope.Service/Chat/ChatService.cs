using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace Hope.WebApi.Services
{
    public class ChatService : Hub
    {
        public Task SendMessage(string user, string message)
        {
            string timestamp = DateTime.Now.ToShortTimeString();
            return Clients.All.SendAsync("ReceiveMessage", timestamp, user, message);
        }
    }
}

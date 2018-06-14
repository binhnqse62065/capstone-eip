using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace CapstoneProjectClient
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public ChatHub() : this(GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients) { }

        public ChatHub(IHubConnectionContext<dynamic> clients)
        {
        }
    }
}
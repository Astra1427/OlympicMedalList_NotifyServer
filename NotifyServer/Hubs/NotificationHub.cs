using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyServer.Hubs
{
    public class NotificationHub : Hub
    {
        
        /// <summary>
        /// Notification message to all client
        /// </summary>
        /// <param name="type">1-news</param>
        /// <param name="message"></param>
        public void NotificationMessage(int type,string message)
        {
            Clients.All.NotificationMessageToClient(type,message);
        }
    }
}
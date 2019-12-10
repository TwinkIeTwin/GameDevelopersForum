using GameDevelopersForum.Controllers;
using GameDevelopersForum.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Hubs
{
	public class ChatHub : Hub
	{
		ForumContext db;
		public ChatHub(ForumContext db) : base()
		{
			this.db = db;
		}

		public async Task SendMessage(string user, string message = "")
		{
			Message mess = new Message { User = db.Users.FirstOrDefault(u => u.Login == user), Text = message, Time = DateTime.Now };
			await db.Messages.AddAsync(mess);
			db.SaveChanges();

			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}

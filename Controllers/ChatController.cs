using GameDevelopersForum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Controllers
{
	public class ChatController : Controller
	{
		private readonly ForumContext db;
		public ChatController(ForumContext db)
		{

			this.db = db;
		}
		
		public IActionResult Chat()
		{
			
			List<Message> messages = db.Messages.Where(u => u.TopicId == null).OrderByDescending(x => x.Time).Take(10).ToList();
			List<string> Users = new List<string>();
			foreach (var message in messages)
			{
				if (message.UserId != null) {
					Users.Add(db.Users.Find(message.UserId).Login);
				}
				else
				{
					Users.Add("Anonymus");
				}
			}
			ViewBag.Users = Users;
			
			return View(messages);
		}


	}
}

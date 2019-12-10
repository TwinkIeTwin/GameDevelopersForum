using GameDevelopersForum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Controllers
{
	public class ForumController : Controller
	{
		private readonly ForumContext db;
		public ForumController(ForumContext db)
		{

			this.db = db;
		}
		[Authorize]
		public IActionResult Create()
		{
			Topic topic = new Topic
			{
				CreationDate = DateTime.Now,
				Creator = db.Users.FirstOrDefault(u => u.Login == User.Identity.Name),
			};
			db.Topics.Add(topic);
			db.SaveChanges();
			return RedirectToAction("TopicEdit", new RouteValueDictionary(
	new { controller = "DataBases", action = "TopicEdit", Id = topic.Id }));

		}

		public IActionResult List()
		{
			return View(db.Topics.Take(countTopicsToShow).ToList());
		}

		[HttpPost]
		public IActionResult Send(int id, string text)
		{

			User user = db.Users.First(u => u.Login == User.Identity.Name);
			Topic topic = db.Topics.Find(id);
			Message message = new Message { Text = text, User = user, Time = DateTime.Now, Topic = topic };
			db.Messages.Add(message);
			db.SaveChanges();
			return Redirect("Show/" + id);
		}

		public IActionResult Show(int id)
		{
			Topic topic = db.Topics.Find(id);
			ViewBag.User = db.Users.Find(topic.CreatorId);
			IQueryable<Message> messages = db.Messages.Where(u => u.Topic.Id == id);
			ViewBag.Messages = messages;
			return View(topic);
		}
		//[HttpGet("{pageNumber}")]
		[HttpGet]
		public async Task<IActionResult> TopicList(int pageNumber = 0)
		{
			if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
			{
				return PartialView("~/Views/Forum/ListGet.cshtml", await getTopicList(pageNumber));
			}
			else return View(await getTopicList(pageNumber));
		}

		const int countTopicsToShow = 5;
	
		private async Task<List<Topic>> getTopicList(int pageNumber)
		{
			var topics = db.Topics;

			return topics.Skip(pageNumber * countTopicsToShow).Take(countTopicsToShow).ToList();
		}


	}
}

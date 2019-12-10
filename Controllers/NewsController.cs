using GameDevelopersForum.Models;
using GameDevelopersForum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Controllers
{
	public class NewsController : Controller
	{
		private readonly ForumContext db;
		public NewsController(ForumContext db)
		{
			this.db = db;
		}
		
		public IActionResult List()
		{
			List <News> news = db.News.OrderByDescending(x => x.PublishingDate).ToList<News>();
			return View(news);
		}
		[Authorize(Roles = "admin, moderator")]
		public IActionResult Create()
		{
			News news = new News { PublishingDate = DateTime.Now};
			db.News.Add(news);
			db.SaveChanges();
			return RedirectToAction("NewsEdit", new RouteValueDictionary(
	new { controller = "DataBases", action = "NewsEdit", Id = news.Id }));
		
		}
		public IActionResult Show(int id)
		{
			return View(db.News.Find(id));
		}
	}
}

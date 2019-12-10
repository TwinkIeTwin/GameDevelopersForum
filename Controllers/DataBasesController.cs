using GameDevelopersForum.Models;
using GameDevelopersForum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Controllers
{
	public class DataBasesController : Controller
	{
		private readonly ForumContext db;
		//UserManager<User> UserManager;
		public DataBasesController(ForumContext db )
		{
			this.db = db;
			//this.UserManager = userManager;
		}
		[Authorize(Roles = "admin, moderator")]
		public IActionResult Index()
		{
			return View();
		}
		[Authorize(Roles = "admin, moderator")]
		public IActionResult News()
		{
			return View(db.News.ToList());
		}
		[Authorize(Roles = "admin")]
		public IActionResult Users()
		{
			return View(db.Users.ToList());
		}
		[Authorize(Roles = "admin, moderator")]
		public IActionResult Topics()
		{
			return View(db.Topics.ToList());
		}
		[HttpGet]

		public IActionResult TopicEdit(int Id)
		{
			Topic topic = db.Topics.Find(Id);
			if (User.IsInRole("admin") || User.IsInRole("moderator") || (User.Identity.IsAuthenticated && topic.Name == null))
			{
				ViewBag.CurrentTopic = topic;
				return View();
			}
			else
			{
				return View(Content("Access denied"));
			}
		}

		[Authorize(Roles = "admin, moderator")]
		public IActionResult TopicDelete(int id)
		{
			db.Topics.Remove(db.Topics.Find(id));
			db.SaveChanges();
			return RedirectToAction("Topics", "DataBases");
		}

		[Authorize(Roles = "admin, moderator")]
		public IActionResult NewsDelete(int id)
		{
			db.News.Remove(db.News.Find(id));
			db.SaveChanges();
			return RedirectToAction("News", "DataBases");
		}

		[Authorize(Roles = "admin")]
		public IActionResult UserDelete(int id)
		{
			db.Users.Remove(db.Users.Find(id));
			db.SaveChanges();
			return RedirectToAction("Users", "DataBases");
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult TopicEdit(TopicEditModel model, int id)
		{
			Topic topic = db.Topics.Find(id);
			
			if (ModelState.IsValid)
			{
				if (model.Description != null)
				{
					topic.Description = model.Description;
				}
				if (model.Name != null)
				{
					topic.Name = model.Name;
				}
				db.SaveChanges();
				return RedirectToAction("List", "Forum");
			}
			ViewBag.CurrentTopic = topic;
			return View();
		}

		[HttpGet]
		[Authorize(Roles = "admin, moderator")]
		public IActionResult NewsEdit(int Id)
		{
			News news = db.News.Find(Id);
			ViewBag.CurrentNews = news;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult NewsEdit(NewsEditModel model, int id)
		{
			News news = db.News.Find(id);

			if (ModelState.IsValid)
			{
				if (model.Description != null)
				{
					news.Description = model.Description;
				}
				if (model.Info != null)
				{
					news.Description = model.Description;
				}
				if (model.Name != null)
				{
					news.Name = model.Name;
				}
				db.SaveChanges();
				return RedirectToAction("News", "DataBases");
			}
			ViewBag.CurrentTopic = news;
			return View();
		}

		public IActionResult UserAPI()
		{
			return View();
		}

		[HttpGet]
		
		//[Route("userEdit/{id:int:min(1)}")]
		[Route("userEdit/{id:correctId}")]
		[Authorize(Roles = "admin")]
		public IActionResult UserEdit(int Id)
		{
			User user = db.Users.Find(Id);
			ViewBag.CurrentUser = user;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult UserEdit(UserEditModel model, int id)
		{
			User user = db.Users.Find(id);

			if (ModelState.IsValid)
			{
				if (model.Login != null)
				{
					user.Login = model.Login;
				}
				if (model.Email != null)
				{
					user.Email = model.Email;
				}
				if (model.About != null)
				{
					user.About = model.About;
				}
				if (model.Password != null)
				{
					user.Password = model.Password;
				}

				if (model.RoleId != null)
				{
					user.RoleId = model.RoleId;
				}
				//await UserManager.UpdateSecurityStampAsync(user);
				db.SaveChanges();
				return RedirectToAction("Users", "DataBases");
			}
			ViewBag.CurrentUser = user;
			return View();
		}

		//[HttpPost]
		//public async Task<IActionResult> Edit(string userId, List<string> roles)
		//{
		//	// получаем пользователя
		//	User user = await _userManager.FindByIdAsync(userId);
		//	if (user != null)
		//	{
		//		// получем список ролей пользователя
		//		var userRoles = await _userManager.GetRolesAsync(user);
		//		// получаем все роли
		//		var allRoles = _roleManager.Roles.ToList();
		//		// получаем список ролей, которые были добавлены
		//		var addedRoles = roles.Except(userRoles);
		//		// получаем роли, которые были удалены
		//		var removedRoles = userRoles.Except(roles);

		//		await _userManager.AddToRolesAsync(user, addedRoles);
		//		await _userManager.RemoveFromRolesAsync(user, removedRoles);
		//		await _userManager.UpdateSecurityStampAsync(user);
		//		return RedirectToAction("Index");
		//	}

		//	return NotFound();
		//}


	}
}

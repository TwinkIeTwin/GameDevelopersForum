using GameDevelopersForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.ViewComponents
{
	public class UsersListViewComponent : ViewComponent
	{
		private ForumContext db;
		public UsersListViewComponent(ForumContext db)
		{
			this.db = db;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await db.Users.ToListAsync());
		}
	}
}

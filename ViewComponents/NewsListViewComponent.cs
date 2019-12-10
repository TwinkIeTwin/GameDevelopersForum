using GameDevelopersForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.ViewComponents
{
	public class NewsListViewComponent : ViewComponent
	{
		private ForumContext db;
		public NewsListViewComponent(ForumContext db)
		{
			this.db = db;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await db.News.ToListAsync());
		}
	}
}

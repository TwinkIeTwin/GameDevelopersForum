using GameDevelopersForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GameDevelopersForum.wwwroot.ViewComponents
{
	public class TopicsListViewComponent : ViewComponent
	{
		private ForumContext db;
		public TopicsListViewComponent(ForumContext db)
		{
			this.db = db;
		}

		public async Task <IViewComponentResult> InvokeAsync()
		{
			return View(await db.Topics.ToListAsync());
		}
	}
}

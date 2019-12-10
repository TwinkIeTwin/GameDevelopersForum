using GameDevelopersForum.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Controllers
{
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		ForumContext db;

		public UsersController(ForumContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public IEnumerable<User> Get()
		//public IEnumerable<ObjectResult> Get()
		{
		
			return db.Users.ToList();
		}


		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			User user = db.Users.FirstOrDefault(x => x.Id == id);
			if (user == null)
				return NotFound();
			return new ObjectResult(user);
		}

		// add new user
		[HttpPost]
		public IActionResult Post([FromBody]User user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			db.Users.Add(user);
			db.SaveChanges();
			return Ok(user);
		}

		// edit
		[HttpPut]
		public IActionResult Put([FromBody]User user)
		{
			if (user == null)
			{
				return BadRequest();
			}
			if (!db.Users.Any(x => x.Id == user.Id))
			{
				return NotFound();
			}

			db.Update(user);
			db.SaveChanges();
			return Ok(user);
		}


		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			User user = db.Users.FirstOrDefault(x => x.Id == id);
			if (user == null)
			{
				return NotFound();
			}
			db.Users.Remove(user);
			db.SaveChanges();
			return Ok(user);
		}

	}
}

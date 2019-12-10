using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Models
{
	public class ForumContext : DbContext
	{
		//public DbSet<User> Users { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Message> Messages{get; set;}

		public ForumContext(DbContextOptions<ForumContext> options)
	: base(options)
		{

			//Database.EnsureDeleted();
			//Database.EnsureCreated();
			//SampleData.Initialize(this);
		}
	}
}

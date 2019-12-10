using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string imageName { get; set; }
		public string About { get; set; }
		public DateTime RegistrationDate { get; set; }
		//public ICollection<Message> Messages { get; set; }
		public User()
		{
			Messages = new List<Message>();
		}
		public int? UserId { get; set; }
		public List<Message> Messages { get; set; }
		public int? RoleId { get; set; }
		public Role Role { get; set; }
	}
	public class Role
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<User> Users { get; set; }
		public Role()
		{
			Users = new List<User>();
		}
	}
}

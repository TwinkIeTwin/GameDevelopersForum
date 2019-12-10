using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.ViewModels
{
	public class UserEditModel
	{
		public string Login { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string About { get; set; }
		public int? RoleId { get; set; }
	}
}

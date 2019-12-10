using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.ViewModels
{
	public class EditModel
	{
		[Remote(action: "CheckPassword", controller: "Account", ErrorMessage = "Неверный пароль")]
		[DataType(DataType.Password)]
		public string LastPassword { get; set; }

		[DataType(dataType: DataType.Password)]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Compare("NewPassword", ErrorMessage = "Пароль введен неверно")]
		public string ConfirmPassword { get; set; }

		[DataType(DataType.EmailAddress) ]
		[Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Email уже используется")]
		public string Email { get; set; }
		public string About { get; set; }
	}
}

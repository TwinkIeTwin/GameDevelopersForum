using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.ViewModels
{
	public class RegisterModel
	{
		[Required(ErrorMessage = "Не указан Логин")]
		//[проверка на совпадение в бд]
		public string Login { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Пароль введен неверно")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Не указан email")]
		[DataType(DataType.EmailAddress)]
		[Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Email уже используется")]
		public string Email { get; set; }
		public string About { get; set; }

	}
}

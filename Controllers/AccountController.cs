using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GameDevelopersForum.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using GameDevelopersForum.Models; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GameDevelopersForum.Controllers
{
	public class AccountController : Controller
	{
		private readonly ForumContext db;
		IHostingEnvironment appEnvironment;
		public AccountController(IHostingEnvironment hostingEnvironment, ForumContext context)
		{
			db = context;
			appEnvironment = hostingEnvironment;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				User user = db.Users.FirstOrDefault(u => u.Login == model.Login);
				if (user == null)
				{
					user = new User { Login = model.Login, Password = model.Password, Email = model.Email, About = model.About };
					Role userRole = db.Roles.FirstOrDefault(r => r.Name == "user");
					if (userRole != null)
					{
						user.Role = userRole;
					}
					db.Users.Add(user);
					db.SaveChanges();
					Authenticate(user); 
					return RedirectToAction("Index", "Home");
				}
				else
					ModelState.AddModelError("", "Пользователь с данным именем уже существует");
			}
			return View(model);
		}


		[HttpGet]
		[Authorize]
		public IActionResult Edit()
		{
			User curUser = db.Users.First(u => u.Login == User.Identity.Name);
			ViewBag.user = curUser;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(EditModel model)
		{
			User user = db.Users.FirstOrDefault(u => u.Login == User.Identity.Name);
			if (ModelState.IsValid)
			{
				if (model.LastPassword == user.Password)
				{
					if (model.About != null)
					{
						user.About = model.About;
					}
					if (model.Email != null)
					{
						user.Email = model.Email;
					}
					if (model.NewPassword != null)
					{
						user.Password = model.NewPassword;
					}

					db.SaveChanges();

					return RedirectToAction("Index", "Home");
				} else
				{
					ModelState.AddModelError("", "неверно введен пароль");
				}
			}
			ViewBag.user = user;
			return View();
		}

		public IActionResult Profile()
		{
			
			User user = db.Users.FirstOrDefault(l => User.Identity.Name == l.Login);
				
			return View(user);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				User user = await db.Users
					.Include(u => u.Role)
					.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
				if (user != null)
				{
					await Authenticate(user);

					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("", "Некорректные логин и(или) пароль");
			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddProfileImage(IFormFile uploadedFile)
		{
			User user = db.Users.FirstOrDefault(l => User.Identity.Name == l.Login);
			string path = "/images/Users/" + user.Login;
			using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
			{
				await uploadedFile.CopyToAsync(fileStream);
			}
			if (uploadedFile != null)
			{
				user.imageName = uploadedFile.Name;
				await db.SaveChangesAsync();
				//model window - image added succesfull
				return View();
			}
			else
			{
				// modal window - image hasn't added
				return View();
			}
		}

		[HttpPost]
		private async Task Authenticate(User user)
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
			};
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}
	}
}
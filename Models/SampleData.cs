using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Models
{
	public static class SampleData
	{
		public static void Initialize(ForumContext context)
		{
			if (!context.Roles.Any() || !context.Users.Any()) { 
			string adminRoleName = "admin";
			string moderatorRoleName = "moderator";
			string userRoleName = "user";

			string adminLogin = "Admin";
			string adminPassword = "Admin";

			string moderatorLogin = "Moderator";
			string moderatorPassword = "Moderator";

			string userLogin = "User";
			string userPassword = "User";
			Role adminRole = new Role { Name = adminRoleName };
			Role moderatorRole = new Role { Name = moderatorRoleName };
			Role userRole = new Role { Name = userRoleName };
			if (!context.Roles.Any())
			{
				context.Roles.AddRange(new Role[] { adminRole, moderatorRole, userRole });
				context.SaveChanges();
			}
			if (!context.Users.Any())
			{
				User adminUser = new User { Login = adminLogin, Password = adminPassword, RoleId = adminRole.Id, RegistrationDate = DateTime.Now, Email = "admin@mail.ru", About = "Adminus", imageName = "Admin.jpg" };
				User moderatorUser = new User { Login = moderatorLogin, Password = moderatorPassword, RoleId = moderatorRole.Id, RegistrationDate = DateTime.Now, Email = "moderator@mail.ru", About = "Moderatorus", imageName = "Moderator.jpg" };
				User userUser = new User { Login = userLogin, Password = userPassword, RoleId = userRole.Id, RegistrationDate = DateTime.Now, Email = "user@mail.ru", About = "Userus", imageName = "User.jpg" };
				context.Users.AddRange(new User[] { adminUser, moderatorUser, userUser });
				context.SaveChanges();
			}
		}
			
			if (!context.News.Any())
			{
				context.News.AddRange(
					new News
					{
						Name = "Cyberpunk2077",
						Description = "Описание новости про cyberpunk2077",
						PreviewImageName = "cyberpunk2077.jpg",
						Info = "информации еще нет",
						PublishingDate = DateTime.Now
					},
					new News
					{
						Name = "Dark Souls",
						Description = "Описание новости про dark souls",
						PreviewImageName = "darksouls.jpg",
						Info = "информации еще нет",
						PublishingDate = DateTime.Now
					},
					new News
					{
						Name = "Skyrim",
						Description = "Описание новости про skyrim",
						PreviewImageName = "skyrim.jpg",
						Info = "информации еще нет",
						PublishingDate = DateTime.Now
					},
					new News
					{
						Name = "The witcher 3",
						Description = "Описание новости про ведьмак 3",
						PreviewImageName = "thewitcher3.jpg",
						Info = "информации еще нет",
						PublishingDate = DateTime.Now
					},
					new News
					{
						Name = "Uncharted 4",
						Description = "Описание новости про Uncharted 4",
						PreviewImageName = "uncharted4.jpg",
						Info = "информации еще нет",
						PublishingDate = DateTime.Now
					}) ;
				context.SaveChanges();
			}

			if (!context.Topics.Any())
			{
				
				User admin = context.Users.FirstOrDefault(u => u.Login == "Admin");
				context.Topics.AddRange(
					new Topic
					{
						CreatorId = admin.Id,
						Name = "Польза и вред видеоигр",
						CreationDate = DateTime.Now,
						PreviewImageName = "1.jpg",
						Description = "Чем опасны компьютерные игры и могут ли они быть полезными?",
						
					},
					new Topic
					{
						CreatorId = admin.Id,
						Name = "Игровые механики",
						CreationDate = DateTime.Now,
						PreviewImageName = "2.jpg",
						Description = "злоупотребление разнообразием механик может привести к плохм эффектам, рассмотрим способы их правильного внедрения.",
					}, new Topic
					{
						CreatorId = admin.Id,
						Name = "Кадзима гений?",
						CreationDate = DateTime.Now,
						PreviewImageName = "3.jpg",
						Description = "Рассмотрим причины почему японского геймдизайнера считают столь гениальным.",

					}, new Topic
					{
						CreatorId = admin.Id,
						Name = "Игры изменившие индустрию",
						CreationDate = DateTime.Now,
						PreviewImageName = "4.jpg",
						Description = "Какие игры оказали самое большое влияние, привнесли новые жанры и изменили отношение к играм?",

					});

				context.SaveChanges();
			}

		}
	}
}

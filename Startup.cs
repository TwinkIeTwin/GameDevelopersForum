using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GameDevelopersForum.constraints;
using GameDevelopersForum.Hubs;
using GameDevelopersForum.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GameDevelopersForum
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		private IConfigurationRoot dbConfConttections;
		public Startup(IHostingEnvironment hostEnv)
		{
			dbConfConttections = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{

			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.AddMvc()
				.AddDataAnnotationsLocalization()
				.AddViewLocalization();
			services.Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = new[]
				{
					new CultureInfo("en"),
					new CultureInfo("de"),
					new CultureInfo("ru")
				};

				options.DefaultRequestCulture = new RequestCulture("ru");
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;
			});


			services.ConfigureApplicationCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromTicks(0);
			});
			string connection = Configuration.GetConnectionString("forumConnection");
			services.AddDbContext<ForumContext>(options => options.UseSqlServer(connection));
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});



			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
				});

	
			services.AddSignalR();


			services.AddRouting(options =>
			{
				options.ConstraintMap.Add("correctId", typeof(IdConstraint));
			});


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{

			var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(locOptions.Value);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();


			app.UseSignalR(routes =>
			{
				routes.MapHub<ChatHub>("/chatHub");
			});
			app.UseDefaultFiles();
			app.UseStaticFiles();
			//app.UseMvc(routes =>
			//{
			//	routes.MapRoute(
			//		name: "default",
			//		template: "{controller=Home}/{action=Index}/{id?}");
			//});

			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "index", template: "/", defaults: new { controller = "Home", action = "Index" });
				routes.MapRoute(name: "about", template: "Home/About", defaults: new { controller = "Home", action = "About" });
				routes.MapRoute(name: "contact", template: "ContactUs", defaults: new { controller = "Home", action = "Contact" });
				routes.MapRoute(name: "privacy", template: "Privacy", defaults: new { controller = "Home", action = "Privacy" });

				routes.MapRoute(name: "register", template: "Register", defaults: new { controller = "Account", action = "Register" });
				routes.MapRoute(name: "profileEdit", template: "ProfileEdit", defaults: new { controller = "Account", action = "Edit" });
				routes.MapRoute(name: "Profile", template: "Profile", defaults: new { controller = "Account", action = "Profile" });
				routes.MapRoute(name: "login", template: "Login", defaults: new { controller = "Account", action = "Login" });

				routes.MapRoute(name: "chat", template: "Chat", defaults: new { controller = "Chat", action = "Chat" });

				routes.MapRoute(name: "basesList", template: "databases/List", defaults: new { controller = "DataBases", action = "Index" });
				routes.MapRoute(name: "basesNews", template: "databases/News", defaults: new { controller = "DataBases", action = "News" });
				routes.MapRoute(name: "basesUsers", template: "databases/Users", defaults: new { controller = "DataBases", action = "Users" });
				routes.MapRoute(name: "basesTopics", template: "databases/Topics", defaults: new { controller = "DataBases", action = "Topics" });
				routes.MapRoute(name: "basesTopicEdit", template: "databases/TopicEdit/{id:correctId?}", defaults: new { controller = "DataBases", action = "TopicEdit" });
				routes.MapRoute(name: "basesTopicDelete", template: "databases/TopicDelete/{id:correctId?}", defaults: new { controller = "DataBases", action = "TopicDelete" });
				routes.MapRoute(name: "basesNewsDelete", template: "databases/NewsDelete/{id:correctId?}", defaults: new { controller = "DataBases", action = "NewsDelete" });
				routes.MapRoute(name: "basesUserDelete", template: "databases/UserDelete/{id:correctId?}", defaults: new { controller = "DataBases", action = "UserDelete" });
				routes.MapRoute(name: "basesNewsEdit", template: "databases/NewsEdit/{id:correctId?}", defaults: new { controller = "DataBases", action = "NewsEdit" });
				routes.MapRoute(name: "basesUserAPI", template: "databases/UserAPI", defaults: new { controller = "DataBases", action = "UserAPI" });
				routes.MapRoute(name: "basesUserEdit", template: "databases/UserEdit/{id:correctId?}", defaults: new { controller = "DataBases", action = "UserEdit" });

				routes.MapRoute(name: "forumList", template: "forums", defaults: new { controller = "Forum", action = "List" });
				routes.MapRoute(name: "forumCreate", template: "createForum", defaults: new { controller = "Forum", action = "Create" });
				routes.MapRoute(name: "forumSend", template: "forumSendComment/{id:correctId?}/{text?}", defaults: new { controller = "Forum", action = "Send" });
				routes.MapRoute(name: "forumShow", template: "forum/{id:correctId?}", defaults: new { controller = "Forum", action = "Show" });

				routes.MapRoute(name: "newsList", template: "Allnews", defaults: new { controller = "News", action = "List" });
				routes.MapRoute(name: "newsCreate", template: "newsCreate", defaults: new { controller = "News", action = "Create" });
				routes.MapRoute(name: "newsShow", template: "news/{id:correctId?}", defaults: new { controller = "News", action = "Show" });
				routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

		});


			//

			//	var myRouteHandler = new RouteHandler(async context =>
			//	{
			//		await context.Response.WriteAsync("Routing content");
			//	});
			//	var routeBuilder = new RouteBuilder(app, myRouteHandler);
			//	routeBuilder.MapRoute(
			//"default",
			//"{controller}/{action}/{id}",
			//new { controller = "Home", action = "Index" },
			//new { id = new IdConstraint() });
			//	app.UseRouter(routeBuilder.Build());

			//

		}
	}
}

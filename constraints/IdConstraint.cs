using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.constraints
{
	public class IdConstraint : IRouteConstraint
	{
		public IdConstraint()
		{
		}

		public bool Match(HttpContext httpContext, IRouter route, string routeKey,
		RouteValueDictionary values, RouteDirection routeDirection)
		{
			int val = 0;
			string str = values[routeKey].ToString();
			bool isInt = int.TryParse(str, out val);
			return isInt && val > 0;
	

		}

	}
}

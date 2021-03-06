﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HappyMoney
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "ArgsApi",
				routeTemplate: "api/{controller}/{args}",
				defaults: new { args = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "NameApi",
				routeTemplate: "api/{controller}/{id}/{action}",
				defaults: new { action = RouteParameter.Optional }
			);
		}
	}
}

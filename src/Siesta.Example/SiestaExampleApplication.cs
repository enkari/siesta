#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Configuration;
using System.Web.Routing;
using CommonServiceLocator.NinjectAdapter;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using RouteDebug;
using Siesta.Example.Entities;
using Siesta.Framework;
#endregion

namespace Siesta.Example
{
	public class SiestaExampleApplication : NinjectHttpApplication
	{
		protected override void OnApplicationStarted()
		{
			ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));

			RegisterAllControllersIn("Siesta.Example");
			RegisterRoutes(RouteTable.Routes);

			if (ConfigurationManager.AppSettings["enableRouteDebugging"] == "true")
				RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
		}

		protected void RegisterRoutes(RouteCollection routes)
		{
			routes.MapRoute(
				"list-users", "users",
				new { controller = "user", action = "list" },
				new { httpMethod = new HttpMethodConstraint("GET") });

			routes.MapRoute(
				"create-user", "users",
				new { controller = "user", action = "create" },
				new { httpMethod = new HttpMethodConstraint("POST") });

			routes.MapRoute(
				"get-user", "users/{id}",
				new { controller = "user", action = "get" },
				new { httpMethod = new HttpMethodConstraint("GET") });

			routes.MapRoute(
				"update-user", "users/{id}",
				new { controller = "user", action = "update" },
				new { httpMethod = new HttpMethodConstraint("PUT") });

			routes.MapRoute(
				"delete-user", "users/{id}",
				new { controller = "user", action = "delete" },
				new { httpMethod = new HttpMethodConstraint("DELETE") });
		}

		protected override IKernel CreateKernel()
		{
			return new StandardKernel(new PersistenceModule(), new SerializationModule());
		}
	}
}
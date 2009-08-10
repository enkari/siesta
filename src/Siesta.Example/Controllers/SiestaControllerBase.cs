#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Siesta.Example.Repositories;
#endregion

namespace Siesta.Example.Controllers
{
	public class SiestaControllerBase : Controller
	{
		public ModelResult<T> Model<T>(T model)
		{
			return new ModelResult<T>(model);
		}

		public ModelResult<T> Model<T>(T model, ModelFormatting formatting)
		{
			return new ModelResult<T>(model, formatting);
		}

		public EmptyResult OK()
		{
			return new EmptyResult();
		}

		public HttpException NotFound()
		{
			return new HttpException(404, "Resource not found");
		}
	}
}
#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
#endregion

namespace Siesta.Framework
{
	public class RestModelBinder : IModelBinder
	{
		public IModelSerializationService SerializationService { get; private set; }

		public RestModelBinder(IModelSerializationService serializationService)
		{
			SerializationService = serializationService;
		}		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)		{
			var request = controllerContext.HttpContext.Request;

			using (var reader = new StreamReader(request.InputStream))
			{
				string content = reader.ReadToEnd();
				string contentType = GetRequestContentType(controllerContext);

				return SerializationService.Deserialize(bindingContext.ModelType, content, contentType);
			}
		}

		private string GetRequestContentType(ControllerContext context)
		{
			IEnumerable<string> supportedTypes = SerializationService.SupportedContentTypes;

			string[] acceptTypes = context.HttpContext.Request.AcceptTypes;
			string contentType = context.HttpContext.Request.ContentType;

			if (contentType != null)
			{
				foreach (string type in supportedTypes)
				{
					if (contentType.Contains(type))
						return type;
				}
			}

			if (acceptTypes != null)
			{
				foreach (string type in supportedTypes)
				{
					if (acceptTypes.Contains(type))
						return type;
				}
			}

			return SerializationService.DefaultContentType;
		}
	}
}
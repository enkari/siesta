#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Siesta.Framework;
#endregion

namespace Siesta
{
	public class BindRestModel : CustomModelBinderAttribute
	{
		public override IModelBinder GetBinder()
		{
			return ServiceLocator.Current.GetInstance<RestModelBinder>();
		}
	}
}
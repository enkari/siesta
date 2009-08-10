#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using Ninject.Modules;
using Siesta.Serializers;
#endregion

namespace Siesta.Example
{
	public class SerializationModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IModelSerializationService>().To<ModelSerializationService>().InSingletonScope();
			Bind<IModelSerializer>().To<XmlModelSerializer>().InSingletonScope();
			Bind<IModelSerializer>().To<JsonModelSerializer>().InSingletonScope();
		}
	}
}
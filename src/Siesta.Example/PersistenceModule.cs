#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using Ninject.Modules;
using Siesta.Example.Repositories;
#endregion

namespace Siesta.Example
{
	public class PersistenceModule : NinjectModule
	{
		public override void Load()
		{
			Bind(typeof(IRepository<>)).To(typeof(InMemoryRepository<>)).InSingletonScope();
		}
	}
}
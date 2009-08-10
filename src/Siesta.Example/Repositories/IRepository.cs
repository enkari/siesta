#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Siesta.Example.Entities;
using Siesta.Serializers;
#endregion

namespace Siesta.Example.Repositories
{
	public interface IRepository<T>
		where T : IEntity
	{
		T Get(int id);
		IQueryable<T> GetAll();

		int Count();
		bool Exists(int id);

		void Save(T entity);
		void Delete(T entity);
	}
}
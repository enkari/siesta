#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using Siesta.Example.Entities;
#endregion

namespace Siesta.Example.Repositories
{
	public class InMemoryRepository<T> : IRepository<T>
		where T : class, IEntity
	{
		private readonly Dictionary<int, T> _items = new Dictionary<int, T>();

		public T Get(int id)
		{
			T item;

			if (!_items.TryGetValue(id, out item))
				return null;

			return item;
		}

		public IQueryable<T> GetAll()
		{
			return _items.Values.AsQueryable();
		}

		public int Count()
		{
			return _items.Count;
		}

		public bool Exists(int id)
		{
			return _items.ContainsKey(id);
		}

		public void Save(T entity)
		{
			if (entity.Id == 0)
				entity.Id = _items.Count + 1;

			_items[entity.Id] = entity;
		}

		public void Delete(T entity)
		{
			if (entity.Id != 0)
				_items.Remove(entity.Id);
		}
	}
}
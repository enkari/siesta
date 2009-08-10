#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Linq;
#endregion

namespace Siesta.Extensions
{
	public static class ExtensionsForIQueryableOfT
	{
		public static IQueryable<T> TakePage<T>(this IQueryable<T> series, int page, int pageSize)
		{
			if (page > 0)
				series = series.Skip(pageSize * (page - 1));

			return series.Take(pageSize);
		}
	}
}
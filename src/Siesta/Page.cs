#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
#endregion

namespace Siesta
{
	[DataContract]
	public abstract class Page<T>
	{
		[DataMember(Name = "page")]
		public int PageNumber { get; set; }

		[DataMember(Name = "pageSize")]
		public int PageSize { get; set; }

		[DataMember(Name = "totalPages")]
		public int TotalPages { get; set; }

		[DataMember(Name = "totalItems")]
		public int TotalItems { get; set; }

		[DataMember(Name = "items")]
		public T[] Items { get; set; }

		protected Page() { }

		protected Page(int pageNumber, int pageSize, int totalItems, IEnumerable<T> items)
		{
			PageNumber = pageNumber;
			PageSize = pageSize;
			TotalItems = totalItems;
			TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
			Items = items.ToArray();
		}
	}
}
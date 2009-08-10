#region License
// Copyright (C) 2008-2009 Enkari, Ltd. All rights reserved.
// This code represents protected trade secrets of Enkari, Ltd. and may not be distributed,
// reproduced, or retransmitted in any form without prior written consent from its creator.
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
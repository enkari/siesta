#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
#endregion

namespace Siesta.Example.Models
{
	public class ListRequest : RequestBase
	{
		public const int DefaultPageSize = 10;

		public int Page { get; set; }
		public int PageSize { get; set; }

		public ListRequest()
		{
			Page = 1;
			PageSize = DefaultPageSize;
		}
	}
}
#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
#endregion

namespace Siesta.Example.Models
{
	public abstract class RequestBase
	{
		public bool Indent { get; set; }

		public ModelFormatting Formatting
		{
			get { return Indent ? ModelFormatting.HumanReadable : ModelFormatting.Normal; }
		}
	}
}
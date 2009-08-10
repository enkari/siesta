#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Linq;
using System.Xml;
#endregion

namespace Siesta.Extensions
{
	public static class XmlNodeExtensions
	{
		public static void Sort(this XmlNode node)
		{
			foreach (XmlElement child in node.ChildNodes.OfType<XmlElement>().OrderBy(n => n.Name))
			{
				node.AppendChild(child);
				child.Sort();
			}
		}
	}
}
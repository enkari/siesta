#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.IO;
using System.Text;
using System.Xml;
#endregion

namespace Siesta.Framework
{
	public class ModelXmlWriter : XmlTextWriter
	{
		private bool _ignore;

		public ModelXmlWriter(Stream stream, Encoding encoding, ModelFormatting formatting)
			: base(stream, encoding)
		{
			Formatting = formatting == ModelFormatting.HumanReadable ? Formatting.Indented : Formatting.None;
		}

		public override void WriteStartAttribute(string prefix, string localName, string ns)
		{
			if (ns == null || ns.Equals("http://www.w3.org/2001/XMLSchema-instance"))
			{
				_ignore = true;
				return;
			}

			base.WriteStartElement(prefix, localName, ns);
		}

		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			if (ns != null && ns.StartsWith("http://schemas.datacontract.org"))
				ns = null;

			base.WriteStartElement(prefix, localName, ns);
		}

		public override void WriteString(string text)
		{
			if (_ignore)
				return;

			base.WriteString(text);
		}

		public override void WriteEndAttribute()
		{
			if (_ignore)
			{
				_ignore = false;
				return;
			}

			base.WriteEndAttribute();
		}
	}
}
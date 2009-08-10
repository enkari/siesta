#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.IO;
using System.Xml;
using Siesta.Extensions;
#endregion

namespace Siesta.Framework
{
	public class ModelXmlReader : XmlDictionaryReader
	{
		private readonly XmlReader _reader;

		public ModelXmlReader(TextReader reader)
		{
			var document = new XmlDocument();

			document.Load(reader);
			document.FirstChild.Sort();

			_reader = new XmlNodeReader(document);
		}

		public override XmlNodeType NodeType
		{
			get { return _reader.NodeType; }
		}

		public override string LocalName
		{
			get { return _reader.LocalName; }
		}

		public override string NamespaceURI
		{
			get { return _reader.NamespaceURI; }
		}

		public override string Prefix
		{
			get { return _reader.Prefix; }
		}

		public override bool HasValue
		{
			get { return _reader.HasValue; }
		}

		public override string Value
		{
			get { return _reader.Value; }
		}

		public override int Depth
		{
			get { return _reader.Depth; }
		}

		public override string BaseURI
		{
			get { return _reader.BaseURI; }
		}

		public override bool IsEmptyElement
		{
			get { return _reader.IsEmptyElement; }
		}

		public override int AttributeCount
		{
			get { return _reader.AttributeCount; }
		}

		public override bool EOF
		{
			get { return _reader.EOF; }
		}

		public override ReadState ReadState
		{
			get { return _reader.ReadState; }
		}

		public override XmlNameTable NameTable
		{
			get { return _reader.NameTable; }
		}

		public override string GetAttribute(string name)
		{
			return _reader.GetAttribute(name);
		}

		public override string GetAttribute(string name, string namespaceURI)
		{
			return _reader.GetAttribute(name, namespaceURI);
		}

		public override string GetAttribute(int i)
		{
			return _reader.GetAttribute(i);
		}

		public override bool MoveToAttribute(string name)
		{
			return _reader.MoveToAttribute(name);
		}

		public override bool MoveToAttribute(string name, string ns)
		{
			return _reader.MoveToAttribute(name, ns);
		}

		public override bool MoveToFirstAttribute()
		{
			return _reader.MoveToFirstAttribute();
		}

		public override bool MoveToNextAttribute()
		{
			return _reader.MoveToNextAttribute();
		}

		public override bool MoveToElement()
		{
			return _reader.MoveToElement();
		}

		public override bool ReadAttributeValue()
		{
			return _reader.ReadAttributeValue();
		}

		public override bool Read()
		{
			return _reader.Read();
		}

		public override void Close()
		{
			_reader.Close();
		}

		public override string LookupNamespace(string prefix)
		{
			return _reader.LookupNamespace(prefix);
		}

		public override void ResolveEntity()
		{
			_reader.ResolveEntity();
		}
	}
}
#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Siesta.Framework;
#endregion

namespace Siesta.Serializers
{
	public class XmlModelSerializer : IModelSerializer
	{
		private readonly Dictionary<RuntimeTypeHandle, DataContractSerializer> _serializers = new Dictionary<RuntimeTypeHandle, DataContractSerializer>();

		public string ContentType
		{
			get { return "application/xml"; }
		}

		public bool IsDefault
		{
			get { return true; }
		}

		public string Serialize(object model, ModelFormatting formatting)
		{
			using (var buffer = new MemoryStream(1024))
			using (var writer = new ModelXmlWriter(buffer, Encoding.UTF8, formatting))
			{
				DataContractSerializer serializer = GetSerializerForType(model.GetType());

				writer.WriteStartDocument();
				serializer.WriteObject(writer, model);
				writer.Flush();

				return Encoding.UTF8.GetString(buffer.ToArray());
			}
		}

		public object Deserialize(Type modelType, string content)
		{
			DataContractSerializer serializer = GetSerializerForType(modelType);

			using (var stream = new StringReader(content))
			using (var reader = new ModelXmlReader(stream))
			{
				return serializer.ReadObject(reader);
			}
		}

		private DataContractSerializer GetSerializerForType(Type type)
		{
			RuntimeTypeHandle handle = type.TypeHandle;

			if (_serializers.ContainsKey(handle))
				return _serializers[handle];

			var serializer = new DataContractSerializer(type);
			_serializers.Add(handle, serializer);

			return serializer;
		}
	}
}
#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using Newtonsoft.Json;
#endregion

namespace Siesta.Serializers
{
	public class JsonModelSerializer : IModelSerializer
	{
		public JsonSerializerSettings Settings { get; private set; }

		public string ContentType
		{
			get { return "application/json"; }
		}

		public bool IsDefault
		{
			get { return false; }
		}

		public JsonModelSerializer()
		{
			Settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
		}

		public string Serialize(object model, ModelFormatting formatting)
		{
			Formatting jsonFormatting = formatting == ModelFormatting.HumanReadable ? Formatting.Indented : Formatting.None;
			return JsonConvert.SerializeObject(model, jsonFormatting, Settings);
		}

		public object Deserialize(Type modelType, string content)
		{
			return JsonConvert.DeserializeObject(content, modelType);
		}
	}
}
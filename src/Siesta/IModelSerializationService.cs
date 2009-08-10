#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
#endregion

namespace Siesta
{
	public interface IModelSerializationService
	{
		IEnumerable<string> SupportedContentTypes { get; }
		string DefaultContentType { get; }

		string Serialize(object model, string contentType, ModelFormatting formatting);
		object Deserialize(Type modelType, string content, string contentType);
	}
}
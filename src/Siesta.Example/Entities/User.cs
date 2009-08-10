#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Runtime.Serialization;
#endregion

namespace Siesta.Example.Entities
{
	[DataContract(Name = "user", Namespace = "")]
	public class User : IEntity
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "username")]
		public string UserName { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "email")]
		public string Email { get; set; }
	}
}
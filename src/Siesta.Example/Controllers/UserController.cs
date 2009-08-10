#region License
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// Licensed under the Apache License, Version 2.0. See the file LICENSE.txt for details.
#endregion
#region Using Directives
using System;
using System.Web.Mvc;
using Siesta.Example.Entities;
using Siesta.Example.Models;
using Siesta.Example.Repositories;
using Siesta.Extensions;
#endregion

namespace Siesta.Example.Controllers
{
	public class UserController : SiestaControllerBase
	{
		public IRepository<User> UserRepository { get; private set; }

		public UserController(IRepository<User> userRepository)
		{
			UserRepository = userRepository;
		}

		public ModelResult<UserPage> List(ListRequest request)
		{
			var users = UserRepository.GetAll().TakePage(request.Page, request.PageSize);
			int totalItems = UserRepository.Count();

			var page = new UserPage(request.Page, request.PageSize, totalItems, users);
			return Model(page, request.Formatting);
		}

		public EmptyResult Create([BindRestModel] User user)
		{
			UserRepository.Save(user);
			return OK();
		}

		public ModelResult<User> Get(GetRequest request)
		{
			User user = UserRepository.Get(request.Id);

			if (user == null)
				throw NotFound();

			return Model(user, request.Formatting);
		}

		public EmptyResult Update([BindRestModel] User user)
		{
			if (!UserRepository.Exists(user.Id))
				throw NotFound();

			UserRepository.Save(user);

			return OK();
		}

		public EmptyResult Delete(int userid)
		{
			User user = UserRepository.Get(userid);

			if (user == null)
				throw NotFound();

			UserRepository.Delete(user);

			return OK();
		}
	}
}
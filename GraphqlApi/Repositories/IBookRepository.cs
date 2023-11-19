// <copyright file="IBookRepository.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Repositories
{
	using Models;

	public interface IBookRepository
	{
		IEnumerable<Book> GetBooks();
	}
}
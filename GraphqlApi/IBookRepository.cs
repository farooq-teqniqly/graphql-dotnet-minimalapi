// <copyright file="IBookRepository.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi
{
	public interface IBookRepository
	{
		IEnumerable<Book> GetBooks();
	}
}
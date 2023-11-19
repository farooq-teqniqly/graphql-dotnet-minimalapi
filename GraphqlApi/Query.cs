// <copyright file="Query.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi
{
	public class Query
	{
		public IEnumerable<Book> GetBooks(IBookRepository bookRepository)
			=> bookRepository.GetBooks();
	}
}
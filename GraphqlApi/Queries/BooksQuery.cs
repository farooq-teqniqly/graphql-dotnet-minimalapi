// <copyright file="BooksQuery.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Queries
{
	using Models;
	using Repositories;

	public partial class Query
	{
		public IEnumerable<Book> GetBooks(IBookRepository bookRepository)
			=> bookRepository.GetBooks();
	}
}
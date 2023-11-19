// <copyright file="BooksQuery.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi
{
	public class BooksQuery
	{
		public IEnumerable<Book> GetBooks(IBookRepository bookRepository)
			=> bookRepository.GetBooks();
	}

	public record Book(string? Title, Author? Author);

	public record Author(string Name);
}
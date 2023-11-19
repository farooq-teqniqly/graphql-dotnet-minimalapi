// <copyright file="BookRepository.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi
{
	public class BookRepository : IBookRepository
	{
		public IEnumerable<Book> GetBooks()
		{
			var author = new Author("Cormac McCarthy");
			yield return new Book("The Road", author);
			yield return new Book("No Country for Old Men", author);
		}
	}
}
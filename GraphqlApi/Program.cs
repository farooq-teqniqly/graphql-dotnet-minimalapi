// <copyright file="Program.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddGraphQLServer().AddQueryType<Query>();

			var app = builder.Build();

			app.MapGraphQL();
			app.Run();
		}
	}

	public class Query
	{
		public string Hello(string name = "World") => $"Hello {name}";

		public IEnumerable<Book> GetBooks()
		{
			var author = new Author("Cormac McCarthy");
			yield return new Book("The Road", author);
			yield return new Book("No Country for Old Men", author);
		}
	}

	public record Book(string? Title, Author? Author);

	public record Author(string Name);
}
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
			builder.Services.AddScoped<IBookRepository, BookRepository>();

			builder
				.Services
				.AddGraphQLServer()
				.RegisterService<IBookRepository>()
				.AddQueryType<BooksQuery>();

			var app = builder.Build();

			app.MapGraphQL();
			app.Run();
		}
	}
}
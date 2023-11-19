// <copyright file="Program.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi
{
	using Queries;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddScoped<IBookRepository, BookRepository>();
			builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

			builder
				.Services
				.AddGraphQLServer()
				.RegisterService<IBookRepository>()
				.RegisterService<ICustomerRepository>()
				.AddQueryType<Query>();

			var app = builder.Build();

			app.MapGraphQL();
			app.Run();
		}
	}
}
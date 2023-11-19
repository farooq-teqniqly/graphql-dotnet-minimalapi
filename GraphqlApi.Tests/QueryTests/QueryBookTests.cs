// <copyright file="QueryBookTests.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Tests.QueryTests
{
	using FluentAssertions;
	using Models;
	using System;
	using System.Net;
	using Utils;

	public class QueryBookTests : IClassFixture<CustomWebApplicationFactory>, IDisposable
	{
		private const string GraphqlEndpoint = "graphql";
		private readonly ApiTestClient client;

		public QueryBookTests(CustomWebApplicationFactory webApplicationFactory)
			=> client = new ApiTestClient(webApplicationFactory.CreateClient());

		[Fact]
		public async Task Can_Query_The_Titles_And_Authors()
		{
			var query = @"{
						    books {
						         title
						         author {
						            name
						         }
						    }
						}";

			var response = await client.EnsureGraphqlPostAsync(GraphqlEndpoint, query);
			var books = await response.DeserializeAsync<Book[]>("books");

			books.Should().NotBeNull();
			books!.Length.Should().Be(2);
			books.Single(b => b.Title == "No Country for Old Men").Author!.Name.Should().Be("Cormac McCarthy");
			books.Single(b => b.Title == "The Road").Author!.Name.Should().Be("Cormac McCarthy");
		}

		[Fact]
		public async Task Can_Query_Just_The_Titles()
		{
			var query = @"{
						    books {
						         title
						    }
						}";

			var response = await client.EnsureGraphqlPostAsync(GraphqlEndpoint, query);
			var books = await response.DeserializeAsync<Book[]>("books");

			books.Should().NotBeNull();
			books!.Length.Should().Be(2);

			books.Count(b => b.Author is null).Should().Be(2);
		}

		[Fact]
		public async Task Can_Query_Just_The_Authors()
		{
			var query = @"{
						    books {
						         author {
									name
								}
						    }
						}";

			var response = await client.EnsureGraphqlPostAsync(GraphqlEndpoint, query);
			var books = await response.DeserializeAsync<Book[]>("books");

			books.Should().NotBeNull();
			books!.Length.Should().Be(2);

			books.Count(b => b.Title is null).Should().Be(2);
			books.Count(b => b.Author!.Name == "Cormac McCarthy").Should().Be(2);
		}

		[Fact]
		public async Task A_Bad_Query_Returns_Bad_Request()
		{
			var query = @"{
						    books {
						         author {
								}
						    }
						}".AsGraphqlQuery();

			var response = await client.PostAsync(GraphqlEndpoint, query);
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}

		public void Dispose() => client.Dispose();
	}
}

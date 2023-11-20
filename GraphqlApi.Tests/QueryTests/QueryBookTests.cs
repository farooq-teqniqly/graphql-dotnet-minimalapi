// <copyright file="QueryBookTests.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Tests.QueryTests
{
	using FluentAssertions;
	using Snapshooter.Xunit;
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

			var queryResult = await RunQueryTest(query);

			Snapshot.Match(queryResult);
		}

		[Fact]
		public async Task Can_Query_Just_The_Titles()
		{
			var query = @"{
						    books {
						         title
						    }
						}";

			var queryResult = await RunQueryTest(query);

			Snapshot.Match(queryResult);
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

			var queryResult = await RunQueryTest(query);

			Snapshot.Match(queryResult);
		}

		[Fact]
		public async Task A_Bad_Query_Returns_Bad_Request()
		{
			var query = @"{
						    books {
						         author {
								}
						    }
						}";

			var error = await RunQueryTest(query, HttpStatusCode.BadRequest);

			Snapshot.Match(error);
		}

		public void Dispose() => client.Dispose();

		private async Task<string> RunQueryTest(
			string query,
			HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
		{
			var response = await client.PostAsync(GraphqlEndpoint, query.AsGraphqlQuery());
			response.StatusCode.Should().Be(expectedStatusCode);

			return await response.Content.ReadAsStringAsync();
		}
	}
}

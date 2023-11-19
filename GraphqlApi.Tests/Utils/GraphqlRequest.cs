// <copyright file="GraphqlRequest.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Tests.Utils
{
	internal static class GraphqlRequest
	{
		public static object AsGraphqlQuery(this string queryString) => new { query = queryString };
	}
}

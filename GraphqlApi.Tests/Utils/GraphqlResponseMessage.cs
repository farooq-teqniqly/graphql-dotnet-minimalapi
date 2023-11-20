// <copyright file="GraphqlResponseMessage.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Tests.Utils
{
	using System.Text.Json;

	internal class GraphqlResponseMessage
	{
		private readonly HttpResponseMessage httpResponseMessage;

		private readonly JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

		public GraphqlResponseMessage(HttpResponseMessage httpResponseMessage) => this.httpResponseMessage = httpResponseMessage;

		public async Task<T?> DeserializeAsync<T>(string rootProperty)
		{
			var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
			var jsonDocument = JsonDocument.Parse(responseBody);
			var dataElement = jsonDocument.RootElement.GetProperty("data").GetProperty(rootProperty);

			return dataElement.Deserialize<T>(jsonSerializerOptions);

		}

		public async Task<string> ReadAsStringAsync() => await httpResponseMessage.Content.ReadAsStringAsync();
	}
}

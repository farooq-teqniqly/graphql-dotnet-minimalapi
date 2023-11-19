// <copyright file="Customer.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Models
{
	public record Customer(string Name, DateOnly Since);
}
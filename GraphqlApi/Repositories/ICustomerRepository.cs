// <copyright file="ICustomerRepository.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Repositories
{
	using Models;

	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetCustomers();
	}
}
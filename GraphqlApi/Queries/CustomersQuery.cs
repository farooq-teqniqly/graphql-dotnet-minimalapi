// <copyright file="CustomersQuery.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi.Queries
{
	using Models;
	using Repositories;

	public partial class Query
	{
		public IEnumerable<Customer> GetCustomers(ICustomerRepository customersRepository)
			=> customersRepository.GetCustomers();
	}
}
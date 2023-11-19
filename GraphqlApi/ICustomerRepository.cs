// <copyright file="ICustomerRepository.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetCustomers();
	}
}
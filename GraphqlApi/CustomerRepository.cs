// <copyright file="CustomerRepository.cs" company="Teqniqly">
// Copyright (c) Teqniqly. All rights reserved.
// </copyright>

namespace GraphqlApi
{
	public class CustomerRepository : ICustomerRepository
	{
		public IEnumerable<Customer> GetCustomers()
		{
			yield return new Customer("Farooq Mahmud", new DateOnly(2022, 1, 13));
			yield return new Customer("Atticus Worthington", new DateOnly(2005, 6, 9));
		}
	}
}
using Bogus;
using JSM.CustomExceptionMiddleware.CustomExceptions;
using System;
using System.Collections.Generic;

namespace JSM.CustomExceptionMiddleware.WebAppTest
{
    public class CustomerService : ICustomerService
    {
        public IEnumerable<Customer> Get(int customersCount)
        {
            return GetCustomers(customersCount);
        }

        public IEnumerable<Customer> GetDomainException(bool returnCustomers)
        {
            if (returnCustomers)
                return GetCustomers();

            throw new InvalidStateException("Custom domain exception message");
        }

        public IEnumerable<Customer> GetCannotAccessException(bool returnCustomers)
        {
            if (returnCustomers)
                return GetCustomers();

            throw new CannotAccessException("Custom cannot access exception message");
        }

        public IEnumerable<Customer> GetNotFoundException(bool returnCustomers)
        {
            if (returnCustomers)
                return GetCustomers();

            throw new NotFoundException("Custom not found exception message");
        }

        public IEnumerable<Customer> GetException(bool returnCustomers)
        {
            if (returnCustomers)
                return GetCustomers();

            throw new Exception("Custom exception message");
        }

        private static IEnumerable<Customer> GetCustomers(int customersCount = 10)
        {
            var fake = new Faker<Customer>()
                .CustomInstantiator(x => new Customer
                {
                    Name = x.Person.FullName
                });

            return fake.Generate(customersCount);
        }
    }
}
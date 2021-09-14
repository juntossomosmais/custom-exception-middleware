﻿using System.Collections.Generic;

namespace JSM.CustomExceptionMiddleware.WebAppTest
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get(int customersCount);
        IEnumerable<Customer> GetDomainException(bool returnCustomers);
        IEnumerable<Customer> GetCannotAccessException(bool returnCustomers);
        IEnumerable<Customer> GetNotFoundException(bool returnCustomers);
        IEnumerable<Customer> GetException(bool returnCustomers);
    }
}

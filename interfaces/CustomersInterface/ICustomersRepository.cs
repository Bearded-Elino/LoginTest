using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VB_0011.dtos;
using VB_0011.models.customer;

namespace VB_0011.interfaces.CustomersInterface
{
    public interface ICustomersRepository
    {
        public Task<Customer> CreateCustomerAsync(RegisterCustomerDto registerCustomerDto);
        public Task<string?> LoginAsync(LoginDto loginDto);
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VB_0011.data;
using VB_0011.dtos;
using VB_0011.interfaces.CustomersInterface;
using VB_0011.mappers;
using VB_0011.models.customer;

namespace VB_0011.repositories.CustomersRepository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _context;

        public CustomersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomerAsync(RegisterCustomerDto registerCustomerDto)
        {
            try
            {
                var customers = new Customer
                {
                    FirstName = registerCustomerDto.FirstName,
                    LastName = registerCustomerDto.LastName,
                    Email = registerCustomerDto.Email,
                    DateOfBirth = registerCustomerDto.DateOfBirth,
                    Address = registerCustomerDto.Address,
                    City = registerCustomerDto.City,
                    Phone = registerCustomerDto.Phone,
                    BVN = registerCustomerDto.BVN,
                    FirstNameOfNextOfKin = registerCustomerDto.FirstNameOfNextOfKin,
                    LastNameOfNextOfKin = registerCustomerDto.LastNameOfNextOfKin,
                    AddressOfNextOfKin = registerCustomerDto.AddressOfNextOfKin,
                    PhoneOfNextOfKin = registerCustomerDto.PhoneOfNextOfKin,

                };
                await _context.Customers.AddAsync(customers);
                await _context.SaveChangesAsync();
                return customers;

            }
            catch (Exception ex)
            {

                throw new Exception("cannot register", ex);
            }
        }

        public Task<string?> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}


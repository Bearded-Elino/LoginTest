using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VB_0011.data;
using VB_0011.dtos;
using VB_0011.interfaces.CustomersInterface;
using VB_0011.models.customer;

namespace VB_0011.controllers.customerController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomerController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterCustomerDto registerCustomerDto)
        {
            try
            {
                var Customers = await _customersRepository.CreateCustomerAsync(registerCustomerDto);
                return Ok(Customers);
            }
            catch (System.Exception)
            {
                return BadRequest(new{status = "failed", message = "customer could not be registered"});
            }
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            try
            {
                var token = await _customersRepository.LoginAsync(loginDto);
                {
                    if (token == null)
                    {
                        return Unauthorized("Login failed");
                    }

                    return Ok(new {Token = token});
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
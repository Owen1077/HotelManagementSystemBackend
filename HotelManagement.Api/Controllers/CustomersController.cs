﻿using HotelManagement.Core.DTOs;
using HotelManagement.Core;
using HotelManagement.Core.IServices;
using HotelManagement.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;

        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("GetCustomers/{pageNo}")]
        public async Task<ActionResult<Response<List<GetCustomerDto>>>> GetCustomers(int pageNo)
        {


            try
            {
                //log information
                var result = await _customerService.GetCustomers(pageNo);
                if (result == null)
                {
                    return NotFound("Custmomers not found");
                }
                return Ok(result);
            }

            catch (Exception ex)
            {
                //log the errors
                // catch exception
                return StatusCode(500, ex.Message);
            }

        }
    }
}
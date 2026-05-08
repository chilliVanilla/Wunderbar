using Microsoft.AspNetCore.Mvc;
using Wunderbar.Application.DTOs;
using Wunderbar.Application.Interfaces;

namespace Wunderbar.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost("AddNewCustomer")]
    public IActionResult AddNewCustomer(CustomerDto customerDto)
    {
        Console.WriteLine("Adding new customer");
        var outcome = _customerService.addNewCustomer(customerDto);

        if (!outcome)
        {
            return BadRequest("Customer not added");
        }
        return Ok(customerDto);
    }
    
    [HttpGet("AllCustomers")]
    public IActionResult GetAllUsers()
    {
        var allCustomers = _customerService.GetAllCustomers();
        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (allCustomers is null)
        {
            return BadRequest();
        }
        
        return Ok(allCustomers);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetCustomerById(Guid id)
    {
        var customer = _customerService.GetCustomerById(id);
        if (customer is null){
            return BadRequest();
        }
        return Ok(customer);
    }

    [HttpGet("GetByEmail/{email}")]
    public IActionResult GetCustomerByEmail(string email)
    {
        var customer = _customerService.GetCustomerByEmail(email);
        if (customer is null)
        {
            return BadRequest("Customer not found");
        }

        return Ok(customer);
    }

    [HttpPatch("UpdateCustomerDetails")]
    public IActionResult UpdateCustomerDetails(Guid id, UpdateDetailsDto dto)
    {
        var status = _customerService.UpdateCustomer(id, dto);
        if (!status)
        {
            return BadRequest("An error occurred!!");
        }

        return Ok("Customer updated");

    }
    

    [HttpDelete("DeleteCustomer")]
    public IActionResult DeleteCustomer(Guid id)
    {
        var test = _customerService.DeleteCustomer(id);

        if (!test)
        {
            return BadRequest("Customer could not be found\nThey're probably no longer exist.");
        }
        return Ok("Customer was deleted!!");
    }

}
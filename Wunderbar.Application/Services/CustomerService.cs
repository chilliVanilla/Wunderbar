using Wunderbar.Application.DTOs;
using Wunderbar.Application.Interfaces;
using Wunderbar.Domain.Models;
using Wunderbar.Infrastructure.Data;

namespace Wunderbar.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _dbcontext;
    public CustomerService(ApplicationDbContext dbcontext)
    {
        this._dbcontext = dbcontext;
    }

    
    public bool addNewCustomer(CustomerDto customerDto)
    {
        if (customerDto is null)
        {
            Console.WriteLine(customerDto + " is null");
            return false;
        }
        // var identityUid = _dbcontext.

        var jjc = new Customer()
        {
            CustomerId = Guid.NewGuid(),
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            MiddleName = customerDto.MiddleName,
            EmailAddress = customerDto.EmailAddress.ToLower().Trim(),
            Age = customerDto.Age,
        };
        
        _dbcontext.Customers.Add(jjc);
        _dbcontext.SaveChanges();
        Console.WriteLine(customerDto + " has been added");
        return true;
    }
    
    public List<Customer> GetAllCustomers()
        {
            return _dbcontext.Customers.ToList();
        }

    public Customer GetCustomerById(Guid id)
    {
        return _dbcontext.Customers.FirstOrDefault(c => c.CustomerId == id);
    }

    public Customer GetCustomerByEmail(string email)
    {
        var tightenedEmail = email.ToLower().Trim();
        return _dbcontext.Customers.FirstOrDefault(c=>c.EmailAddress == email);
    }

    public bool UpdateCustomer(Guid id, UpdateDetailsDto updateDetails)
    {
        if (updateDetails is null)
        {
            Console.WriteLine(updateDetails + " is null");
            return false;
        }

        var target = GetCustomerById(id);

        Console.WriteLine("Update Details: " + updateDetails);

        if (updateDetails.FirstName is not null)
        {
            target.FirstName = updateDetails.FirstName;
        }
        if (updateDetails.LastName is not null)
        {
            target.LastName = updateDetails.LastName;
        }
        if (updateDetails.EmailAddress is not null)
        {
            target.EmailAddress = updateDetails.EmailAddress;
        }
        if (updateDetails.MiddleName is not null)
        {
            target.MiddleName = updateDetails.MiddleName;
        }
        if (updateDetails.Age is not null)
        {
            target.Age = updateDetails.Age;
        }

        _dbcontext.SaveChanges();
        
        return true;
    }

    public bool DeleteCustomer(Guid id)
    {
        var customer = _dbcontext.Customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer is null)
        {
            return false;
        }
        _dbcontext.Customers.Remove(customer);
        _dbcontext.SaveChanges();
        return true;
    }
    

    
    
}
using Wunderbar.Application.DTOs;
using Wunderbar.Domain.Models;

namespace Wunderbar.Application.Interfaces;

public interface ICustomerService
{
    public bool addNewCustomer(CustomerDto customerDto);
    public List<Customer> GetAllCustomers();
    public Customer GetCustomerById(Guid id);
    public Customer GetCustomerByEmail(string email);
    public bool UpdateCustomer(Guid id, UpdateDetailsDto customerDto);
    public bool DeleteCustomer(Guid id);
    
    
    
}
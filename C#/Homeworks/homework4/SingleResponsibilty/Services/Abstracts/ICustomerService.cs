using SingleResponsibilty.Entities;

namespace SingleResponsibilty.Services.Abstracts;
public interface ICustomerService {
    public Task<IEnumerable<Customer>> GetCustomers();
    public Task<Customer> GetCustomerByIdAsync(Guid id);
    public Task AddCustomerAsync(Customer customer);
    public Task RemoveCustomerAsync(Customer customer);
    public Task RemoveCustomerByIdAsync(Guid id);
}
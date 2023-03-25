using SingleResponsibilty.Entities;
using SingleResponsibilty.Repository.Abstracts;
using SingleResponsibilty.Services.Abstracts;

namespace SingleResponsibilty.Services;
public sealed class CustomerService : ICustomerService {
    public readonly ICustomerReadRepository customerReadRepository;
    public readonly ICustomerWriteRepository customerWriteRepository;

    public CustomerService(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository) {
        this.customerReadRepository = customerReadRepository;
        this.customerWriteRepository = customerWriteRepository;
    }

    public async Task AddCustomerAsync(Customer customer) {
        await this.customerWriteRepository.InsertAsync(customer);
    }

    public async Task<Customer> GetCustomerByIdAsync(Guid id) {
        return await this.customerReadRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetCustomers() {
        return await this.customerReadRepository.GetAllAsync();   
    }

    public async Task RemoveCustomerAsync(Customer customer) {
        await this.customerWriteRepository.DeleteAsync(customer);
    }

    public async Task RemoveCustomerByIdAsync(Guid id) {
        await this.customerWriteRepository.DeleteByIdAsync(id);
    }
}
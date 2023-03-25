using SingleResponsibilty.Entities;
using SingleResponsibilty.Repository.Abstracts;

namespace SingleResponsibilty.Repository.Concretes;
public sealed class CustomerReadRepository : AsyncReadRepository<Customer>, ICustomerReadRepository { }
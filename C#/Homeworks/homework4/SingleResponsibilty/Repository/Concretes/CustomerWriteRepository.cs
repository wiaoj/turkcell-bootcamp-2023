using SingleResponsibilty.Entities;
using SingleResponsibilty.Repository.Abstracts;

namespace SingleResponsibilty.Repository.Concretes;
public sealed class CustomerWriteRepository : AsyncWriteRepository<Customer>, ICustomerWriteRepository { }
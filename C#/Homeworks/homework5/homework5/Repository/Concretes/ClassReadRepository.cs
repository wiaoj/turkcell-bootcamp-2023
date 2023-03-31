using homework5.Entities;
using homework5.Repository.Abstracts;

namespace homework5.Repository.Concretes;
public sealed class ClassReadRepository : ReadRepository<ClassEntity>, IClassReadRepository { }
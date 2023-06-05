using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Common.Specification;
public abstract class Specification<TEntity> where TEntity : Entity, new() { }
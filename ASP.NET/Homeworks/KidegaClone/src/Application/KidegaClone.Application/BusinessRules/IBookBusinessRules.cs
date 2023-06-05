using KidegaClone.Application.Common;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.BusinessRules;
internal interface IBookBusinessRules : IBusinessRules {
    void IfBookIsNullThrow(BookEntity? book);
}
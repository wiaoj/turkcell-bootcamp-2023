using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.BusinessRules;
internal sealed class BookBusinessRules : IBookBusinessRules {
    public void IfBookIsNullThrow(BookEntity? book)
        => _ = book ?? throw new Exception("Kitap bulunamadı dırırırım");
}
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;
public sealed class ApplicationUser : IdentityUser, IEntity {
    public string Name { get; set; }
    public string Surname { get; set; }
}
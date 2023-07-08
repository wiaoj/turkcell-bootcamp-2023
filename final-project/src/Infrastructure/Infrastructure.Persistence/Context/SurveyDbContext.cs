using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;
internal class SurveyDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string> {
    public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options) { }

    public DbSet<ApplicationUser> Users { get; set; }
}
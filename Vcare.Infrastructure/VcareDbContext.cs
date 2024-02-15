using Microsoft.EntityFrameworkCore;
using Vcare.Domain.LandingPages;

namespace Medicare.Infrastructure;

public class VcareDbContext: DbContext
{
    public VcareDbContext(DbContextOptions<VcareDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Signup> Signups { get; set; }
    public DbSet<Login> Logins { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VcareDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
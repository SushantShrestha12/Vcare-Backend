using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vcare.Domain.LandingPages;

namespace Medicare.Infrastructure.Configurations;

public class LoginConfiguration: IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.HasKey(l => l.Email);
    }
}
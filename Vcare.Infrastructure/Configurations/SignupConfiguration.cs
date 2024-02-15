using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vcare.Domain.LandingPages;

namespace Medicare.Infrastructure.Configurations;

public class SignupConfiguration: IEntityTypeConfiguration<Signup>
{
    public void Configure(EntityTypeBuilder<Signup> builder)
    {
        builder.HasKey(o => o.Id);
    }
}
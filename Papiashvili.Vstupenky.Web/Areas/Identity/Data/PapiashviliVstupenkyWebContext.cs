using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Papiashvili.Vstupenky.Web.Areas.Identity.Data;

namespace Papiashvili.Vstupenky.Web.Areas.Identity.Data;

public class PapiashviliVstupenkyWebContext : IdentityDbContext<PapiashviliVstupenkyWebUser>
{
    public PapiashviliVstupenkyWebContext(DbContextOptions<PapiashviliVstupenkyWebContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<PapiashviliVstupenkyWebUser>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PapiashviliVstupenkyWebUser> builder)
    {
        builder.Property(x => x.jmeno).HasMaxLength(100);
        builder.Property(x => x.prijmeni).HasMaxLength(100);
    }
}

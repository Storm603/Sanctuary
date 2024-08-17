using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Seeding.Configurations
{
    internal class BaseApplicationUserConfiguration : IEntityTypeConfiguration<BaseApplicationUser>
    {
        public void Configure(EntityTypeBuilder<BaseApplicationUser> builder)
        {
            builder.HasMany(e => e.Claims).WithOne().HasForeignKey(uc => uc.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Roles).WithOne().HasForeignKey(uc => uc.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Tokens).WithOne().HasForeignKey(uc => uc.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Logins).WithOne().HasForeignKey(uc => uc.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Address).WithOne(x => x.BaseUser).HasForeignKey<Address>(x => x.UserId);
        }
    }
}

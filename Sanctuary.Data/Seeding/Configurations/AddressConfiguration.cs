using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sanctuary.Data.Models.LocationTables;

namespace Sanctuary.Data.Seeding.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(x => x.BaseUser).WithOne(x => x.Address)
                .HasForeignKey<Address>(x => x.UserId);
            builder.HasOne(x => x.Clinic).WithOne(x => x.Address)
                .HasForeignKey<Address>(x => x.ClinicId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sanctuary.Data.Models.ClinicTables;

namespace Sanctuary.Data.Seeding.Configurations
{
    internal class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasMany(x => x.Doctors).WithOne(x => x.Clinic).HasForeignKey(x => x.ClinicId);
            builder.HasMany(x => x.Users).WithOne(x => x.Clinic).HasForeignKey(x => x.ClinicId);

            builder.HasIndex(x => x.ClinicName).IsUnique();
        }
    }
}
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
    internal class ClinicStaffLeaveConfiguration : IEntityTypeConfiguration<ClinicStaffLeave>
    {
        public void Configure(EntityTypeBuilder<ClinicStaffLeave> builder)
        {
            builder.HasOne(x => x.RequestedBy).WithMany(x => x.ClinicStaffLeaveRequest)
                .HasForeignKey(x => x.RequestedById);
            builder.HasOne(x => x.ReplacedBy).WithMany(x => x.ClinicStaffLeaveReplace)
                .HasForeignKey(x => x.ReplacedById);
            builder.Property(x => x.Days).HasColumnType("smallint");
        }
    }
}
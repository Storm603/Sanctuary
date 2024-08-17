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
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasOne(c => c.Client).WithMany(a => a.AppointmentList).HasForeignKey(fk => fk.ClientId);
            builder.HasOne(d => d.Doctor).WithMany(s => s.Schedule).HasForeignKey(fk => fk.DoctorId);
        }
    }
}

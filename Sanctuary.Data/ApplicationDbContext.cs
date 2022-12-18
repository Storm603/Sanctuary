using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data.Seeding;

namespace Sanctuary.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<BaseApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MT_User_Addresses> MtUserAddresses { get; set; }
        public DbSet<ClientUser> ClientUsers { get; set; }
        public DbSet<ClinicStaffUser> ClinicStaffUsers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<MedicalLog> MedicalLogs { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PromoCodes> PromoCodes { get; set; }
        public DbSet<PetHotel> PetHotel { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<HospitalizedPets> HospitalizedPets { get; set; }
        public DbSet<ClinicServices> ClinicServices { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<AbsenceType> AbsenceType { get; set; }


        public DbSet<MT_Clinic_Addresses> MtClinicAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                 new IdentityRole("Dentist"),
                 new IdentityRole("Dermatologist"),
                 new IdentityRole("Emergency and Critical Care Specialist"),
                 new IdentityRole("Ophthalmologist"),
                 new IdentityRole("Dentist"),
                 new IdentityRole("Surgery"),
                 new IdentityRole("Toxicologist"),
                 new IdentityRole("Behaviorist"),
                 new IdentityRole("Common Veterinary"),
                 new IdentityRole("Manager"),
                 new IdentityRole("Administrator"),
                 new IdentityRole("User"));

            builder.Entity<MT_User_Addresses>().HasKey(x => new { x.AddressId, x.UserId });
            builder.Entity<MT_Clinic_Addresses>().HasKey(x => new { x.AddressId, x.ClinicId });

            builder.Entity<MT_Clinic_Addresses>().HasOne(x => x.Clinic).WithOne(x => x.Address).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<MT_Clinic_Addresses>().HasOne(x => x.Address).WithOne().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>().HasOne(cu => cu.Client).WithMany(a => a.AppointmentList)
                .HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Appointment>().HasOne(su => su.Doctor).WithMany(a => a.Schedule)
                .HasForeignKey(fk => fk.DoctorId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Clinic>().HasMany(x => x.Doctor).WithOne(x => x.Clinic).HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Clinic>().HasMany(x => x.Users).WithOne(x => x.Clinic).HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PetHotel>().HasKey(x => x.Id);
            builder.Entity<Clinic>().HasKey(x => x.Id);

            builder.Entity<ClinicStaffLeave>().HasOne(x => x.RequestedBy).WithMany(x => x.ClinicStaffLeaveRequest).HasForeignKey(x => x.RequestedById)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ClinicStaffLeave>().HasOne(x => x.ReplacedBy).WithMany(x => x.ClinicStaffLeaveReplace).HasForeignKey(x => x.ReplacedById)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

    }
}

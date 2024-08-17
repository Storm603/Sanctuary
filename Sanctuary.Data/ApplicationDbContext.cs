using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Common.Models;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.Configurable;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Models.PicturesTables;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data
{
    public class ApplicationDbContext : IdentityDbContext<BaseApplicationUser, ApplicationRole, string>
    {
        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder) where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaseApplicationUser> BaseUser { get; set; } = null!;
        public DbSet<ClientUser> ClientUsers { get; set; } = null!;
        public DbSet<ClinicStaffUser> ClinicStaffUsers { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<MedicalLog> MedicalLogs { get; set; } = null!;
        public DbSet<Breed> Breeds { get; set; } = null!;
        public DbSet<Allergies> Allergies { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<PromoCodes> PromoCodes { get; set; } = null!;
        public DbSet<PetHotel> PetHotel { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<HospitalizedPets> HospitalizedPets { get; set; } = null!;
        public DbSet<ClinicServices> ClinicServices { get; set; } = null!;
        public DbSet<Clinic> Clinics { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Medicine> Medicines { get; set; } = null!;
        public DbSet<AbsenceType> AbsenceType { get; set; } = null!;
        public DbSet<PostalCodesCoordinates> PostalCodes { get; set; } = null!;
        public DbSet<ImageStorage> Images { get; set; } = null!;


        public DbSet<Setting> Settings { get; set; } = null!;

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(nameof(SetIsDeletedQueryFilter), BindingFlags.NonPublic | BindingFlags.Static)!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            this.ConfigureModelRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes.Where(et =>
                et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));

            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(builder, new object[] { builder });
            }

            //Disable cascade delete
            var foreignKeys = entityTypes.SelectMany(e =>
                e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        // Applying model Configurations from this. assembly IEntityTypeConfiguration
        private void ConfigureModelRelations(ModelBuilder builder) =>
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntities = this.ChangeTracker.Entries().Where(e =>
                e.Entity is IAuditInfo && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntities)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}

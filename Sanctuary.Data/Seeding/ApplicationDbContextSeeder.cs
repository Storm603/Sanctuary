using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sanctuary.Data.Seeding
{
    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>()!.CreateLogger(typeof(ApplicationDbContext));

            try
            {
                var seeders = new List<ISeeder>
                {
                    new RolesSeeder(),
                    new SettingsSeeder(),
                    new PostalCodesSeeder(),
                    new GeneralInformationSeeder(),
                    new PhotoSeeder(),
                    new AppointmentSeeder(),
                };

                foreach (var seeder in seeders)
                {
                    await seeder.SeedAsync(context, serviceProvider);
                    await context.SaveChangesAsync();
                    logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

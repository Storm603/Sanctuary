using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;

namespace Sanctuary.Data.Repositories
{
    public class ClinicRepository<TEntity> : IClinicRepository<TEntity> where TEntity : Clinic
    {
        private ApplicationDbContext Context;
        private DbSet<TEntity> DbSet;
        public ClinicRepository(ApplicationDbContext injContext)
        {
            Context = injContext;
            this.DbSet = this.Context.Set<TEntity>();
        }

    }
}

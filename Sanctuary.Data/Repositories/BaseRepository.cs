using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Control.ControlContracts;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Data;

namespace Sanctuary.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<TEntity> DbSet { get; }

        protected BaseRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        public virtual Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

        public virtual IQueryable<TEntity> All() => DbSet;

        public virtual IQueryable<TEntity> AllAsNoTracking() => DbSet.AsNoTracking();

        public void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public virtual Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed state(managed objects from the GC) only
                this.Context?.Dispose();
                // or SafeHandle Dispose implementation call
            }
        }
    }
}

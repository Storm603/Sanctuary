using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IDeletableEntityRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class/*, IDeletableEntity*/
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}

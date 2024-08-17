using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Repositories.RepositoriesContracts;

namespace Sanctuary.Data.Factories
{
    public abstract class RepositoryFactory
    {
        public static TRepository GetRepositoryInstance<TRepository, TEntity>(params object[] instantiations)
            where TRepository : IBaseRepository<TEntity> where TEntity : class
        {
            return (TRepository)Activator.CreateInstance(typeof(TRepository), instantiations)!;
        }
    }
}

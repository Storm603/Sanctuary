using System.Data;
using System.Data.Entity.Validation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Control.ControlContracts;
using Sanctuary.Data.Factories;
using Sanctuary.Data.Repositories.RepositoriesContracts;

namespace Sanctuary.Data.Control
{
    public class TransactionalManagementUoW<TRepository, TEntity> : ITransactionalManagementUoW<TRepository, TEntity> where TRepository : IBaseRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext Context { get; }
        private string _errorMessage = string.Empty;
        private SqlTransaction? _dbTransaction;
        private SqlConnection? _dbConnection;
        private bool _disposed;
        public TRepository Repository { get; }


        public TransactionalManagementUoW(ApplicationDbContext context)
        {
            this.Context = context;
            Repository = RepositoryFactory.GetRepositoryInstance<TRepository, TEntity>(context);
        }

        public async void CreateTransaction(SqlCommand? command = null, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _dbConnection = Context.Database.GetDbConnection() as SqlConnection;
            await _dbConnection!.OpenAsync();

            _dbTransaction =  _dbConnection.BeginTransaction();

            if (command != null)
            {
                command.Connection = _dbConnection;
                command.Transaction = _dbTransaction;
            }
        }

        public void Commit()
        {
            _dbTransaction?.Commit();
        }

        public void Rollback()
        {
            _dbTransaction?.Rollback();
            _dbTransaction?.Dispose();
        }

        public void Save()
        {
            try
            {
                this.Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage = _errorMessage +
                                        $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage} {Environment.NewLine}";
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Repository.Dispose();
                }
            }
            _disposed = true;
        }
    }
}

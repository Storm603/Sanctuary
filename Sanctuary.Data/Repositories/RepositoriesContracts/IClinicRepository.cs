using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IClinicRepository<TEntity> where TEntity : Clinic
    {
    }
}

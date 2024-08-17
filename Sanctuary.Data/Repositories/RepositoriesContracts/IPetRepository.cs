using Sanctuary.Data.Models.PetTables;
using Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IPetRepository<TEntity> where TEntity : Pet
    {
        Task<List<PetDTO>> GetAllPetsOwnedByRegisteredUserByUserId(string userId);
    }
}

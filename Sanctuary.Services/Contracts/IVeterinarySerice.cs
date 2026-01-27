using Sanctuary.Services.Data.Services.DTOs.VeterinarianDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Services.Contracts
{
    public interface IVeterinarySerice
    {
        public Task<List<VeterinariansByRoleDTO>?> GetVeterinariansByWorkPositionInClinic(string veterinarianWorkPosition, string clinicName);
    }
}

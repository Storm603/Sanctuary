using Sanctuary.Services.Data.Services.DTOs.VeterinarianDTOs;
using Sanctuary.Web.ViewModels.AppointmentCreationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Services.Contracts
{
    public interface IUserService
    {
        Task<List<VeterinariansByRoleDTO>?> GetVeterinariansByWorkPositionInClinic(string veterinarianWorkPosition, string clinicId);
    }
}

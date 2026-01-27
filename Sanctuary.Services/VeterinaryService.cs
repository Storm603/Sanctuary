using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Contracts;
using Sanctuary.Services.Data.Services.DTOs.VeterinarianDTOs;

namespace Sanctuary.Services
{
    public class VeterinaryService : IVeterinarySerice
    {
        private IVeterinaryRepository<ClinicStaffUser> vetRepository;
        public VeterinaryService(IVeterinaryRepository<ClinicStaffUser> injVetRepository)
        {
            vetRepository = injVetRepository;
        }

        public async Task<List<VeterinariansByRoleDTO>?> GetVeterinariansByWorkPositionInClinic(string veterinarianWorkPosition, string clinicName)
        {
            var vetsByWorkPosition = await vetRepository.GetAllVeterinariansByUserRoleAndClinicId(veterinarianWorkPosition, clinicName);

            if (vetsByWorkPosition.Count == 0)
            {
                return null;
            }

            var dtoFiltering = new List<VeterinariansByRoleDTO>();

            //foreach (var vet in vetsByWorkPosition)
            //{
            //    dtoFiltering.Add(new VeterinariansByRoleDTO()
            //    {
            //        FirstName = vet.BaseUser.FirstName,
            //        LastName = vet.LastName,
            //        RoleName = veterinarianWorkPosition,
            //        Email = vet.Email,
            //        PhoneNumber = vet.PhoneNumber,
            //        ClinicName = clinicName,
            //        ImageId = vet.RelatedPictures.Where(x => x.IsProfilePicture).Select(x => x.Id.ToString()).FirstOrDefault(),
            //    });
            //}

            return dtoFiltering;
        }
    }
}

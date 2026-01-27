using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Contracts;
using Sanctuary.Services.Data.Services.DTOs.VeterinarianDTOs;
using Sanctuary.Web.ViewModels.AppointmentCreationViewModels;

namespace Sanctuary.Services
{
    public class UserService : IUserService
    {
        private IUserRepository<BaseApplicationUser> UserRepository;

        public UserService(IUserRepository<BaseApplicationUser> injUserRepository)
        {
            UserRepository = injUserRepository;
        }

    }
}

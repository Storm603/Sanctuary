using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Contracts;
using Sanctuary.Web.ViewModels;
using Sanctuary.Web.ViewModels.AppointmentCreationViewModels;

namespace Sanctuary.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IPetRepository<Pet> PetRepository;
        private IUserRepository<BaseApplicationUser> UserRepository;
        private IAppointmentRepository<Appointment> AppointmentRepository;
        public AppointmentService(IPetRepository<Pet> injPetRepository, IUserRepository<BaseApplicationUser> injUserRepository, IAppointmentRepository<Appointment> injAppRepository)
        {
            PetRepository = injPetRepository;
            UserRepository = injUserRepository;
            AppointmentRepository = injAppRepository;
        }

        public async Task<AppointmentSubmissionViewModel> AppointmentViewModelRenderingForRegisteredUser(string userID, AppointmentGeneralInformationViewModel model)
        {
            var listOfUserPets = await PetRepository.GetAllPetsOwnedByRegisteredUserByUserId(userID);

            var listOfClinicVets = await UserRepository.GetAllVeterinariansByClinicName(model.ClinicName);

            var completedModel = new AppointmentSubmissionViewModel()
            {
                AppointmentType = model.AppointmentType,
                ClinicName = model.ClinicName,
                OwnedPets = listOfUserPets,
                ClinicVets = listOfClinicVets
            };

            return completedModel;
        }


        // API Method
        public async Task<string> GetAppointmentTimeFramesByDayAndVet(string day, string vetId)
        {
            var resultSet = await AppointmentRepository.GetTimeFramesOfAllAppointmentsInDayByVetId(int.Parse(day), vetId);

            // Item 1 holds start time, Item 2 holds how many elements to be taken on GUI
            var refinedData = new List<Tuple<TimeOnly, int>>();

            // Item 2 holds end time of time, Item 1 holds start time
            foreach (var tupleItem in resultSet)
            {
                var timeSpanMinutes = tupleItem.Item2 - tupleItem.Item1;

                refinedData.Add(new Tuple<TimeOnly, int>(tupleItem.Item1, timeSpanMinutes.Minutes / 5));
            }
            
            
            return JsonConvert.SerializeObject(refinedData);
        }
    }
}

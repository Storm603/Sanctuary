using Sanctuary.Web.ViewModels;
using Sanctuary.Web.ViewModels.AppointmentCreationViewModels;


namespace Sanctuary.Services.Contracts
{
    public interface IAppointmentService
    {
        Task<AppointmentSubmissionViewModel> AppointmentViewModelRenderingForRegisteredUser(string userID, AppointmentGeneralInformationViewModel model);
        Task<string> GetAppointmentTimeFramesByDayAndVet(string day, string vetId);

    }
}

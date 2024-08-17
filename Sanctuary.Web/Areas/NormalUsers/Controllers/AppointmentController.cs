using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Common;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Services.Contracts;
using Sanctuary.Web.ViewModels;
using Sanctuary.Web.ViewModels.AppointmentCreationViewModels;
using System;
using System.Security.Claims;

namespace Sanctuary.Web.Areas.NormalUsers.Controllers
{
    [Authorize(Roles = (ExistingIdentityRolesConstants.UserRoleName))]
    public class AppointmentController : Controller
    {
        public IImageService ImageService { get; set; }
        public IUserService UserService { get; set; }
        public UserManager<BaseApplicationUser> UserManager { get; set; }
        public IDataProtector DataEnc { get; set; }
        public IAppointmentService AppointmentService { get; set; }

        public AppointmentController(IImageService injService, IUserService injUserService, UserManager<BaseApplicationUser> injUManager, IDataProtectionProvider injDataEnc, IAppointmentService injAppointmentService)
        {
            ImageService = injService;
            UserService = injUserService;
            UserManager = injUManager;
            AppointmentService = injAppointmentService;
            DataEnc = injDataEnc.CreateProtector("Areas.Normalusers.Appointment");
        }

        [HttpGet]
        [Area("NormalUsers")]
        public IActionResult AppointmentSelectLocation()
        {
            return View("/Areas/NormalUsers/Views/Appointment/AppointmentBranchSelection.cshtml");
        }

        [HttpGet]
        [Area("NormalUsers")]
        public IActionResult AppointmentDetails([FromQuery]string clinicName)
        {
            ViewData["ClinicName"] = clinicName;

            return View("/Areas/NormalUsers/Views/Appointment/AppointmentGeneralChoice.cshtml");
        }

        [HttpPost]
        [Area("NormalUsers")]
        public async Task<IActionResult> AppointmentDetails(AppointmentGeneralInformationViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var completeModel = await AppointmentService.AppointmentViewModelRenderingForRegisteredUser(userId, model);
            
            return View("/Areas/NormalUsers/Views/Appointment/AppointmentSubmission.cshtml", completeModel);
        }

        [HttpPost]
        [Area("NormalUsers")]
        public async Task<IActionResult> AppointmentSubmission([FromForm]SubmittedAppointmentViewModel model)
        {
            var time = DateTime.Now.ToUniversalTime;
            ;
            TimeOnly times = new TimeOnly();
            return View("/Areas/NormalUsers/Views/Appointment/apptest.cshtml");
        }
    }
}

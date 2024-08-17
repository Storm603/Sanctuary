using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sanctuary.Services.Contracts;

namespace Sanctuary.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService injAppointmentService)
        {
            this.appointmentService = injAppointmentService;
        }

        [HttpGet]
        [Route("/[action]")]
        [EnableCors("Sanctuary.Web")]
        public async Task<IActionResult> GetAppointmentTimeFrames([FromHeader] string day, [FromHeader] string vetId)
        {
            string resultSet = await appointmentService.GetAppointmentTimeFramesByDayAndVet(day, vetId);

            return Ok(resultSet);
        }
    }
}

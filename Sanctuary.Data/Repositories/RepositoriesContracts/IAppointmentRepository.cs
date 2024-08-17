using Sanctuary.Data.Models.ClinicTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IAppointmentRepository<TAppointment> : IBaseRepository<TAppointment> where TAppointment : Appointment
    {
        Task<List<Tuple<TimeOnly, TimeOnly>>> GetTimeFramesOfAllAppointmentsInDayByVetId(int day, string vetId);
    }
}

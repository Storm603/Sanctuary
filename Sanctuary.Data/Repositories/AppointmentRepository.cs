using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;

namespace Sanctuary.Data.Repositories
{
    public class AppointmentRepository<TAppointment> : BaseRepository<TAppointment>, IAppointmentRepository<TAppointment> where TAppointment : Appointment
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context) {}
        
        // Gets all from-to time frames for the specified day for the specified vet
        // vetid is DB Model "ClinicStaffUser" not BaseApplicationUser
        public async Task<List<Tuple<TimeOnly, TimeOnly>>> GetTimeFramesOfAllAppointmentsInDayByVetId(int day, string vetId)
        {
            //vetId = "c1f4eece-e448-40a6-8ce0-b2d7e823c7c5";

            var resultSet = await DbSet.Where(x => x.DoctorId == vetId && x.TimeOfAppointmentFrom.Day == day).OrderBy(x => x.TimeOfAppointmentFrom).Select(x => new Tuple<TimeOnly, TimeOnly>(TimeOnly.FromDateTime(x.TimeOfAppointmentFrom), TimeOnly.FromDateTime(x.TimeOfAppointmentTo))).ToListAsync();

            return resultSet;
        }
    }
}
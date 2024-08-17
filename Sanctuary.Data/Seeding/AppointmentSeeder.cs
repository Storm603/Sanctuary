using Sanctuary.Data.Models.ClinicTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Seeding
{
    internal class AppointmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            await SeedAppointmentsAsync(dbContext);
        }

        private async Task SeedAppointmentsAsync(ApplicationDbContext dbContext)
        {
            var date = DateTime.Now;

            var pet1 = dbContext.Pets.Where(x => x.Id == Guid.Parse("0eb8bcae-c1e7-41e4-8b4a-8646ef40dfa4")).FirstOrDefault();
            var pet2 = dbContext.Pets.Where(x => x.Id == Guid.Parse("ce19863b-ae5c-4f51-ab03-32dcf282b0cf")).FirstOrDefault();
            var pet3 = dbContext.Pets.Where(x => x.Id == Guid.Parse("1f33e4d9-7b5d-421c-9b74-fc737973f48e")).FirstOrDefault();
            var pet4 = dbContext.Pets.Where(x => x.Id == Guid.Parse("ed14f8d7-43d4-4958-b94f-95cffaa19f3c")).FirstOrDefault();
            var pet5 = dbContext.Pets.Where(x => x.Id == Guid.Parse("5970d47d-5892-482e-9beb-01020e519592")).FirstOrDefault();
            
            List<Appointment> appointments = new List<Appointment>() {
            new Appointment()
            {
                Id = Guid.Parse("bfdf522d-c973-4cf2-a9d5-62b3cdb0ca08"),
                AppointmentNumber = "gibberish1",
                DoctorId = "c1f4eece-e448-40a6-8ce0-b2d7e823c7c5",
                ClientId = "c6482797-412d-451d-aab9-cf3d1ac39a39",
                Reason = "kjlashdfgfaujihsld",
                TimeOfAppointmentFrom = new DateTime(date.Year, date.Month, date.Day, 08, 00, 00),
                TimeOfAppointmentTo = new DateTime(date.Year, date.Month, date.Day, 08, 15, 00)
                
            },
            new Appointment()
            {
                Id = Guid.Parse("cbf8d98c-e7e6-4056-a5f4-555dd60517c5"),
                AppointmentNumber = "gibberish2",
                DoctorId = "c1f4eece-e448-40a6-8ce0-b2d7e823c7c5",
                ClientId = "1146fc2b-09cd-424e-a2d8-20e8e1836731",
                Reason = "kjlashdfgfaujihsld",
                TimeOfAppointmentFrom = new DateTime(date.Year, date.Month, date.Day, 09, 15, 00),
                TimeOfAppointmentTo = new DateTime(date.Year, date.Month, date.Day, 09, 30, 00)
            },
            new Appointment()
            {
                Id = Guid.Parse("c570a0d9-0a51-4fbf-b85e-a351643c20fa"),
                AppointmentNumber = "gibberish3",
                DoctorId = "c1f4eece-e448-40a6-8ce0-b2d7e823c7c5",
                ClientId = "30b0a024-61d0-4a17-b610-231df2b6c560",
                Reason = "kjlashdfgfaujihsld",
                TimeOfAppointmentFrom = new DateTime(date.Year, date.Month, date.Day, 09, 40, 00),
                TimeOfAppointmentTo = new DateTime(date.Year, date.Month, date.Day, 10, 00, 00)
            },
            new Appointment()
            {
                Id = Guid.Parse("8befe515-9152-400a-a678-7e53747008f2"),
                AppointmentNumber = "gibberish4",
                DoctorId = "c1f4eece-e448-40a6-8ce0-b2d7e823c7c5",
                ClientId = "ab3012dd-3e21-4a69-92ef-a21983868159",
                Reason = "kjlashdfgfaujihsld",
                TimeOfAppointmentFrom = new DateTime(date.Year, date.Month, date.Day, 13, 40, 00),
                TimeOfAppointmentTo = new DateTime(date.Year, date.Month, date.Day, 14, 00, 00)
            },
            new Appointment()
            {
                Id = Guid.Parse("eb71174d-c5d7-4f0c-835d-0437503e2236"),
                AppointmentNumber = "gibberish5",
                DoctorId = "c1f4eece-e448-40a6-8ce0-b2d7e823c7c5",
                ClientId = "3e76e2bf-f936-4106-90f4-60a411a346e9",
                Reason = "kjlashdfgfaujihsld",
                TimeOfAppointmentFrom = new DateTime(date.Year, date.Month, date.Day, 14, 30, 00),
                TimeOfAppointmentTo = new DateTime(date.Year, date.Month, date.Day, 15, 00, 00)
            },
        };

            appointments[0].Pets.Add(pet1);
            appointments[1].Pets.Add(pet2);
            appointments[2].Pets.Add(pet3);
            appointments[3].Pets.Add(pet4);
            appointments[4].Pets.Add(pet5);

            await dbContext.Appointments.AddRangeAsync(appointments);

            //await dbContext.SaveChangesAsync();

            //var appointments0 = dbContext.Appointments.Where(x => x.Id == Guid.Parse("bfdf522d-c973-4cf2-a9d5-62b3cdb0ca08")).FirstOrDefault();
            //var appointments1 = dbContext.Appointments.Where(x => x.Id == Guid.Parse("cbf8d98c-e7e6-4056-a5f4-555dd60517c5")).FirstOrDefault();
            //var appointments2 = dbContext.Appointments.Where(x => x.Id == Guid.Parse("c570a0d9-0a51-4fbf-b85e-a351643c20fa")).FirstOrDefault();
            //var appointments3 = dbContext.Appointments.Where(x => x.Id == Guid.Parse("8befe515-9152-400a-a678-7e53747008f2")).FirstOrDefault();
            //var appointments4 = dbContext.Appointments.Where(x => x.Id == Guid.Parse("eb71174d-c5d7-4f0c-835d-0437503e2236")).FirstOrDefault();

            //appointments0!.Pets.Add(pet1!);
            //appointments1!.Pets.Add(pet2!);
            //appointments2!.Pets.Add(pet3!);
            //appointments3!.Pets.Add(pet4!);
            //appointments4!.Pets.Add(pet5!);

            await dbContext.SaveChangesAsync();
        }
    }
}
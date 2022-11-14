using Sanctuary.Data.Models.UserTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.ClinicTables;

namespace Sanctuary.Data.Models.LocationTables
{
    public class MT_Clinic_Addresses
    {
        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public Clinic? Clinic { get; set; }


        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Address? Address { get; set; }
    }
}

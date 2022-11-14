using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.LocationTables
{
    public class MT_User_Addresses
    {
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public BaseApplicationUser User { get; set; } = null!;


        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))] 
        public Address Address { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.LocationTables
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public int PostalCode { get; set; }
        public string Disctrict { get; set; }
        public string StreetName { get; set; }
        public float? lon { get; set; }
        public float? lat { get; set; }
    }
}

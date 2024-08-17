using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sanctuary.Services.Data.Services.API.DTO
{
    public class DetailedAddressDTO
    {
        [JsonPropertyName("ClinicName")] 
        public string ClinicName { get; set; } = null!;

        [JsonPropertyName("StreetName")]
        public string StreetName { get; set; } = null!;

        [JsonPropertyName("District")]
        public string? District { get; set; }

        [JsonPropertyName("Town")]
        public string Town { get; set; } = null!;

        [JsonPropertyName("PostalCode")] 
        public string Zip { get; set; } = null!;

        [JsonPropertyName("Country")]
        public string Country { get; set; } = null!;

        [JsonPropertyName("lat")]
        public double lat { get; set; }
        [JsonPropertyName("lon")]
        public double lon { get; set; }
    }
}

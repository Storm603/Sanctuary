using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sanctuary.Services.Data.Services.API.DTO
{
    public class ZipCoordinatesDTO
    {
        [JsonPropertyName("PostalCode")] 
        public string PostalCode { get; set; } = null!;
        [JsonPropertyName("lat")]
        public double lat { get; set; }
        [JsonPropertyName("lon")]
        public double lon { get; set; }
    }
}

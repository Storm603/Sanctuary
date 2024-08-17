using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sanctuary.Services.Data.Services.API.DTO
{
    public class CoordinatesDTO
    {

        [JsonPropertyName("lat")] public double lat { get; set; }
        [JsonPropertyName("lon")] public double lng { get; set; } 
    }
}

﻿using System.Text.Json.Serialization;

namespace Sanctuary.Web.Views.ViewModels.APIViewModels
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
    }
}

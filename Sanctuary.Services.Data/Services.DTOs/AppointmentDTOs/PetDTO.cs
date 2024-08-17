using Sanctuary.Data.Models.PetTables;

namespace Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs
{
    public class PetDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char? Sex { get; set; }
        public float? Weight { get; set; }
        public string? EyeColour { get; set; }
        public string? FurColour { get; set; }
        public bool? Microchip { get; set; }
        public string? PictureId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.PetTables
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Breed Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Sex { get; set; }
        public float Weight { get; set; }
        public string EyeColor { get; set; }
        public string FurColor { get; set; }
        public bool Microchip { get; set; }
        public string Description { get; set; }


        public List<Allergies> Allergies = new List<Allergies>();


        public List<MedicalLog> MedicalLogs { get; set; }


        public string ClientUserId { get; set; }
        [ForeignKey(nameof(ClientUserId))]
        public ClientUser ClientUser { get; set; }
    }
}

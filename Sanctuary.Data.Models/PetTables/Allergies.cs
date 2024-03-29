﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Models.PetTables
{
    public class Allergies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Type { get; set; }

        [Range(0, 5)]
        public int Severity { get; set; }

        [Required]
        public Guid PetId { get; set; }
        [ForeignKey(nameof(PetId))]
        public Pet Pet { get; set; }
    }
}

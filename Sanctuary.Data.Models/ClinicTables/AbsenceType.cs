﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class AbsenceType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(15)] 
        public string Type { get; set; } = null!;
    }
}

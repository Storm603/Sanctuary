﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class ClinicStaffLeave
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BeginDate { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
            
        [Required] 
        public virtual AbsenceType AbsenceType { get; set; } = null!;

        [Required]
        [Range(1, 64)]
        public int Days { get; set; }


        [StringLength(200, MinimumLength = 0)] 
        public string Description { get; set; } = null!;

        [Required]
        public bool Approved { get; set; }


        [Required] 
        public string RequestedById { get; set; } = null!;
        [ForeignKey(nameof(RequestedById))] 
        public virtual ClinicStaffUser RequestedBy { get; set; } = null!;



        public string? ReplacedById { get; set; }
        [ForeignKey(nameof(ReplacedById))]
        public virtual ClinicStaffUser? ReplacedBy { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Models
{
    [Table("CGI_Inspection_D")]
    public partial class InspectionD
    {
        [Key]
        public short IdClientId { get; set; }
        [Key]
        public short IdVendorId { get; set; }
        [Key]
        public short IdDepotId { get; set; }
        [Key]
        public string IdInspectionRefNmbr { get; set; }
        [Key]
        public short IdLineNmbr { get; set; }
        public short? IdRepairWhyMade { get; set; }
        public int IdRepairCode { get; set; }
        public short IdRepairCodeSched { get; set; }
        public string IdRepairLocation { get; set; }
    }
}

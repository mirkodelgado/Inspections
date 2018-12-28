using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Dtos
{
    public partial class InspectionDDto
    {
        //public string IdInspectionRefNmbr { get; set; }
        public short IdLineNmbr { get; set; }
        public short? IdRepairWhyMade { get; set; }
        public int IdRepairCode { get; set; }
        public short IdRepairCodeSched { get; set; }
        public string IdRepairLocation { get; set; }
    }
}

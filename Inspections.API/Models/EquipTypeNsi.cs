using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Models
{
    [Table("DMS_GateEquipmentNSIType")]
    public partial class EquipTypeNsi
    {
        [Key]
        public short EtnCode { get; set; }
        public string EtnDescription { get; set; }
        public string EtnShortName { get; set; }
    }
}

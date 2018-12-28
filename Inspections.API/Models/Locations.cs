using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Models
{
    [Table("CGI_Locations")]
    public partial class Locations
    {
        [Key]
        public short LgClientId { get; set; }

        [Key]
        public short LgBillToCid { get; set; }

        [Key]
        public string LgGroupId { get; set; }

        [Key]
        public short LgRepairCategory { get; set; }
        
        [Key]
        public string LgLocationNmbr { get; set; }
        public string LgLocationAlpha { get; set; }
        public string LgLocationIso { get; set; }
    }
}

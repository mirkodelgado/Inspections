using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Dtos
{
    public partial class LocationsDto
    {
        public short LgRepairCategory { get; set; }
        
        public string LgLocationNmbr { get; set; }
        public string LgLocationAlpha { get; set; }
    }
}

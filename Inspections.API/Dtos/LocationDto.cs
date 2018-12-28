using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Dtos
{
    [Table("CGI_Location")]
    public partial class LocationDto
    {
        //public short DptClientId { get; set; }
        //public short DptVendorId { get; set; }
        //public short DptDepotId { get; set; }
        //public short DptBillToClientId { get; set; }
        //public string DptSystemName { get; set; }
        public string DptName { get; set; }
        public string DptAddress1 { get; set; }
    }
}

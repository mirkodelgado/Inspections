using System;
using System.Collections.Generic;

namespace Inspections.API.Models
{
    public partial class Facility
    {
        public short VClientId { get; set; }
        public short VVendorId { get; set; }
        public string VName { get; set; }
        public string VAddress1 { get; set; }
        public string VAddress2 { get; set; }
        public string VAddress3 { get; set; }
        public string VCity { get; set; }
        public string VState { get; set; }
        public string VZipCode { get; set; }
        public string VPhone { get; set; }
        public string VPhoneExt { get; set; }
        public string VFax { get; set; }
        public string VContact { get; set; }
        public string VMemo { get; set; }
        public string VEdierrorEmail { get; set; }
    }
}

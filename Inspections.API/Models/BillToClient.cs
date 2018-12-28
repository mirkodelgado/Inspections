using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Models
{
    [Table("CGI_BillToClient")]
    public partial class BillToClient
    {
        [Key]
        public short BtcBilltoClientId { get; set; }
        public string BtcBillToClientName { get; set; }
        public string BtcBillToClientShortName { get; set; }
        public string BtcXmlclientCode { get; set; }
        public string BtcGateXmlclientCode { get; set; }
        public string BtcAllowIschassis { get; set; }
        public string BtcAllowIsdryBox { get; set; }
        public string BtcAllowIsreefer { get; set; }
        public string BtcAllowIsgenset { get; set; }
        public string BtcAllowOhchassis { get; set; }
        public string BtcAllowOhdryBox { get; set; }
        public string BtcAllowOhreefer { get; set; }
        public string BtcAllowOhgenset { get; set; }
        public string BtcHhshowFhwaauth { get; set; }
        public string BtcHhshowLaborRate { get; set; }
        public string BtcHhshowTireData { get; set; }
        public string BtcHhshowVesselVoyage { get; set; }
        public string BtcHhshowDvir { get; set; }
        public string BtcCcmpoolClient { get; set; }
        public short? BtcTariffId { get; set; }
        public short? BtcInspectionTariffId { get; set; }
        public short? BtcTier { get; set; }
        public short? BtcHhauditRequired { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Models
{
    [Table("CGI_Inspection_M")]
    public partial class InspectionM
    {
        public short ImClientId { get; set; }
        
        [ForeignKey("ImClientId, ImVendorId, ImDepotId, ImBillToCid")]
        public virtual Location Depot { get; set; }

        public short ImVendorId { get; set; }
        public short ImDepotId { get; set; }
        public string ImInspectionRefNmbr { get; set; }

        //[ForeignKey("ImClientId, ImVendorId, ImDepotId, ImInspectionRefNmbr")]
        //public virtual ICollection<InspectionD> InspectionD { get; set; }

        public short ImTariffId { get; set; }
        public string ImIssuedById { get; set; }
        public DateTime ImInspectionDate { get; set; }

        [ForeignKey("ImEquipTypeNsi")]
        public virtual EquipTypeNsi EquipmentType { get; set; }

        [Column("ImEquipType_Nsi")]
        public short? ImEquipTypeNsi { get; set; }
        public int? ImEquipCount { get; set; }
        public string ImEquip1Id { get; set; }
        public string ImEquip1Size { get; set; }
        public string ImRelatedEquipId { get; set; }
        public string ImMemo { get; set; }

        [ForeignKey("ImBillToCid")]
        public virtual BillToClient BillToClient { get; set; }

        public short? ImBillToCid { get; set; }
        public short? ImBillToVid { get; set; }
        public short? ImBillToDid { get; set; }
        public string ImHandHeldEstimate { get; set; }
        public string ImHandHeldSerialNmbr { get; set; }
        public string ImFmcsadate { get; set; }
        public DateTime ImTimeStamp { get; set; }
        public string ImCleanInspection { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Dtos
{
    public partial class InspectionMDto
    {
        public short ImClientId { get; set; }
        public short ImVendorId { get; set; }
        public short ImDepotId { get; set; }
        public string ImInspectionRefNmbr { get; set; }
        //public short ImTariffId { get; set; }
        //public string ImIssuedById { get; set; }
        public DateTime? ImInspectionDate { get; set; }
        //public short? ImEquipTypeNsi { get; set; }
        //public int? ImEquipCount { get; set; }
        public string ImEquip1Id { get; set; }
        //public string ImEquip1Size { get; set; }
        //public string ImRelatedEquipId { get; set; }
        //public string ImMemo { get; set; }

        public short? ImBillToCid { get; set; }
        //public short? ImBillToVid { get; set; }
        //public short? ImBillToDid { get; set; }
        public string ImFmcsadate { get; set; }
        //public DateTime ImTimeStamp { get; set; }
        public string ImCleanInspection { get; set; }
    }
}

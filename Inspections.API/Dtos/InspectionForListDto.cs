using System;
using Inspections.API.Models;

namespace Inspections.API.Dtos
{
    public class InspectionForListDto
    {
        public string ImInspectionRefNmbr { get; set; }
        public DateTime? ImInspectionDate { get; set; }
        public string ImEquip1Id { get; set; }

        public BillToClientDto BillToClient { get; set; }

        public LocationDto Depot;

        public EquipTypeNsi EquipmentType;

        //public DateTime ImTimeStamp { get; set; }

        public string ImCleanInspection { get; set; }
     }
}
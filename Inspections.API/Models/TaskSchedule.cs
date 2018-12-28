using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Models
{
    [Table("CGI_TaskSchedule")]
    public partial class TaskSchedule
    {
        [Key]
        public int TsTaskCode { get; set; }
        public short? TsTaskCategory { get; set; }
        public int? TsTaskCodeOldSystem { get; set; }
        public string TsActive { get; set; }
        public string TsPrint { get; set; }
        public DateTime? TsLastUpdate { get; set; }
        public decimal? TsHours { get; set; }
        public decimal? TsFlatRate { get; set; }
        public string TsCalculation { get; set; }
        public decimal? TsLevel1Qty { get; set; }
        public decimal? TsLevel1Hours { get; set; }
        public decimal? TsLevel2Qty { get; set; }
        public decimal? TsLevel2Hours { get; set; }
        public decimal? TsLevel3Qty { get; set; }
        public decimal? TsLevel3Hours { get; set; }
        public short? TsBidTask { get; set; }

        [Column("TsYml_Iso_Component")]
        public string TsYmlIsoComponent { get; set; }

        [Column("TsYml_Iso_Repair")]
        public string TsYmlIsoRepair { get; set; }

        [Column("TsYml_Iso_Damage")]
        public string TsYmlIsoDamage { get; set; }

        [Column("TsIso_Component")]
        public string TsIsoComponent { get; set; }

        [Column("TsIso_Location")]
        public string TsIsoLocation { get; set; }

        [Column("TsIso_Damage")]
        public string TsIsoDamage { get; set; }

        [Column("TsIso_Material")]
        public string TsIsoMaterial { get; set; }

        [Column("TsIso_Repair")]
        public string TsIsoRepair { get; set; }

        [Column("TsNyk_PartCode")]
        public string TsNykPartCode { get; set; }

        [Column("TsNyk_RepairCode")]
        public string TsNykRepairCode { get; set; }

        [Column("TsNyk_OscarCode")]
        public string TsNykOscarCode { get; set; }

        [Column("TsHyn_AccountingCode")]
        public short? TsHynAccountingCode { get; set; }

        [Column("TsCma_AccountingCode")]
        public string TsCmaAccountingCode { get; set; }
        public string TsTaskDescription { get; set; }
        public string TsShortTaskDescription { get; set; }
        public string TsYtidescription { get; set; }
        public string TsMercPlusRepairCode { get; set; }
        public string TsAarjobCode { get; set; }
        public string TsAarconditionCode { get; set; }
        public string TsAardescription { get; set; }
        public decimal? TsAarhours { get; set; }

        [Column("TsSc_Iso_Component")]
        public string TsScIsoComponent { get; set; }

        [Column("TsSc_Iso_Location")]
        public string TsScIsoLocation { get; set; }

        [Column("TsSc_Iso_Material")]
        public string TsScIsoMaterial { get; set; }

        [Column("TsSc_Iso_Repair")]
        public string TsScIsoRepair { get; set; }
        public string TsDamageRecovery { get; set; }
        public string TsPositionGroup { get; set; }
        public string TsYmadeGroup { get; set; }
        public short? TsBypassOnOtherEstimate { get; set; }
        public string TsNykvesselVoyageRequired { get; set; }
        public short? TsDmsClientId { get; set; }
        public string TsSerialNmbrsRequired { get; set; }
        public short? TsRecoveryCategory { get; set; }
        public decimal? TsCalc1Qty { get; set; }
        public decimal? TsCalc1Hrs { get; set; }
        public decimal? TsCalc1Max { get; set; }
        public decimal? TsCalc2Qty { get; set; }
        public decimal? TsCalc2Hrs { get; set; }
        public decimal? TsCalc2Max { get; set; }
        public decimal? TsCalc3Qty { get; set; }
        public decimal? TsCalc3Hrs { get; set; }
        public decimal? TsCalc3Max { get; set; }
        public decimal? TsCalc4Qty { get; set; }
        public decimal? TsCalc4Hrs { get; set; }
        public decimal? TsCalc4Max { get; set; }
        public decimal? TsCalc5Qty { get; set; }
        public decimal? TsCalc5Hrs { get; set; }
        public decimal? TsCalc5Max { get; set; }
        public decimal? TsCalc6Qty { get; set; }
        public decimal? TsCalc6Hrs { get; set; }
        public decimal? TsCalc6Max { get; set; }
        public string TsMultiLocation { get; set; }
        public decimal? TsLevel1Matl { get; set; }
        public decimal? TsLevel2Matl { get; set; }
        public decimal? TsLevel3Matl { get; set; }
        public int? TsMaxSize { get; set; }
        public string TsTaskPartQty { get; set; }
        public decimal? TsRehours { get; set; }
        public decimal? TsProductionHrs { get; set; }
    }
}

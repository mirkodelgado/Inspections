using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Models
{
    [Table("CGI_Location")]
    public partial class Location
    {
        public short DptClientId { get; set; }
        public short DptVendorId { get; set; }
        public short DptDepotId { get; set; }
        public short DptBillToClientId { get; set; }
        public short? DptBillToVendorId { get; set; }
        public short? DptBillToDepotId { get; set; }
        public short? DptGlobalRegion { get; set; }
        public string DptIsosenderId { get; set; }
        public string DptScheduleDportCode { get; set; }
        public string DptSystemName { get; set; }
        public string DptName { get; set; }
        public string DptAddress1 { get; set; }
        public string DptAddress2 { get; set; }
        public string DptAddress3 { get; set; }
        public string DptCity { get; set; }
        public string DptState { get; set; }
        public string DptZipCode { get; set; }
        public string DptContact { get; set; }
        public string DptPhone { get; set; }
        public string DptPhoneExt { get; set; }
        public string DptFax { get; set; }
        
        [Column("DptTir_Required")]
        public string DptTirRequired { get; set; }
        public string DptNewportGetsTir { get; set; }
        public decimal? DptTaxRate { get; set; }
        public string DptTaxChassisLabor { get; set; }
        public string DptTaxChassisParts { get; set; }
        public string DptTaxCntrLabor { get; set; }
        public string DptTaxCntrParts { get; set; }
        public string DptTaxGenSetLabor { get; set; }
        public string DptTaxGenSetParts { get; set; }
        public string DptOnlyTaxLaborIfParts { get; set; }
        public decimal? DptAutoLimitChassis { get; set; }
        public decimal? DptAutoLimitDryCntr { get; set; }
        public decimal? DptAutoLimitReefer { get; set; }
        public decimal? DptAutoLimitGenSet { get; set; }
        public decimal? DptAutoLimitVesselOps { get; set; }
        public decimal? DptAutoLimitTank { get; set; }
        public string DptLockTaskTime { get; set; }
        public string DptLockCcpartPrice { get; set; }
        public string DptLockRgspartPrice { get; set; }
        public string DptCurrencyCode { get; set; }
        public DateTime? DptLaborRateEffectiveDate { get; set; }
        public decimal? DptLaborRateChassisSt { get; set; }
        public decimal? DptLaborRateChassisOt { get; set; }
        public decimal? DptLaborRateChassisDt { get; set; }
        public decimal? DptLaborRateChassisDot { get; set; }
        public decimal? DptLaborRateDryCntrSt { get; set; }
        public decimal? DptLaborRateDryCntrOt { get; set; }
        public decimal? DptLaborRateDryCntrDt { get; set; }
        public decimal? DptLaborRateDryCntrDot { get; set; }
        public decimal? DptLaborRateRfrCntrSt { get; set; }
        public decimal? DptLaborRateRfrCntrOt { get; set; }
        public decimal? DptLaborRateRfrCntrDt { get; set; }
        public decimal? DptLaborRateRfrCntrDot { get; set; }
        public decimal? DptLaborRateRugsst { get; set; }
        public decimal? DptLaborRateRugsot { get; set; }
        public decimal? DptLaborRateRugsdt { get; set; }
        public decimal? DptLaborRateRugsdot { get; set; }
        public DateTime? DptPriorLaborRateEffectiveDate { get; set; }
        public decimal? DptPriorLaborRateChassisSt { get; set; }
        public decimal? DptPriorLaborRateChassisOt { get; set; }
        public decimal? DptPriorLaborRateChassisDt { get; set; }
        public decimal? DptPriorLaborRateChassisDot { get; set; }
        public decimal? DptPriorLaborRateDryCntrSt { get; set; }
        public decimal? DptPriorLaborRateDryCntrOt { get; set; }
        public decimal? DptPriorLaborRateDryCntrDt { get; set; }
        public decimal? DptPriorLaborRateDryCntrDot { get; set; }
        public decimal? DptPriorLaborRateRfrCntrSt { get; set; }
        public decimal? DptPriorLaborRateRfrCntrOt { get; set; }
        public decimal? DptPriorLaborRateRfrCntrDt { get; set; }
        public decimal? DptPriorLaborRateRfrCntrDot { get; set; }
        public decimal? DptPriorLaborRateRugsst { get; set; }
        public decimal? DptPriorLaborRateRugsot { get; set; }
        public decimal? DptPriorLaborRateRugsdt { get; set; }
        public decimal? DptPriorLaborRateRugsdot { get; set; }
        public decimal? DptConsumableRateChassisLabor { get; set; }
        public decimal? DptConsumableRateChassisParts { get; set; }
        public decimal? DptConsumableRateDryBoxLabor { get; set; }
        public decimal? DptConsumableRateDryBoxParts { get; set; }
        public decimal? DptConsumableRateRugslabor { get; set; }
        public decimal? DptConsumableRateRugsparts { get; set; }

        [Column("DptPartsMu_Chassis")]
        public decimal? DptPartsMuChassis { get; set; }
        
        [Column("DptPartsMu_Container")]
        public decimal? DptPartsMuContainer { get; set; }
        
        [Column("DptPartsMu_Carrier")]
        public decimal? DptPartsMuCarrier { get; set; }
        
        [Column("DptPartsMu_Daikin")]
        public decimal? DptPartsMuDaikin { get; set; }
        
        [Column("DptPartsMu_Mitsubishi")]
        public decimal? DptPartsMuMitsubishi { get; set; }
        
        [Column("DptPartsMu_ThermoKing")]
        public decimal? DptPartsMuThermoKing { get; set; }
        public string DptCsavvendorApcode { get; set; }
        public string DptCsavportCode { get; set; }
        public string DptCsavzone { get; set; }
        public string DptCsavdefaultCarrier { get; set; }
        public string DptCsavsupplierId { get; set; }
        public string DptHynvendorApid { get; set; }
        public string DptNykpayee { get; set; }
        public string DptNykrepairer { get; set; }
        public string DptNykoffice { get; set; }
        public string DptNykoscarFacility { get; set; }
        public string DptNykoscarVendor { get; set; }
        public string DptNykoscarLocation { get; set; }
        public string DptYmlvendorApid { get; set; }
        public string DptYmlvendorLocation { get; set; }
        public string DptYmlvendorId { get; set; }
        public string DptCmasupplierSite { get; set; }
        public string DptCmasupplier { get; set; }
        public string DptCmaportId { get; set; }
        public short? DptNsiportId { get; set; }
        public string DptSignedContractChassisTasks { get; set; }
        public string DptSignedContractChassisParts { get; set; }
        public string DptSignedContractDryBoxTasks { get; set; }
        public string DptSignedContractDryBoxParts { get; set; }
        public string DptSignedContractReeferTasks { get; set; }
        public string DptSignedContractReeferParts { get; set; }
        public string DptSignedContractGsetTasks { get; set; }
        public string DptSignedContractGsetParts { get; set; }
        public string DptMemo { get; set; }
        public string DptEmail1 { get; set; }
        public string DptEmail2 { get; set; }
        public string DptEmail3 { get; set; }
        public string DptEmail4 { get; set; }
        public string DptEmail5 { get; set; }
        public string DptEmail6 { get; set; }
        public string DptEmail1Tir { get; set; }
        public string DptEmail2Tir { get; set; }
        public string DptEmail3Tir { get; set; }
        public string DptEmail4Tir { get; set; }
        public string DptEmail5Tir { get; set; }
        public string DptEmail6Tir { get; set; }
        public string DptRailDepot { get; set; }
        public string DptEdidepot { get; set; }
        public string DptEdisendTo { get; set; }
        public string DptEdifrom { get; set; }
        public string DptEdireportEmail1 { get; set; }
        public string DptEdireportEmail2 { get; set; }
        public string DptEdireportEmail3 { get; set; }
        public string DptEdireportEmail4 { get; set; }
        public string DptEdireportEmail5 { get; set; }

        [Column("DptWes_StartDate")]
        public DateTime? DptWesStartDate { get; set; }
        public string DptRemitToName { get; set; }
        public string DptRemitToAddress1 { get; set; }
        public string DptRemitToAddress2 { get; set; }
        public string DptRemitToAddress3 { get; set; }
        public string DptRemitToCity { get; set; }
        public string DptRemitToState { get; set; }
        public string DptRemitToZipCode { get; set; }
        public short? DptCcpartSchedule { get; set; }
        public string DptAllowIschassis { get; set; }
        public string DptAllowIsdryBox { get; set; }
        public string DptAllowIsreefer { get; set; }
        public string DptAllowIsgenset { get; set; }
        public string DptAllowOhchassis { get; set; }
        public string DptAllowOhdryBox { get; set; }
        public string DptAllowOhreefer { get; set; }
        public string DptAllowOhgenset { get; set; }
        public string DptAllowSurvey { get; set; }
        public string DptAllowRoadability { get; set; }
        public string DptAllowTires { get; set; }
        public string DptAllowRoadService { get; set; }
        public string DptAllowVesselOps { get; set; }
        public string DptAllowRgservices { get; set; }
        public short? DptTireVendorId { get; set; }
        public short? DptTireDepotId { get; set; }
        public int? DptTireTargetInventory { get; set; }
        public float? DptTireFetaxRate { get; set; }
        public float? DptTireSalesTaxRate { get; set; }
        public string DptTimeZone { get; set; }
        public short? DptTimeZoneOffset { get; set; }
        public string DptCcmsenderId { get; set; }
        public string DptCcmvendorId { get; set; }
        public string DptCcmfacilityId { get; set; }
        public string DptCcmfunctionalSenderId { get; set; }
        public string DptCcmiepscac { get; set; }
        public string DptAllowMonitoring { get; set; }
        public string DptAllowIstank { get; set; }
        public string DptAllowOhtank { get; set; }
        public string DptAllowGate { get; set; }
        public string DptAllowChassisInspection { get; set; }
        public string DptAllowDryBoxInspection { get; set; }
        public string DptPhotosRequired { get; set; }
        public short? DptTariffId { get; set; }
        public string DptMobilePhotosRequired { get; set; }
        public string DptCgitier { get; set; }
        public string DptTracpsvendor { get; set; }
        public string DptTracedivendor { get; set; }
    }
}

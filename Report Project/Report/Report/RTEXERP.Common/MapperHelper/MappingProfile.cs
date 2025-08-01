using AutoMapper;
using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.BLModels.dbo;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.EMBRO.VoucherModel;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.Maxco.DataTransferModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.DBEntities.CMS;
using RTEXERP.DBEntities.dbo;
using RTEXERP.DBEntities.Embro;
using RTEXERP.DBEntities.EMBRO;
using RTEXERP.DBEntities.FiniteScheduler;
using RTEXERP.DBEntities.MaterialsManagement;
using RTEXERP.DBEntities.Maxco;

namespace RTEXERP.Common.MapperHelper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShippingInvoiceExcelMigrationViewModel, ShippingInvoiceExcelMigration>().ReverseMap();
            CreateMap<CMBL_SampleViewModel, CMBL_Sample>().ReverseMap();
            CreateMap<CMBL_SampleItemViewModel, CMBL_SampleItem>().ReverseMap();
            CreateMap<CMBL_SampleGateReceivingViewModel, CMBL_SampleGateReceiving>().ReverseMap();
            CreateMap<CMBL_SampleItemGateReceivingViewModel, CMBL_SampleItemGateReceiving>().ReverseMap();
            CreateMap<RoleWiseModuleViewModel, RoleWiseModule>().ReverseMap();

            #region Maxco
            CreateMap<MAC_OrderCostingInfoVM, MAC_OrderCostingInfo>().ReverseMap();
            CreateMap<MAC_FabricCostingInfoVM, MAC_FabricCostingInfo>().ReverseMap();
            CreateMap<MAC_AccessoriesCostingInfoVM, MAC_AccessoriesCostingInfo>().ReverseMap();

            CreateMap<Mer_StyleMasterVM, Mer_StyleMaster>().ReverseMap();
            CreateMap<Mer_StylePODetailVM, Mer_StylePODetail>().ReverseMap();
            CreateMap<Mer_StylePOColorSizeQuantityDetailVM, Mer_StylePOColorSizeQuantityDetail>().ReverseMap();


            CreateMap<FabricBooking, FabricBookingViewModel>().ReverseMap();
            CreateMap<FabricBookingMaster, FabricBookingMasterViewModel>().ReverseMap();
            CreateMap<FabricBookingDetail, FabricBookingDetailViewModel>().ReverseMap();
            CreateMap<FabricBookingSizeDetail, FabricBookingSizeDetailViewModel>().ReverseMap();
            CreateMap<IE_OrderEfficiency, IE_OrderEfficiencyViewModel>().ReverseMap();
            CreateMap<InterOrderFabricTransfer, InterOrderFabricTransferDTM>().ReverseMap();
            #endregion

            #region Finite Scheduler
            CreateMap<OvalPrintingReportMasterViewModel, OvalPrintingReportMaster>().ReverseMap();
            CreateMap<OvalPrintingReportDetailsViewModel, OvalPrintingReportDetails>().ReverseMap();
            CreateMap<LotWiseCuttingInfoViewModel, LotWiseCuttingInfo>().ReverseMap();
            CreateMap<LotWiseCuttingInfoMarkersViewModel, LotWiseCuttingInfoMarkers>().ReverseMap();
            CreateMap<LotWiseCuttingInfoMarkersSizesViewModel, LotWiseCuttingInfoMarkersSizes>().ReverseMap();
            CreateMap<LotWiseShortCuttingInfoViewModel, LotWiseShortCuttingInfo>().ReverseMap();
            CreateMap<OrderColorWiseRejectionBreakdown_ReportViewModel, OrderColorWiseRejectionBreakdown_Report>().ReverseMap();
            CreateMap<DFS_LotDyeingDelivery, DFS_LotDyeingDeliveryVM>().ReverseMap();

            #endregion Finite Scheduler

            #region EMBRO
            CreateMap<CBM_AdvancePaymentViewModel, TblCbmAdvancePayment>().ReverseMap();
            CreateMap<VoucherViewModel, Voucher>().ReverseMap();
            CreateMap<VoucherDetailViewModel, Voucherdetail>().ReverseMap();
            CreateMap<VoucherGeneralInfoViewModel, VoucherGeneralInfo>().ReverseMap();
            CreateMap<JournalVoucherInfoViewModel, JournalVoucherInfo>().ReverseMap();
            CreateMap<BankVoucherInfoViewModel, BankVoucherInfo>().ReverseMap();

            #endregion EMBRO

            #region CMS
            CreateMap<MonthlyProductionCostAnalysisMasterVM, MonthlyProductionCostAnalysisMaster>().ReverseMap();
            CreateMap<MonthlyProductionCostAnalysisDetailsVM, MonthlyProductionCostAnalysisDetails>().ReverseMap();
            #endregion CMS

            #region MaterialsManagement
            CreateMap<KnittingNeedleConsumptionMasterViewModel, KnittingNeedleConsumptionMaster>().ReverseMap();
            CreateMap<KnittingNeedleConsumptionDetailsViewModel, KnittingNeedleConsumptionDetails>().ReverseMap();
            #endregion MaterialsManagement


        }
    }
}

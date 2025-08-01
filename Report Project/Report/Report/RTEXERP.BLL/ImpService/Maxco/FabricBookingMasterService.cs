using RTEXERP.Contracts.BLModels.Maxco.SPModel.FabricBooking;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class FabricBookingMasterService : IFabricBookingMasterService
    {
        private readonly IFabricBookingMasterRepository fabricBookingMasterRepository;
        private readonly IKRS_SizesRepository krs_SizesRepository;

        public FabricBookingMasterService(IFabricBookingMasterRepository _fabricBookingMasterRepository, IKRS_SizesRepository _krs_SizesRepository)
        {
            fabricBookingMasterRepository = _fabricBookingMasterRepository;
            krs_SizesRepository = _krs_SizesRepository;
        }
        public async Task<List<FRSFabricForBooking>> GETFRSFabricForBooking(List<int> StyleIDList)
        {
            var bookingList = new List<FRSFabricForBooking>();
            if (StyleIDList.Count > 0)
            {
                var StyleXML = "<Order>";
                foreach (var styleID in StyleIDList)
                {
                    StyleXML += $"<Style ID=\"{styleID}\"/>";
                }
                StyleXML += $"</Order>";
                bookingList = await fabricBookingMasterRepository.GETFRSFabricForBooking(StyleXML);
            }
            return bookingList;
        }

        public async Task<FabricBookingMasterViewModel> GETFRSFabricFullDataForBooking(List<int> StyleIDList)
        {
            var fullData = new FabricBookingMasterViewModel();
            var bookingData = await GETFRSFabricForBooking(StyleIDList);
            if (bookingData.Count > 0)
            {
                foreach (var data in bookingData)
                {
                    var bookingSizes = new List<FabricBookingSizeDetailViewModel>();
                    if (data.ProcurementUnitID == 7)//7=>Pieces
                    {
                        var sizeList = await krs_SizesRepository.GetKRS_MasterWiseSizes(data.KRSID, data.AttributeInstanceID);
                        bookingSizes = sizeList.Select(x => new FabricBookingSizeDetailViewModel()
                        {
                            KRSDID = x.KRSDID,
                            SizeID = x.SizeID,
                            SizeName = x.SizeName,
                            Len = x.Len,
                            Wid = x.Wid,
                            PantoneNo = x.Pantone,
                            Quantity = x.Quantity,
                            WeightConsumption = x.WeightConsumption,
                            FabricTrimID=x.FabricTrimID.Value,
                            FabricTrimName=x.FabricTrimName
                        }).ToList();
                        //detail.FabricBookingSizeDatail = bookingSizes;
                    }
                    var detail = new FabricBookingDetailViewModel()
                    {
                        StyleID = data.StyleID,
                        FabricComposition = data.FabricComposition,
                        Dia = data.FinishedWidth,
                        GSM = data.GSM,
                        PantoneNo = data.PantoneNo,
                        UseIn = data.FabricUseIn,
                        NumberOfGarments = data.NumberOfGarments,
                        Consumption = data.FinishFabricConsumption,
                        TotalKG = Math.Ceiling((data.NumberOfGarments * data.FinishFabricConsumption)),
                        FSTypeID = data.FSTypeID,
                        FSType = data.FSType,
                        RequirementSheetID = data.RequirementSheetID,
                        KRS_MID = data.KRSID,
                        ProcurementUnitID = data.ProcurementUnitID,                       
                        StyleName=data.StyleName,
                        FabricTypeID=data.FabricTypeID,
                        FabricType=data.FabricType,
                        FabricQualityID=data.FabricQualityID,
                        FabricQuality=data.FabricQuality,
                        ProcurementUnit=data.Unit,
                        AttributeInstanceID=data.AttributeInstanceID,
                        FabricBookingSizeDetail = bookingSizes
                    };
                    fullData.FabricBookingDetail.Add(detail);


                }
            }
            return fullData;

        }
    }
}

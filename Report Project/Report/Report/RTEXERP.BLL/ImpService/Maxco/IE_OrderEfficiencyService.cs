using AutoMapper;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace RTEXERP.BLL.ImpService.Maxco
{
    public class IE_OrderEfficiencyService : IIE_OrderEfficiencyService
    {
        private readonly IIE_OrderEfficiencyRepository iE_OrderEfficiencyRepository;
        private readonly ISFS_ProductionResourceSpecificationRepository _sFS_ProductionResourceSpecificationRepository;
        private readonly IMapper mapper;

        public IE_OrderEfficiencyService(IIE_OrderEfficiencyRepository _iE_OrderEfficiencyRepository
            , IMapper _mapper
            , ISFS_ProductionResourceSpecificationRepository sFS_ProductionResourceSpecificationRepository)
        {
            iE_OrderEfficiencyRepository = _iE_OrderEfficiencyRepository;
            mapper = _mapper;
            _sFS_ProductionResourceSpecificationRepository = sFS_ProductionResourceSpecificationRepository;
        }

        public async Task<IE_OrderEfficiencyViewModel> GetIEOrderEfficient(int id)
        {
            return await iE_OrderEfficiencyRepository.GetIEOrderEfficient(id);
        }

        public async Task<IE_OrderEfficiencyViewModel> GetOrderEfficientByID(int ID)
        {
            var orderEfficientDB = await iE_OrderEfficiencyRepository.GetOrderEfficientByID(ID);
            var orerEfficientVM = mapper.Map<IE_OrderEfficiency, IE_OrderEfficiencyViewModel>(orderEfficientDB);
            return orerEfficientVM;
        }

        public async Task<List<OrderEfficiencyDataModel>> GetOrderEfficientList(DateTime? dateFrom, DateTime? dateTo, int orderID = 0, int styleID = 0, string pantonNo = null)
        {
            var targetData = await iE_OrderEfficiencyRepository.GetOrderEfficientList(dateFrom, dateTo, orderID, styleID, pantonNo);
            var lineInfo = await _sFS_ProductionResourceSpecificationRepository.GetProductionResourceSpecificationsList(4);

            var finalData = from t in targetData
                            join lin in lineInfo on t.LineID equals lin.SFS_PRSID into rtnData
                            from tline in rtnData.DefaultIfEmpty()
                            select new OrderEfficiencyDataModel
                            {
                                BuyerID = t.BuyerID,
                                ID = t.ID,
                                HourlyTargetProduction = t.HourlyTargetProduction,
                                LineID = t.LineID,
                                LineName = tline.Name,
                                OrderID = t.OrderID,
                                OrderNo = t.OrderNo,
                                OrderSMV = t.OrderSMV,
                                PantoneNo = t.PantoneNo,
                                Remarks = t.Remarks,
                                StyleID = t.StyleID,
                                StyleName = t.StyleName,
                                TargetEffiency = t.TargetEffiency,
                                ManPower = t.ManPower,

                            };

            return finalData.ToList();
        }

        public async Task<RResult> Remove(int ID)
        {
            return await iE_OrderEfficiencyRepository.Remove(ID);
        }

        public async Task<RResult> SaveIEOrderEfficiency(IE_OrderEfficiencyViewModel model)
        {
            var orderEfficientDB = new IE_OrderEfficiency();
            if (model.ID > 0)
            {
                orderEfficientDB = await iE_OrderEfficiencyRepository.GetOrderEfficientByID(model.ID);
                orderEfficientDB.ReportDate = model.ReportDate;
                orderEfficientDB.OrderID = model.OrderID;
                orderEfficientDB.StyleID = model.StyleID;
                orderEfficientDB.LineID = model.LineID;
                orderEfficientDB.PantoneNo = model.PantoneNo;
                orderEfficientDB.HourlyTargetProduction = model.HourlyTargetProduction;
                orderEfficientDB.OrderSMV = model.OrderSMV;
                orderEfficientDB.TargetEffiency = model.TargetEffiency;
                orderEfficientDB.LineManpower = model.LineManpower;
                orderEfficientDB.WorkingHour = model.WorkingHour;
                orderEfficientDB.Remarks = model.Remarks;
                orderEfficientDB.UpdatedDate = DateTime.Now;
            }
            else
            {
                orderEfficientDB = mapper.Map<IE_OrderEfficiencyViewModel, IE_OrderEfficiency>(model);
            }

            return await iE_OrderEfficiencyRepository.SaveIEOrderEfficiency(orderEfficientDB);
        }
    }
}

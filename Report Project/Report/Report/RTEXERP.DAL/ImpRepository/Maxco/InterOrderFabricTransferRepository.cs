using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.DataTransferModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class InterOrderFabricTransferRepository : GenericRepository<InterOrderFabricTransfer>, IInterOrderFabricTransferRepository
    {
        private readonly MaxcoDBContext dbCon;
        private readonly IMapper _mapper;
        public InterOrderFabricTransferRepository(MaxcoDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            _mapper = mapper;
        }

        public async Task<List<SelectListItem>> DDLFabricTransferedFromOrders(DateTime? transferDateFrom, DateTime? transferDateTo, string Predict)
        {
            transferDateTo = transferDateTo == null ? DateTime.Now : transferDateTo;
            transferDateFrom = transferDateFrom == null ? DateTime.Now.AddYears(-2) : transferDateFrom;

            var dataQuery = from iot in dbCon.InterOrderFabricTransfer
                            join o in dbCon.Style on iot.TransferedFromOrderID equals (int)o.ID
                            where iot.IsRemoved == false && iot.TransferDate >= transferDateFrom.Value && iot.TransferDate <= transferDateTo.Value
                            select new
                            {
                                OrderID = iot.TransferedToOrderID,
                                OrderNo = o.OrderNo.Trim()
                            };

            if (string.IsNullOrEmpty(Predict) == false)
            {
                dataQuery = dataQuery.Where(b => b.OrderNo.Contains(Predict));
            }

            var data = await dataQuery.Select(r => new SelectListItem
            {
                Text = r.OrderNo,
                Value = r.OrderID.ToString()
            }).Distinct().ToListAsync();
            return data;
        }

        public async Task<List<SelectListItem>> DDLFabricTransferedToOrders(DateTime? transferDateFrom, DateTime? transferDateTo, string Predict)
        {
            transferDateTo = transferDateTo == null ? DateTime.Now : transferDateTo;
            transferDateFrom = transferDateFrom == null ? DateTime.Now.AddYears(-2) : transferDateFrom;

            var _dataQuery = from iot in dbCon.InterOrderFabricTransfer
                             join o in dbCon.Style on iot.TransferedToOrderID equals (int)o.ID
                             where iot.IsRemoved == false && iot.TransferDate >= transferDateFrom.Value && iot.TransferDate <= transferDateTo.Value
                             select new
                             {
                                 OrderID = iot.TransferedToOrderID,
                                 OrderNo = o.OrderNo.Trim()
                             };

            if (string.IsNullOrEmpty(Predict) == false)
            {
                _dataQuery = _dataQuery.Where(b => b.OrderNo.Contains(Predict));
            }
            var data = await _dataQuery.Select(r => new SelectListItem
            {
                Text = r.OrderNo,
                Value = r.OrderID.ToString()
            }).Distinct().ToListAsync();
            return data;
        }

        public async Task<List<FabricTransferSenderReceiverInfoSPModel>> GetFabricTransferReceiverInfo(int orderID)
        {
            var infoList = new List<FabricTransferSenderReceiverInfoSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.USP_GetFabricTransferReceiverInfo")
                             .WithSqlParam("OrderID", orderID)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 infoList = handler.ReadToList<FabricTransferSenderReceiverInfoSPModel>() as List<FabricTransferSenderReceiverInfoSPModel>;
                             });
                return infoList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<FabricTransferSenderReceiverInfoSPModel>> GetFabricTransferSenderInfo(int orderID)
        {
            var infoList = new List<FabricTransferSenderReceiverInfoSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.USP_GetFabricTransferSenderInfo")
                             .WithSqlParam("OrderID", orderID)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 infoList = handler.ReadToList<FabricTransferSenderReceiverInfoSPModel>() as List<FabricTransferSenderReceiverInfoSPModel>;
                             });
                return infoList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RResult> SaveInterOrderFabricTransfer(InterOrderFabricTransferDTM model, int CreatedBy)
        {
            RResult rResult = new RResult();
            decimal PreviousAdjust = 0;
            var fromOrderRequiredFabric = await dbCon.QRM_OrderSheetFabrics.FirstAsync(b => b.VersionID == model.TransferedFromVersionID
                                && b.AttributeInstanceID == model.TransferedFromOrderFabricAttributeInstanceID);

            var toOrderRequiredFabric = await dbCon.QRM_OrderSheetFabrics.FirstAsync(b => b.VersionID == model.TransferedToVersionID
                                            && b.AttributeInstanceID == model.TransferedToOrderFabricAttributeInstanceID);

            var toOrderExistingTransferFabric = await dbCon.InterOrderFabricTransfer
                                                     .Where(b => b.TransferedToOrderID == model.TransferedToOrderID
                                                              && b.TransferedToOrderFabricAttributeInstanceID == model.TransferedToOrderFabricAttributeInstanceID
                                                              && b.IsRemoved == false).SumAsync(b => b.TransferedQuantity);
            ///Remove Condition For Additional.
            if (model.TransferTypeID != 3)
            {
                if (toOrderRequiredFabric.RequiredQty.Value < Convert.ToDouble(model.TransferedQuantity))
                {
                    rResult.result = 0;
                    rResult.message = "Quantity overlap for this Order.";
                    return rResult;
                }
            }

            InterOrderFabricTransfer dbModel = _mapper.Map<InterOrderFabricTransferDTM, InterOrderFabricTransfer>(model);
            dbModel.IsRemoved = false;
            dbModel.CreatedBy = CreatedBy;
            dbModel.CreatedDate = DateTime.Now;

            dbCon.InterOrderFabricTransfer.Add(dbModel);
            if (toOrderRequiredFabric.AdjustRequiredQty > 0)
            {
                PreviousAdjust = toOrderRequiredFabric.AdjustRequiredQty.Value;
            }
            if (model.TransferTypeID == 1 || model.TransferTypeID == 3)
            {
                fromOrderRequiredFabric.AdjustRequiredQty = fromOrderRequiredFabric.AdjustRequiredQty - model.TransferedQuantity;
                dbModel.IsFromOSGenerated = false;
            }
            if (model.TransferTypeID == 3)
            {
                toOrderRequiredFabric.AdjustRequiredQty = PreviousAdjust + model.TransferedQuantity;
                dbModel.IsToOSGenerated = false;
            }
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = "Successfully Saved Interorder transfer.";
            return rResult;
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.DataTransferModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
    public interface IInterOrderFabricTransferRepository:IGenericRepository<InterOrderFabricTransfer>
    {
        Task<List<FabricTransferSenderReceiverInfoSPModel>> GetFabricTransferSenderInfo(int orderID);
        Task<List<FabricTransferSenderReceiverInfoSPModel>> GetFabricTransferReceiverInfo(int orderID);
        Task<RResult> SaveInterOrderFabricTransfer(InterOrderFabricTransferDTM model,  int CreatedBy);
        Task<List<SelectListItem>> DDLFabricTransferedFromOrders(DateTime? transferDateFrom, DateTime? transferDateTo,string Predict);
        Task<List<SelectListItem>> DDLFabricTransferedToOrders(DateTime? transferDateFrom, DateTime? transferDateTo, string Predict);

    }
}

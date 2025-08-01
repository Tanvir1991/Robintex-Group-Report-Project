using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.DataTransferModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface IInterOrderFabricTransferService
    {
        Task<List<FabricTransferSenderReceiverInfoSPModel>> GetFabricTransferSenderInfo(int orderID);
        Task<List<FabricTransferSenderReceiverInfoSPModel>> GetFabricTransferReceiverInfo(int orderID);
        Task<RResult> SaveInterOrderFabricTransfer(InterOrderFabricTransferDTM model, int CreatedBy);
        Task<List<SelectListItem>> DDLFabricTransferedFromToOrders(DateTime? transferDateFrom, DateTime? transferDateTo, string receiveType, string Predict);
        
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.DataTransferModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class InterOrderFabricTransferService : IInterOrderFabricTransferService
    {
        private readonly IInterOrderFabricTransferRepository interOrderFabricTransferRepository;

        public InterOrderFabricTransferService(IInterOrderFabricTransferRepository _interOrderFabricTransferRepository)
        {
            interOrderFabricTransferRepository = _interOrderFabricTransferRepository;
        }

        public async Task<List<SelectListItem>> DDLFabricTransferedFromToOrders(DateTime? transferDateFrom, DateTime? transferDateTo, string receiveType, string Predict)
        {
            if (receiveType == "Sender")
            {
                return await interOrderFabricTransferRepository.DDLFabricTransferedFromOrders(transferDateFrom, transferDateTo, Predict);
            }
            else
            {
                return await interOrderFabricTransferRepository.DDLFabricTransferedToOrders(transferDateFrom, transferDateTo,Predict);
            }
        }

        public async Task<List<FabricTransferSenderReceiverInfoSPModel>> GetFabricTransferReceiverInfo(int orderID)
        {
            return await interOrderFabricTransferRepository.GetFabricTransferReceiverInfo(orderID);
        }

        public async Task<List<FabricTransferSenderReceiverInfoSPModel>> GetFabricTransferSenderInfo(int orderID)
        {
            return await interOrderFabricTransferRepository.GetFabricTransferSenderInfo(orderID);
        }

        public async Task<RResult> SaveInterOrderFabricTransfer(InterOrderFabricTransferDTM model, int CreatedBy)
        {
            return await interOrderFabricTransferRepository.SaveInterOrderFabricTransfer(model, CreatedBy);
        }
    }
}

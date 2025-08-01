using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class ConsumptionSheetUserInputsRepository:GenericRepository<ConsumptionSheetUserInputs>, IConsumptionSheetUserInputsRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public ConsumptionSheetUserInputsRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> ConsumptionSheetUserInputsSave(ConsumptionSheetUserInputs entity)
        {
            var rResult = new RResult();
            try
            {
                if (entity.InspectionPcs!=null|| entity.PanelRejectPcs != null || entity.PanelRejectPercentage != null || entity.TotalFinishFabricUsed != null)
                {
                    var dbEntity = dbCon.ConsumptionSheetUserInputs.Where(x => x.OrderID == entity.OrderID && x.PantoneNo == entity.PantoneNo).FirstOrDefault();
                    if (dbEntity!=null)
                    {
                        dbEntity.InspectionPcs = entity.InspectionPcs > 0 ? entity.InspectionPcs : null;
                        dbEntity.PanelRejectPcs = entity.PanelRejectPcs > 0 ? entity.PanelRejectPcs : null;
                        dbEntity.PanelRejectPercentage = entity.PanelRejectPercentage > 0 ? entity.PanelRejectPercentage : null;
                        dbEntity.TotalFinishFabricUsed = entity.TotalFinishFabricUsed > 0 ? entity.TotalFinishFabricUsed : null;
                        dbEntity.ALGOOSQty = entity.ALGOOSQty > 0 ? entity.ALGOOSQty : null;
                        dbEntity.TotalFinishFabricMayReq= entity.TotalFinishFabricMayReq > 0 ? entity.TotalFinishFabricMayReq : null;
                    }
                    else
                    {
                        var newEntity = new ConsumptionSheetUserInputs();
                        newEntity.OrderID = entity.OrderID;
                        newEntity.OrderNo = entity.OrderNo;
                        newEntity.PantoneNo = entity.PantoneNo;
                        newEntity.InspectionPcs = entity.InspectionPcs > 0 ? entity.InspectionPcs : null;
                        newEntity.PanelRejectPcs = entity.PanelRejectPcs > 0 ? entity.PanelRejectPcs : null;
                        newEntity.PanelRejectPercentage = entity.PanelRejectPercentage > 0 ? entity.PanelRejectPercentage : null;
                        newEntity.TotalFinishFabricUsed = entity.TotalFinishFabricUsed > 0 ? entity.TotalFinishFabricUsed : null;
                        newEntity.ALGOOSQty = entity.ALGOOSQty > 0 ? entity.ALGOOSQty : null;
                        newEntity.TotalFinishFabricMayReq = entity.TotalFinishFabricMayReq > 0 ? entity.TotalFinishFabricMayReq : null;

                        dbCon.ConsumptionSheetUserInputs.Add(newEntity);
                    }
                    await dbCon.SaveChangesAsync();
                }
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;

            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}

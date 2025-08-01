using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface IConsumptionSheetUserInputsRepository:IGenericRepository<ConsumptionSheetUserInputs>
    {
        Task<RResult> ConsumptionSheetUserInputsSave(ConsumptionSheetUserInputs entity);
    }
}

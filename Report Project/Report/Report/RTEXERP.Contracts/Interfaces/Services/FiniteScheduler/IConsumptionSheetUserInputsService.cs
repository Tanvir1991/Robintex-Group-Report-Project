using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface IConsumptionSheetUserInputsService
    {
        Task<RResult> ConsumptionSheetUserInputsSave(ConsumptionSheetUserInputs entity);
    }
}

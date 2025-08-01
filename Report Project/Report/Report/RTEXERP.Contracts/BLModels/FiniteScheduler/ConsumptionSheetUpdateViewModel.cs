using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class ConsumptionSheetUpdateViewModel
    {
        public ConsumptionSheetUserInputs ConsumptionSheetUserInputs { get; set; }
        public List<OrderColorWiseRejectionBreakdown_Report> OrderColorWiseRejectionBreakdown_Report { get; set; }
    }
}

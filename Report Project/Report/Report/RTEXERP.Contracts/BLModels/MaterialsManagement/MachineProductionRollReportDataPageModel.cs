using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
  public  class MachineProductionRollReportDataPageModel
    {
        public MachineProductionRollReportDataPageModel()
        {
            MachineProductionRoll = new List<MachineProductionRollSPModel>();
        }
        public string DateDuration { get; set; }
        public List<MachineProductionRollSPModel> MachineProductionRoll { get; set; }
       
    }
}

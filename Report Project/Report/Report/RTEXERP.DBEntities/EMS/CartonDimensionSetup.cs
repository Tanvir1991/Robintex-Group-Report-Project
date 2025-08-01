using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class CartonDimensionSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? GarmentLimit { get; set; }
    }
}

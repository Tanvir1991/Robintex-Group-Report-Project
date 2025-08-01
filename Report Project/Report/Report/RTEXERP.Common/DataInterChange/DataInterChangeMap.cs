using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Common.DataInterChange
{
   public class DataInterChangeMap
    {

        public int CompanyWiseDefaultBusinessType(int CompanyId)
        {
            int BusinessTypeId = 0;
            if (CompanyId == 183)
            {
                BusinessTypeId = 6;
            }
            else if (CompanyId == 20183)
            {
                BusinessTypeId = 20006;
            }
            return BusinessTypeId;
        }
    }
}

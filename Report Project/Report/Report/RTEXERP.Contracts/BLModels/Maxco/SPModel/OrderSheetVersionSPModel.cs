using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{
    public class OrderSheetVersionSPModel
    {
        public int VersionID { get; set; }
        public string SheetNo { get; set; }
        public string OrderNo  { get; set; }
        public string VersionNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string OSStatus { get; set; }
       public int OrderID { get; set; }

        public string CreationDateSTR { get { return CreationDate.ToString("dd-MMM-yyyy"); } }
    }
}

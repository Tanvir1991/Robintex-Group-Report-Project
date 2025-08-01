using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.Common.AccDefaultSetups
{
    public   class AccDefaultSetup
    {
        public AccDefaultSetup( int CompanyID)
        {
            if (CompanyID == 183)
            {
                BusinessID = 6;
            }
            else if(CompanyID==20183)
            {
                BusinessID = 20006;
            }
        }
        public   int BusinessID {get;set;}

        public string FinincialDateFrom(DateTime DateFrom)
        {
            int Month = DateFrom.Month;
            string _DateFrom = "";
            int year = DateFrom.Year;
            if (Month >= 7)
            {
                  year = DateFrom.Year;
            }
            else if (Month <= 6)
            {
                  year = (DateFrom.Year)-1;
            }
            _DateFrom = $"01-July-{year}";
            return _DateFrom;
        }

        public List<SelectListItem> DDLVoucherCategory()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            item.Add(new SelectListItem { Value = "Party", Text = "Party Voucher" });
            item.Add(new SelectListItem { Value = "Vat", Text = "Vat Voucher" });
            item.Add(new SelectListItem { Value = "ITax", Text = "Income Tax Voucher" });
            return item;
        }

       
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.Common
{
  public  class DropDownItem
    { 
        public bool Selected { get; set; }
       
        public string Text { get; set; }
      
        public string Value { get; set; }

        public string Custome1 { get; set; }
        public string Custome2 { get; set; }
        public string Custome3 { get; set; }
        public string Custome4 { get; set; }
    }
}

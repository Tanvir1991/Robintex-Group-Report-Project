using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel.BatchCosting
{
 public   class BatchOrderInfo
    {
     public int  BuyerID              {get;set;}
     public string BuyerName          {get;set;}
     public long  OrderID             {get;set;}
     public string OrderName          {get;set;}
     public string MachineName        {get;set;}
     public string MachineCap         {get;set;}
     public string Color              {get;set;}
     public long  LotID                {get;set;}
     public string LotNo              {get;set;}
     public string ColorDesc          {get;set;}
     public string FinishComments { get; set; }

    }
}

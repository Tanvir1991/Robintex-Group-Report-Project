using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class ExportInvoiceAdjustMasterRepository : GenericRepository<ExportInvoiceAdjustMaster>, IExportInvoiceAdjustMasterRepository
    {
        private EmbroDBContext dbCon;
        public ExportInvoiceAdjustMasterRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;
        }
      
        public async Task<RResult> GenerateAdjustNumber(int CompanyID)
        {
            RResult rResult = new RResult();
            string _adjustNum = "";
            int serialNumber = 1;
            string YearShort = DateTime.Now.ToString("yy");
            if (CompanyID == 183)
            {
                _adjustNum = $"RT-ADJ-{YearShort}-";
            }
            else
            {
                _adjustNum = $"CF-ADJ-{YearShort}-";
            }
            var _voucherData = from adv in dbCon.ExportInvoiceAdjustMaster
                           where  adv.AdjustmentNo.Contains(_adjustNum)
                              select new RResult
                              {
                                  statusMsg = adv.AdjustmentNo,
                                  statusCode =adv.AdjustmentSerial==null ?0:adv.AdjustmentSerial.Value
                              };
            var advList = await _voucherData.ToListAsync();
            if(advList != null && advList.Count > 0)
            {
                serialNumber = advList.Max(b=>b.statusCode)+1;
            }

            _adjustNum = _adjustNum + serialNumber.ToString("0000");
            rResult.statusCode = serialNumber;
            rResult.statusMsg = _adjustNum;
            return rResult;
        }

        public async Task<List<ExportInvoiceAdjustmentListViewModel>> GetExportInvoiceAdjustmentList(ExportInvoiceAdjustmentListViewModel model)
        {
            var data = from adjM in dbCon.ExportInvoiceAdjustMaster
                       join adjD in dbCon.ExportInvoiceAdjustDetails on adjM.ID equals adjD.MasterID
                       join v in dbCon.Voucher on adjM.VoucherID equals v.Id
                       join ve in dbCon.ExportInvoiceVoucherMapping on v.Id equals ve.VoucherID
                       join chq in dbCon.CbmCheque on v.Id equals chq.VoucherId
                       where (adjM.CreatedDate.Date >= model.DateFrom && adjM.CreatedDate.Date <= model.DateTo.Date)
                        && v.CompanyId==(int)model.CompanyID && ve.ExportInvoiceTypeID == model.ExportInvoiceTypeID
                       group new { adjM, adjD, v } by new { adjM.ID,adjM.AdjustmentNo, adjM.CreatedDate, v.VoucherNumber, v.Vdate,chq.ChqNum } into Nt
                       select new ExportInvoiceAdjustmentListViewModel
                       {
                           AdjustmentID = Nt.Key.ID,
                           AdjustmentNo = Nt.Key.AdjustmentNo,
                           AdjustmentDate = Nt.Key.CreatedDate.ToString("dd-MMM-yyyy"),
                           VoucherNumber = Nt.Key.VoucherNumber,
                           VoucherDate = Nt.Key.Vdate.Value.ToString("dd-MMM-yyyy"),
                           Amount = Nt.Sum(b => b.adjD.Amount),
                           ChequeNumber = Nt.Key.ChqNum
                       };

            var _rData = await data.ToListAsync();
            return _rData;

        }

        public async Task<RResult> SaveExportInfoiceAdjustment(ExportInvoiceAdjustMaster model)
        {
            RResult rResult = new RResult();
            try
            {
                dbCon.ExportInvoiceAdjustMaster.Add(model);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = $"Successfully Created <br/> Adjustment Number : {model.AdjustmentNo}";
                

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}

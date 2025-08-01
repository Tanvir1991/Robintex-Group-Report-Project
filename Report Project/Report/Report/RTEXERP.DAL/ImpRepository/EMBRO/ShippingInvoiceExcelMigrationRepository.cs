
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using AutoMapper;
using RTEXERP.DBEntities.Embro;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
   public class ShippingInvoiceExcelMigrationRepository : GenericRepository<ShippingInvoiceExcelMigration>, IShippingInvoiceExcelMigrationRepository
    {

        private EmbroDBContext dbCon;
        private IMapper mapper;
        public ShippingInvoiceExcelMigrationRepository(EmbroDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }

        public async Task<List<ShippingInvoiceExcelMigrationViewModel>> ShippingInvoiceSave(ExcelPackage package)
        {

            List<ShippingInvoiceExcelMigrationViewModel> dataList = new List<ShippingInvoiceExcelMigrationViewModel>();
            List<ShippingInvoiceExcelMigration> listToSave = new List<ShippingInvoiceExcelMigration>();
            List<ShippingInvoiceExcelMigrationViewModel> duplicateInvoiceList = new List<ShippingInvoiceExcelMigrationViewModel>();
            try
            {  
                foreach (var sheet in package.Workbook.Worksheets)
                {
                    var rowCount = sheet.Dimension.Rows;
                    var columnCount = sheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)
                    {   
                        dataList.Add(new ShippingInvoiceExcelMigrationViewModel
                        {
                            ExcelSerial = sheet.Cells[row, 1].Value.ToString().Trim()==""?0:Convert.ToInt32(sheet.Cells[row, 1].Value.ToString().Trim()),
                            InvoiceNo = sheet.Cells[row, 2].Value.ToString().Trim(),
                            ShippingBillNo= sheet.Cells[row, 3].Value.ToString().Trim(),
                            ShippingDate= Convert.ToDateTime(sheet.Cells[row, 4].Value.ToString().Trim())
                        });
                    }
                    duplicateInvoiceList = await FindDuplicateInvoiceList(dataList);
                    if (duplicateInvoiceList.Count==0) {
                        listToSave = mapper.Map<List<ShippingInvoiceExcelMigrationViewModel>, List<ShippingInvoiceExcelMigration>>(dataList);
                        listToSave.ForEach(x => { x.IsMigrated = false; x.IsRemoved = false; x.ExcelUploadDate = DateTime.Now; });

                        dbCon.ShippingInvoiceExcelMigration.AddRange(listToSave);
                        await dbCon.SaveChangesAsync();
                    }
                    break;// now we just need to read the first sheet only
                }
                return duplicateInvoiceList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        private async Task<List<ShippingInvoiceExcelMigrationViewModel>> FindDuplicateInvoiceList(List<ShippingInvoiceExcelMigrationViewModel> dataList)
        {
            List<ShippingInvoiceExcelMigrationViewModel> duplicateData = new List<ShippingInvoiceExcelMigrationViewModel>();
            try
            {
                var containsInvoiceNo = dataList.Select(x => x.InvoiceNo);
                var dbData = await dbCon.ShippingInvoiceExcelMigration.Where(p => containsInvoiceNo.Contains(p.InvoiceNo))
                  .Select(d => new ShippingInvoiceExcelMigrationViewModel()
                  {
                      InvoiceNo = d.InvoiceNo
                  }).ToListAsync();
                if (dbData.Count > 0)
                {
                    duplicateData = (from dbd in dbData
                                     join dl in dataList on dbd.InvoiceNo equals dl.InvoiceNo
                                     select new ShippingInvoiceExcelMigrationViewModel()
                                     {
                                         ExcelSerial = dl.ExcelSerial,
                                         InvoiceNo = dl.InvoiceNo,
                                         ShippingBillNo = dl.ShippingBillNo,
                                         ShippingDate = dl.ShippingDate
                                     }).ToList();
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        
            return duplicateData;
        }
    }
}

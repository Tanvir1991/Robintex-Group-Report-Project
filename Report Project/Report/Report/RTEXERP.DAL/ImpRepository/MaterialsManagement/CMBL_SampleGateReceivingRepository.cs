using AutoMapper;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class CMBL_SampleGateReceivingRepository : GenericRepository<CMBL_SampleGateReceiving>, ICMBL_SampleGateReceivingRepository
    {
        private MaterialsManagementDBContext dbCon;
        private IMapper mapper;
        public CMBL_SampleGateReceivingRepository(MaterialsManagementDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
        public async Task<RResult> SampleGateReceivingSave(CMBL_SampleGateReceivingViewModel model, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var SampleReceive = mapper.Map<CMBL_SampleGateReceivingViewModel, CMBL_SampleGateReceiving>(model);
                SampleReceive.DocumentDate = DateTime.Now;
                SampleReceive.UserID = createdBy;
                dbCon.CMBL_SampleGateReceiving.Add(SampleReceive);
                await dbCon.SaveChangesAsync();
                var TransactionList = new List<CMBL_StockTransaction>();

                int transactionDocumentNo = GetNextDocumentNo();
                
                foreach (var item in model.CMBL_SampleItemGateReceiving)
                {
                    var itemEntity = await dbCon.CMBL_SampleItem.FindAsync(item.SampleItemID);
                    var newItemEntity = itemEntity;
                    newItemEntity.Balance = itemEntity.Balance - item.ReceivedQuantity;
                    dbCon.Entry(itemEntity).CurrentValues.SetValues(newItemEntity);
                    
                    var storeLocation = 0;
                    if (SampleReceive.CompanyID == 183)//RobinTex
                    {
                        storeLocation = 958;
                    }
                    else if (SampleReceive.CompanyID == 20183)//CompTex
                    {
                        storeLocation = 956;
                    }
                    var transaction = new CMBL_StockTransaction
                    {
                        DocumentTypeID = 24,
                        DocumentNo= transactionDocumentNo,
                        TransactionDate = DateTime.Now,
                        ItemID = itemEntity.ItemID,
                        Quantity = (float)Math.Round((float)item.ReceivedQuantity*100/100,2),
                        UserSelectedUnit = itemEntity.UnitID,
                        Rate_WRTbaseUnit = (float)itemEntity.Rate,
                        StoreLocationID=storeLocation,
                        Status=2,
                        Deleted=0,
                        CompanyID=SampleReceive.CompanyID,
                        IRRID= itemEntity.RequisitionDetailID
                    };
                    TransactionList.Add(transaction);
                }
                dbCon.CMBL_StockTransaction.AddRange(TransactionList);

                var newSample = SampleReceive;
                newSample.SampleRecNo = SampleReceive.SampleID;
                dbCon.Entry(SampleReceive).CurrentValues.SetValues(newSample);
                await dbCon.SaveChangesAsync();

                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }

        private int GetNextDocumentNo()
        {
            var currentMaxNo = 24000;
            
            try
            {
                var currentList = dbCon.CMBL_StockTransaction.Where(x => x.DocumentTypeID == 24).ToList();
                if (currentList.Count>0)
                {
                     currentMaxNo= currentList.Max(m => m.DocumentNo);
                }
                currentMaxNo = currentMaxNo + 1;
            }
            catch (Exception e)
            {
                throw;
            }
            return currentMaxNo;
        }
    }
}

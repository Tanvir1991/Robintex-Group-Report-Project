using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class KnittingNeedleConsumptionMasterRepository : GenericRepository<KnittingNeedleConsumptionMaster>, IKnittingNeedleConsumptionMasterRepository
    {
        private MaterialsManagementDBContext dbCon;

        public KnittingNeedleConsumptionMasterRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<RResult> SaveKnittingNeedleConsumptionData(KnittingNeedleConsumptionMaster model)
        {
            var rResult = new RResult();
            try
            {
                if (model.ID == 0)
                {
                    await dbCon.KnittingNeedleConsumptionMaster.AddAsync(model);
                    await dbCon.SaveChangesAsync();
                    rResult.message = ReturnMessage.InsertMessage;
                }
                else
                {
                    if (model.ID>0)
                    {
                        var masterObj =  dbCon.KnittingNeedleConsumptionMaster.Where(b => b.ID == model.ID).FirstOrDefault();
                        masterObj.MachineNo = model.MachineNo;
                        masterObj.ConsumptionDate = model.ConsumptionDate;
                        masterObj.CompanyID = model.CompanyID;
                        masterObj.CreatedDate = DateTime.Now;
                        masterObj.CreatedBy = model.CreatedBy;
                        await dbCon.SaveChangesAsync();
                    }
                    var listOfObj = dbCon.KnittingNeedleConsumptionDetails.Where(b => b.KnittingNeedleConsumptionMasterID == model.ID).ToList();
                    foreach (var item in listOfObj)
                    {
                        var detailsobj = model.KnittingNeedleConsumptionDetails.Where(b => b.ID == item.ID && b.KnittingNeedleConsumptionMasterID == item.KnittingNeedleConsumptionMasterID).FirstOrDefault();
                        if(detailsobj != null)
                        {
                            item.Quantity = detailsobj.Quantity;
                            item.UnitRate = detailsobj.UnitRate;
                            await dbCon.SaveChangesAsync();
                        }
                        else
                        {
                            
                            item.IsRemoved = true;
                            item.UpdateddDate = DateTime.Now;
                            item.UpdatedBy = model.UpdatedBy;
                            await dbCon.SaveChangesAsync();

                        }
                       // await dbCon.SaveChangesAsync();

                    }


                    foreach (var ConsumptionDetails in model.KnittingNeedleConsumptionDetails)
                    {
                        if (ConsumptionDetails.ID == 0)
                        {
                            await dbCon.KnittingNeedleConsumptionDetails.AddAsync(ConsumptionDetails);
                            await dbCon.SaveChangesAsync();
                        }
                    }
                    rResult.message = ReturnMessage.UpdateMessage;

                }


                rResult.result = 1;
               
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return rResult;
        }

        private void SaveKnittingNeedleConsumptionDetails(KnittingNeedleConsumptionDetails item, int MasterID)
        {
            var detailsList = dbCon.KnittingNeedleConsumptionDetails.Where(b => b.KnittingNeedleConsumptionMasterID == MasterID).ToList();

            foreach (var details in detailsList)
            {
                if (details.ID == item.ID)
                {
                    dbCon.KnittingNeedleConsumptionDetails.Update(item);
                }
            }
            throw new NotImplementedException();
        }

        public async Task<List<KnittingNeedleConsumptionViewModel>> GetNittingNeedleConsumptionList()
        {
            List<KnittingNeedleConsumptionViewModel> knittingNeedle = new List<KnittingNeedleConsumptionViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetNittingNeedleConsuptionData")
                .ExecuteStoredProcAsync((handler) =>
                {
                    knittingNeedle = handler.ReadToList<KnittingNeedleConsumptionViewModel>() as List<KnittingNeedleConsumptionViewModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return knittingNeedle;
        }

        public async Task<List<KnittingNeedleConsumptionViewModel>> GetNittingNeedleConsuptionByCompanyIDAndMachineNo(DateTime dateFrom, DateTime dateTo, int companyID=0,int machineNo=0)
        {
            List<KnittingNeedleConsumptionViewModel> knittingNeedle = new List<KnittingNeedleConsumptionViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetNittingNeedleConsuptionByCompanyIDAndMachineNo")
                     .WithSqlParam("dateFrom", dateFrom)
                     .WithSqlParam("dateTo", dateTo)
                      .WithSqlParam("companyID", companyID)
                        .WithSqlParam("machineNo", machineNo)
                         
                            
                .ExecuteStoredProcAsync((handler) =>
                {
                    knittingNeedle = handler.ReadToList<KnittingNeedleConsumptionViewModel>() as List<KnittingNeedleConsumptionViewModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return knittingNeedle;
        }

        public async Task<KnittingNeedleConsumptionMasterViewModel> GetKnittingNeedleConsumptionMasterData(int ID)
        {
            var obj = await (from km in dbCon.KnittingNeedleConsumptionMaster
                                 // join knd in dbCon.KnittingNeedleConsumptionDetails on km.ID equals knd.KnittingNeedleConsumptionMasterID
                                 // join vw in dbCon.vw_CMBL_ItemALLAttribute on knd.ItemID equals vw.ItemID
                             where km.ID == ID && km.IsRemoved == false //&& knd.IsRemoved == false
                             select new KnittingNeedleConsumptionMasterViewModel()
                             {
                                 ID = km.ID,
                                 CompanyID = km.CompanyID,
                                 MachineNo = km.MachineNo,
                                 CreateDateTime = km.ConsumptionDate.ToString("dd-MMM-yyyy"),

                                 KnittingNeedleConsumptionDetails = (from knm in dbCon.KnittingNeedleConsumptionMaster
                                                                     join kd in dbCon.KnittingNeedleConsumptionDetails on knm.ID equals kd.KnittingNeedleConsumptionMasterID
                                                                     join vw in dbCon.vw_CMBL_ItemALLAttribute on kd.ItemID equals vw.ItemID
                                                                     join  krc in dbCon.KnittingRepairItemCategory on kd.KnittingRepairItemCategoryID equals krc.ItemCategoryID
                                                                     where knm.ID == ID && knm.IsRemoved == false && kd.IsRemoved == false && kd.KnittingNeedleConsumptionMasterID == ID
                                                                     select new KnittingNeedleConsumptionDetailsViewModel()
                                                                     {
                                                                         ID = kd.ID,
                                                                         KnittingNeedleConsumptionMasterID = kd.KnittingNeedleConsumptionMasterID,
                                                                         ItemID = kd.ItemID,
                                                                         Quantity = kd.Quantity,
                                                                         UnitID = kd.UnitID,
                                                                         UnitRate = kd.UnitRate,
                                                                         BroadGroupOne = (int)vw.L_1_AttributeID,
                                                                         BroadGroupTwo = (int)vw.L_2_AttributeID,
                                                                         BroadGroupThree = (int)vw.L_3_AttributeID,
                                                                         ItemName = vw.ItemName,
                                                                         KnittingRepairItemCategoryID=kd.KnittingRepairItemCategoryID,
                                                                         KnittingRepairItemCategoryName = krc.CategoryName,
                                                                     }).ToList()


                             }).FirstAsync();
            return obj;
        }
    }
}

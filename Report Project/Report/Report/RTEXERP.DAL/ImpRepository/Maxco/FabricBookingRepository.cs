using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class FabricBookingRepository : GenericRepository<FabricBooking>, IFabricBookingRepository
    {
        private MaxcoDBContext dbCon;
        public FabricBookingRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;
            //dbCon.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<RResult> FabricBookingSave(FabricBooking fabricBooking, bool? savechange)
        {
            RResult rResult = new RResult();
            try
            {
                dbCon.FabricBooking.Add(fabricBooking);
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

        public async Task<RResult> FabricBookingUpdate(int fabricBookingID,int updatedBy, bool? savechange)
        {
            RResult rResult = new RResult();
            try
            {
                //var entity = await dbCon.FabricBooking                 
                // .Include(x => x.FabricBookingMaster)                 
                // .ThenInclude(y => y.FabricBookingDetail)
                // .ThenInclude(z => z.FabricBookingSizeDetail)
                // .Where(a => a.FabricBookingID == fabricBookingID).FirstAsync();
                //entity.FabricBookingMaster.IsActive = false;
                //entity.FabricBookingMaster.FabricBookingDetail.ForEach(x =>
                //{
                //    x.IsActive = false; x.UpdatedBy = updatedBy; x.UpdatedDate = DateTime.Now;
                //    x.FabricBookingSizeDetail.ForEach(y => { y.IsActive = false; y.UpdatedBy = updatedBy; y.UpdatedDate = DateTime.Now; });
                //});
                var fabBook = await dbCon.FabricBooking.Where(x => x.FabricBookingID == fabricBookingID).FirstOrDefaultAsync();
                //var fabMaster = await dbCon.FabricBookingMaster.Where(x => x.IsActive == true && x.IsRemoved == false && x.FabricBookingID == fabricBookingID && x.Version == fabBook.CurrentVersion).FirstAsync();
                //var fabDetail = await dbCon.FabricBookingDetail.Where(x => x.IsActive == true && x.IsRemoved == false && x.BookingMasterID == fabMaster.BookingMasterID).ToListAsync();
                var entity = await dbCon.FabricBookingMaster                 
                 .Include(y => y.FabricBookingDetail)
                 .ThenInclude(z => z.FabricBookingSizeDetail)
                 .Where(a => a.FabricBookingID == fabricBookingID && a.Version==fabBook.CurrentVersion && a.IsActive==true && a.IsRemoved ==false).FirstAsync();
                entity.IsActive = false;
                entity.UpdatedBy = updatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.FabricBookingDetail.ForEach(x =>
                {
                    x.IsActive = false; x.UpdatedBy = updatedBy; x.UpdatedDate = DateTime.Now;
                    x.FabricBookingSizeDetail.ForEach(y => { y.IsActive = false; y.UpdatedBy = updatedBy; y.UpdatedDate = DateTime.Now; });
                });



                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<List<FabricBookingViewModel>> GetFabricBookingList(int OrderID = 0, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            DateTo = DateTo == null ? DateTime.Now: DateTo;
            DateFrom = DateFrom == null ? DateTo.Value.AddDays(-7) : DateFrom;         

            var data =await( from fb in dbCon.FabricBooking
                       join s in dbCon.Style on fb.OrderID equals s.ID
                where fb.IsActive == true && fb.IsRemoved == false && fb.CreatedDate >= DateFrom && fb.CreatedDate <= DateTo && (OrderID== 0 || fb.OrderID== OrderID)
                select new FabricBookingViewModel() { 
                    FabricBookingID= fb.FabricBookingID,
                    FabricBookingNo= fb.FabricBookingNo,
                    OrderID=fb.OrderID,
                    OrderNo=s.OrderNo,
                    CurrentVersion=fb.CurrentVersion
                }).ToListAsync();
            return data;
        }

        public async Task<RResult> UpdateCurrentVersionNo(int fabricBookingID, int updatedBy, bool? savechange)
        {
            RResult rResult = new RResult();
            var entity = await GetByIdAsync(fabricBookingID);
            entity.CurrentVersion += 1;
            entity.UpdatedBy = updatedBy;
            entity.UpdatedDate = DateTime.Now;
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            rResult.statusCode = entity.CurrentVersion;
            return rResult;
        }
        public async Task<List<SelectListItem>> DDLOrderWiseStyleForFabricBooking(int OrderID,int? FabricBookingID=0)
        {
            var styleList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetDDLOrderWiseStyleForFabricBooking")
                             .WithSqlParam("OrderID", OrderID)
                              .WithSqlParam("FabricBookingID", FabricBookingID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 styleList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                             });
                return styleList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<FabricBookingVersionViewModel>> FabricBookingVersions(int FabricBookingID, int OrderID)
        {
            try
            {
                var data = await (from b in dbCon.FabricBooking
                                  join bm in dbCon.FabricBookingMaster on b.FabricBookingID equals bm.FabricBookingID
                                  join byr in dbCon.Buyer_Setup on bm.BuyerID equals byr.ID
                                  join s in dbCon.Style on b.OrderID equals s.ID
                                  where b.IsActive == true && b.IsRemoved == false && b.FabricBookingID == FabricBookingID && b.OrderID == OrderID
                                  && bm.IsRemoved == false
                                  select new FabricBookingVersionViewModel()
                                  {
                                      BuyerID = byr.ID,
                                      BuyerName = byr.Description.Trim(),
                                      CreatedDateMsg = bm.CreatedDate.ToString("dd-MMM-yyyy"),
                                      DeliveryEndDateMsg = bm.DeliveryEndDate.ToString("dd-MMM-yyyy"),
                                      DeliveryStartDateMsg = bm.DeliveryStartDate.ToString("dd-MMM-yyyy"),
                                      FabricBookingID = b.FabricBookingID,
                                      BookingMasterID = bm.BookingMasterID,
                                      FabricBookingNo = b.FabricBookingNo,
                                      IsActive = bm.IsActive.Value,
                                      OrderID = (int)s.ID,
                                      OrderNo = s.OrderNo.Trim(),
                                      Reference = bm.Reference,
                                      Version = bm.Version
                                  }).OrderBy(x => x.Version).ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }          
            
        }


        //public async Task<RResult> UPdateAndInsertForReversion(FabricBooking model,int createdBy)
        //{
        //    //var entity = await dbCon.FabricBooking                 
        //    // .Include(x => x.FabricBookingMaster)                 
        //    // .ThenInclude(y => y.FabricBookingDetail)
        //    // .ThenInclude(z => z.FabricBookingSizeDetail)
        //    // .Where(a => a.FabricBookingID == fabricBookingID).FirstAsync();
        //    RResult oResult = new RResult();
        //    var currentVersion = await dbCon.FabricBooking
        //        .Where(b => b.FabricBookingID == model.FabricBookingID && b.IsRemoved == false && b.IsActive == true)
        //        .Include(b => b.FabricBookingMaster)
        //              .ThenInclude(c => c.FabricBookingDetail)
        //               .ThenInclude(d => d.FabricBookingSizeDetail)
        //                  .Where(f => f.FabricBookingMaster.IsActive == true 
        //                          && f.FabricBookingMaster.IsRemoved==false
        //                          && f.FabricBookingMaster.FabricBookingDetail.All(b=>b.IsRemoved==false && b.IsActive==true))
        //                  .FirstOrDefaultAsync();
        //    if(currentVersion ==null && currentVersion.FabricBookingID == 0)
        //    {
        //        oResult.result = 0;
        //        oResult.message = "Not Match.";
        //        return oResult;
        //    }
        //   // int newVersion = currentVersion.CurrentVersion + 1;
        //   // currentVersion.CurrentVersion = newVersion;
        //    currentVersion.FabricBookingMaster.IsActive = false;
        //    currentVersion.FabricBookingMaster.UpdatedBy = createdBy;
        //    currentVersion.FabricBookingMaster.UpdatedDate = DateTime.Now;

        //    currentVersion.FabricBookingMaster.FabricBookingDetail.ToList().ForEach(b => { b.IsActive = false;
        //        b.UpdatedBy = createdBy;b.UpdatedDate = DateTime.Now;
        //        b.FabricBookingSizeDetail.ToList().ForEach(C => { C.IsActive = false; C.UpdatedDate = DateTime.Now; C.UpdatedBy = createdBy; });
        //    });
        //    dbCon.FabricBooking.Update(currentVersion);
        //    await dbCon.SaveChangesAsync();

        //    var newData = await dbCon.FabricBooking.Where(b=>b.FabricBookingID==model.FabricBookingID).FirstOrDefaultAsync();
        //   // dbCon.Entry(newData).State =EntityState.Detached; // add this
        //    int newVersionNo = newData.CurrentVersion + 1;
        //    newData.CurrentVersion = newVersionNo;
        //    newData.UpdatedBy = createdBy;
        //    newData.UpdatedDate = DateTime.Now;
        //    newData.FabricBookingMaster = model.FabricBookingMaster;
        //    newData.FabricBookingMaster.FabricBookingID = 0;
        //    newData.FabricBookingMaster.Version = newVersionNo;
        //    await dbCon.SaveChangesAsync();
        //    //  dbCon.FabricBooking.Update(newData);



        //    // newMaster.Version = newVersion;
        //    //currentVersion.FabricBookingMaster = newMaster;

        //    /*
        //    fabricBookingMaster.BuyerID = newMaster.BuyerID;
        //    fabricBookingMaster.CreatedBy = newMaster.CreatedBy;
        //    fabricBookingMaster.CreatedDate = newMaster.CreatedDate;
        //    fabricBookingMaster.DeliveryEndDate = newMaster.DeliveryEndDate;
        //    fabricBookingMaster.DeliveryStartDate = newMaster.DeliveryStartDate;
        //    fabricBookingMaster.IsActive = newMaster.IsActive;
        //    fabricBookingMaster.IsRemoved = newMaster.IsRemoved;
        //    fabricBookingMaster.OrderID = newMaster.OrderID;
        //    fabricBookingMaster.Reference = newMaster.Reference;
        //    fabricBookingMaster.RevisionReason = newMaster.RevisionReason;
        //    fabricBookingMaster.Version = newVersion;
        //    */


        //    oResult.result = 1;
        //    oResult.message = "";

        //    return oResult;
        //}
    }
}

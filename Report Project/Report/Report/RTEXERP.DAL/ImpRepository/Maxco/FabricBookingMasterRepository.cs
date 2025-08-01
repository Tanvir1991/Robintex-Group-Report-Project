using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.SPModel.FabricBooking;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class FabricBookingMasterRepository : GenericRepository<FabricBookingMaster>, IFabricBookingMasterRepository
    {
        private MaxcoDBContext dbCon;

        public FabricBookingMasterRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;
            //dbCon.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public async Task<RResult> FabricBookingMasterSave(List<FabricBookingMaster> entity, bool? savechange)
        {
            RResult rResult = new RResult();

            dbCon.FabricBookingMaster.AddRange(entity);           
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.InsertMessage;
            return rResult;
        }

        public async Task<List<FRSFabricForBooking>> GETFRSFabricForBooking(string StyleXML)
        {
            var bookingList = new List<FRSFabricForBooking>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GETFRSFabricForBooking")
                             .WithSqlParam("StyleXML", StyleXML)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 bookingList = handler.ReadToList<FRSFabricForBooking>() as List<FRSFabricForBooking>;
                             });
                return bookingList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

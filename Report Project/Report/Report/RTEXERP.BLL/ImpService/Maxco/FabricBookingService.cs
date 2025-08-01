using AutoMapper;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Transactions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class FabricBookingService : IFabricBookingService
    {
        private readonly IFabricBookingRepository fabricBookingRepository;
        private readonly IMapper mapper;
        private readonly IFabricBookingMasterRepository fabricBookingMasterRepository;
        private readonly ILogger<FabricBookingService> _loger;

        public FabricBookingService(IFabricBookingRepository _fabricBookingRepository, IMapper _mapper, IFabricBookingMasterRepository _fabricBookingMasterRepository
            , ILogger<FabricBookingService> loger)
        {
            fabricBookingRepository = _fabricBookingRepository;
            mapper = _mapper;
            fabricBookingMasterRepository = _fabricBookingMasterRepository;
            _loger = loger;
        }

        public async Task<List<SelectListItem>> DDLOrderWiseStyleForFabricBooking(int OrderID, int? FabricBookingID = 0)
        {
            return await fabricBookingRepository.DDLOrderWiseStyleForFabricBooking(OrderID, FabricBookingID);
        }

        public async Task<RResult> FabricBookingSave(FabricBookingViewModel fabricBooking, int createdBy, bool? savechange)
        {
            RResult rResult = new RResult();

            //using(TransactionScope scope=new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{
                try
                {
                    var entity = mapper.Map<FabricBookingViewModel, FabricBooking>(fabricBooking);
                    entity.IsActive = true;
                    entity.IsRemoved = false;
                    entity.CreatedBy = createdBy;
                    entity.CreatedDate = DateTime.Now;
                entity.FabricBookingMaster.ForEach(x =>
                {
                    x.IsActive = true; x.IsRemoved = false; x.CreatedBy = createdBy; x.CreatedDate = DateTime.Now;
                    x.FabricBookingDetail.ForEach(y =>
                    {
                        y.IsActive = true; y.IsRemoved = false; y.CreatedBy = createdBy; y.CreatedDate = DateTime.Now;
                        y.FabricBookingSizeDetail.ForEach(z => { z.IsActive = true; z.IsRemoved = false; z.CreatedBy = createdBy; z.CreatedDate = DateTime.Now; });
                    });
                });
                //entity.FabricBookingMaster.ForEach(b=> { b.IsActive.Value == true;b.isre })
                    //entity.FabricBookingMaster.IsActive = true;
                    //entity.FabricBookingMaster.IsRemoved = false;
                    //entity.FabricBookingMaster.CreatedBy = createdBy;
                    //entity.FabricBookingMaster.CreatedDate = DateTime.Now;
                    //entity.FabricBookingMaster.FabricBookingDetail.ForEach(x =>
                    //{
                    //    x.IsActive = true; x.IsRemoved = false; x.CreatedBy = createdBy; x.CreatedDate = DateTime.Now;
                    //    x.FabricBookingSizeDetail.ForEach(z => { z.IsActive = true; z.IsRemoved = false; z.CreatedBy = createdBy; z.CreatedDate = DateTime.Now; });
                    //});

                    if (fabricBooking.FabricBookingID == 0)
                    {
                        var existingBookings = await fabricBookingRepository.FindAllAsync(x => x.OrderID == fabricBooking.OrderID && x.IsRemoved==false);
                        var bookingNo = $"FB-{fabricBooking.OrderNo}-{existingBookings.Count + 1}";
                        entity.FabricBookingNo = bookingNo;
                        entity.OrderID = fabricBooking.OrderID;
                        entity.CurrentVersion = 1;
                        entity.FabricBookingMaster[0].Version = 1;
                        rResult = await fabricBookingRepository.FabricBookingSave(entity, savechange);
                    }
                    else
                    {
                    
                        rResult = await fabricBookingRepository.FabricBookingUpdate(fabricBooking.FabricBookingID, createdBy, savechange);
                        rResult = await fabricBookingRepository.UpdateCurrentVersionNo(fabricBooking.FabricBookingID, createdBy, savechange);
                        entity.FabricBookingMaster[0].FabricBookingID = fabricBooking.FabricBookingID;
                        entity.FabricBookingMaster[0].Version = rResult.statusCode;
                    //var BookingMaster = await fabricBookingRepository.GetByIdAsync(fabricBooking.FabricBookingID);
                    //  BookingMaster.FabricBookingMaster=entity.FabricBookingMaster;
                    List<FabricBookingMaster> reviseBookingMaster = new List<FabricBookingMaster>();
                    reviseBookingMaster = entity.FabricBookingMaster;
                    reviseBookingMaster.ForEach(x => { x.FabricBookingID = fabricBooking.FabricBookingID; });
                    rResult = await fabricBookingMasterRepository.FabricBookingMasterSave(reviseBookingMaster, true);

                    //await fabricBookingRepository.UpdateAsync(BookingMaster, BookingMaster.FabricBookingID, true);

                    //rResult = await fabricBookingRepository.UPdateAndInsertForReversion(entity, createdBy);
                }
                   // scope.Complete();
                }
                catch (Exception e)
                {
                   // scope.Dispose();
                    throw new Exception(e.Message);
                }
          //  }            

            return rResult;
        }

        public async Task<List<FabricBookingVersionViewModel>> FabricBookingVersions(int FabricBookingID, int OrderID)
        {
            return await fabricBookingRepository.FabricBookingVersions(FabricBookingID, OrderID);
        }

        public async Task<List<FabricBookingViewModel>> GetFabricBookingList(int OrderID = 0, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            return await fabricBookingRepository.GetFabricBookingList(OrderID, DateFrom, DateTo);
        }

        public async Task<FabricBookingMasterViewModel> GetFabticBookingMasterByBookingID(int FabricBookingID)
        {
            var entity = await fabricBookingMasterRepository.FindAsync(x => x.IsActive == true && x.IsRemoved == false && x.FabricBookingID == FabricBookingID);
            var model = mapper.Map<FabricBookingMaster, FabricBookingMasterViewModel>(entity);
            return model;

        }
    }
}

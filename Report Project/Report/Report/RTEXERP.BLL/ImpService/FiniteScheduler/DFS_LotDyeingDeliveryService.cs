using AutoMapper;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class DFS_LotDyeingDeliveryService : IDFS_LotDyeingDeliveryService
    {
        private readonly IDFS_LotDyeingDeliveryRepository _dfs_lotDyeingDeliveryRepository;
        private readonly IMapper _mapper;

        public DFS_LotDyeingDeliveryService(IDFS_LotDyeingDeliveryRepository dfs_lotDyeingDeliveryRepository, IMapper mapper)
        {
            _dfs_lotDyeingDeliveryRepository = dfs_lotDyeingDeliveryRepository;
            _mapper = mapper;
        }
        public async Task<List<DFS_LotDyeingDeliveryVM>> GetLotDyeingDelivery(DateTime DateFrom, DateTime DateTo)
        {
            var data = await this._dfs_lotDyeingDeliveryRepository.GetLotDyeingDelivery(DateFrom, DateTo);
            return data;
        }

        public async Task<RResult> Insert(DFS_LotDyeingDeliveryVM model)
        {
            RResult rResult = new RResult();
            try
            {
                var isExist =await _dfs_lotDyeingDeliveryRepository.FindAllAsync(b => b.IsRemoved == false && b.LotID == model.LotID);
                if(isExist != null && isExist.Count > 0)
                {
                    rResult.result = 0;
                    rResult.message="This LOT already Exist.";
                    return rResult;
                }

                var dbModel = _mapper.Map<DFS_LotDyeingDeliveryVM, DFS_LotDyeingDelivery>(model);
                dbModel.IsRemoved = false;
                dbModel.CreatedDate = DateTime.Now;
                dbModel.CreatedBy = model.UserID;
                await _dfs_lotDyeingDeliveryRepository.InsertAsync(dbModel, true);
                rResult.result = 1;
                rResult.message = "Successfully insertd data.";
            }
            catch (Exception e)
            {
                rResult.result = 0;

            }
            return rResult;
        }

        public async Task<RResult> Remove(DFS_LotDyeingDeliveryVM model)
        {
            RResult oresult = new RResult();
            oresult.result = 0;
          
            var dbData = await _dfs_lotDyeingDeliveryRepository.FindAsync(b=>b.ID==model.ID && b.IsRemoved==false);
            if (dbData != null)
            {
                dbData.IsRemoved = true;
                dbData.UpdatedBy = model.UserID;
                dbData.UpdatedDate = DateTime.Now;
                dbData.Remarks = $"{dbData.Remarks},Del:{model.Remarks}";
                await _dfs_lotDyeingDeliveryRepository.UpdateAsync(dbData, model.ID, true);
                oresult.result = 1;
                oresult.message = "Successfully Removed.";
 }
            return oresult;
        }

        public async Task<RResult> Update(DFS_LotDyeingDeliveryVM model)
        {
            RResult oresult = new RResult();
            oresult.result = 0;
            var isExist = await _dfs_lotDyeingDeliveryRepository.FindAllAsync(b => b.IsRemoved == false && b.LotID == model.LotID && b.ID != model.ID);
            if (isExist != null && isExist.Count > 0)
            {
                oresult.result = 0;
                oresult.message = "This LOT already Exist.";
                return oresult;
            }
            var dbData = await _dfs_lotDyeingDeliveryRepository.FindAsync(b => b.ID == model.ID && b.IsRemoved == false);
            if (dbData != null)
            {
                dbData.LotID = model.LotID;
                dbData.LotConfirmDate = model.LotConfirmDate;
             
                dbData.UpdatedBy = model.UserID;
                dbData.UpdatedDate = DateTime.Now;
                dbData.Remarks = $"{dbData.Remarks},UP:{model.Remarks}";
                await _dfs_lotDyeingDeliveryRepository.UpdateAsync(dbData, model.ID, true);
                oresult.result = 1;
                oresult.message = "Successfully Update.";
            }
            return oresult;
        }
    }
}

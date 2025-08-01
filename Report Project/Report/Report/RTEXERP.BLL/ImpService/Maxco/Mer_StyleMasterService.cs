using AutoMapper;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class Mer_StyleMasterService : IMer_StyleMasterService
    {
        private readonly IMer_StyleMasterRepository _mer_OrderMasterRepository;
        private readonly IMapper mapper;
        public Mer_StyleMasterService(IMer_StyleMasterRepository mer_OrderMasterRepository,IMapper _mapper)
        {
            _mer_OrderMasterRepository = mer_OrderMasterRepository;
            mapper = _mapper;
        }

        public async Task<List<MerOrderShipmentSPModel>> GetMerOrderShipment(int ZoneID = 0, string StyleNo = "", DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            return await _mer_OrderMasterRepository.GetMerOrderShipment(ZoneID, StyleNo, DateFrom, DateTo);
            
        }

        public async Task<string> GetNexProgramNumber(string Prefix)
        {
            return await _mer_OrderMasterRepository.GetNexProgramNumber(Prefix);
        }

        public async Task<RResult> OrderMasterSave(Mer_StyleMasterVM model, int createdBy)
        {
            try
            {
                var entity = mapper.Map<Mer_StyleMasterVM, Mer_StyleMaster>(model);
                entity.Program = await GetNexProgramNumber($"{model.ZoneCode}-{DateTime.Now:yy}-{model.SeasonCode}-");
                entity.CreatedBy = createdBy;
                entity.CreatedDate = DateTime.Now;
                entity.IsActive = true;
                entity.IsRemoved = false;
                entity.Mer_StylePODetail.ToList().ForEach(b => {
                    b.IsActive = true; b.IsRemoved = false; b.CreatedBy = createdBy; b.CreatedDate = DateTime.Now;
                    b.Mer_StylePOColorSizeQuantityDetail.ToList().ForEach(x => { x.IsActive = true; x.IsRemoved = false; x.CreatedBy = createdBy; x.CreatedDate = DateTime.Now; });
                });

                return await _mer_OrderMasterRepository.OrderMasterSave(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}

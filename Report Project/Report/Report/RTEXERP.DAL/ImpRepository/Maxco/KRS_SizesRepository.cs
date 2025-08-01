using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class KRS_SizesRepository : GenericRepository<KRS_Sizes>, IKRS_SizesRepository
    {
        private MaxcoDBContext dbCon;
        public KRS_SizesRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<KRS_SizesViewModel>> GetKRS_MasterWiseSizes(int KRS_MID, long AttributeInstanceID)
        {
            var query = await(from d in dbCon.KRS_DETAIL
                        join s in dbCon.KRS_Sizes on d.ID equals s.KRSDID
                        join t in dbCon.FabricTrims_Setup on s.FabricTrimID equals t.ID
                        where d.KRS_MID == KRS_MID && s.FRSAttributeInstanceID == AttributeInstanceID
                        select  new KRS_SizesViewModel() { 
                            KRSSID=s.KRSSID,
                            KRSDID=s.KRSDID,
                            SizeID=s.SizeID,
                            Len=s.Len,
                            Wid=s.Wid,
                            Color=s.Color,
                            Quantity=s.Quantity,
                            WeightConsumption=s.WeightConsumption,
                            FRSAttributeInstanceID=s.FRSAttributeInstanceID,
                            Pantone=s.Pantone,
                            FabricTrimID=s.FabricTrimID,
                            FabricTrimName=t.Description.Trim(),
                            SizeName=s.SizeName
                        }).ToListAsync();
            return query;
        }
    }
}

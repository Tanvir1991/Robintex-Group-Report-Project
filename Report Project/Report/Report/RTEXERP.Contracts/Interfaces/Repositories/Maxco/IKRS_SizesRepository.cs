using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
    public interface IKRS_SizesRepository
    {
        Task<List<KRS_SizesViewModel>> GetKRS_MasterWiseSizes(int KRS_MID, long AttributeInstanceID);
    }
}

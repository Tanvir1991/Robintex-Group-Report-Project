using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class MarkerCuttingSizes_ExcelRepository : GenericRepository<MarkerCuttingSizes_Excel>, IMarkerCuttingSizes_ExcelRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public MarkerCuttingSizes_ExcelRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<OrderWiseMarkerInfoViewModel>> GetMarkerCuttingSizesExcel_ByOrder(string orderNo, string color, int MarkerCuttingPlanMaster_ExcelID)
        {
            var markerList = new List<OrderWiseMarkerInfoViewModel>();
            try
            {
                var _MCPMaster = dbCon.MarkerCuttingPlanMaster_Excel.Where(x => x.OrderNo == orderNo && x.Color == color);

                if (MarkerCuttingPlanMaster_ExcelID > 0)
                {
                    _MCPMaster = _MCPMaster.Where(x => x.MCPMasterID == MarkerCuttingPlanMaster_ExcelID);
                }

                var MCPMaster = await _MCPMaster.FirstOrDefaultAsync();

                if (MCPMaster != null)
                {
                    var MCPMasterID = MCPMaster.MCPMasterID;
                    markerList = await dbCon.MarkerCuttingInfo_Excel.Where(x => x.MCPMasterID == MCPMasterID)
                        .Select(r => new OrderWiseMarkerInfoViewModel()
                        {
                            MCPMasterID = r.MCPMasterID,
                            MCInfoID = r.MCInfoID,
                            MarkerSerial = r.MarkerSerial,
                            Marker = $"Marker-{r.MarkerSerial}({r.InfoType})",
                            ReceivedDIA = MCPMaster.Dia
                        }).OrderBy(x => x.MarkerSerial).ToListAsync();
                    foreach (var item in markerList)
                    {
                        item.MarkerSizeInfo = await dbCon.MarkerCuttingSizes_Excel.Where(x => x.MCInfoID == item.MCInfoID)
                            .Select(r => new MarkerSizeInfoViewModel()
                            {
                                Size = r.Size.Replace("/P", ""),
                                SizeSerial = r.SizeSerial,
                                SizeValue = r.SizeValue
                            }).OrderBy(x => x.SizeSerial).ToListAsync();
                    }
                }
                return markerList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<MarkerSizeInfoViewModel>> GetMarkerShortCuttingSizesExcel_ByOrder(string orderNo, string pantoneNo, int quantity)
        {
            var MarkerSizeInfoList = new List<MarkerSizeInfoViewModel>();
            try
            {
                var MCPMaster = await dbCon.MarkerCuttingPlanMaster_Excel.Where(x => x.OrderNo == orderNo && x.Color==pantoneNo && x.TotalQty==quantity).FirstOrDefaultAsync();
                if (MCPMaster != null)
                {
                    var MCPMasterID = MCPMaster.MCPMasterID;
                    var markerCuttingInfo = await dbCon.MarkerCuttingInfo_Excel.Where(x => x.MCPMasterID == MCPMasterID).FirstOrDefaultAsync();
                    if (markerCuttingInfo != null)
                    {
                        MarkerSizeInfoList = await dbCon.MarkerCuttingSizes_Excel.Where(x => x.MCInfoID == markerCuttingInfo.MCInfoID)
                            .Select(r => new MarkerSizeInfoViewModel()
                            {
                                Size = r.Size,
                                SizeSerial = r.SizeSerial,
                                SizeValue = r.SizeValue
                            }).OrderBy(x => x.SizeSerial).ToListAsync();
                    }

                }
                return MarkerSizeInfoList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

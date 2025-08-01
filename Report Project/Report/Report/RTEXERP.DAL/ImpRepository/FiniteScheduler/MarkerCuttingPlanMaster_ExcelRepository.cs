using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RTEXERP.DAL.ImpRepository.MaterialsManagement;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class MarkerCuttingPlanMaster_ExcelRepository : GenericRepository<MarkerCuttingPlanMaster_Excel>, IMarkerCuttingPlanMaster_ExcelRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public MarkerCuttingPlanMaster_ExcelRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLOrderWiseColor(string orderNo)
        {
            var colorList = await dbCon.MarkerCuttingPlanMaster_Excel
                .Where(x => x.OrderNo == orderNo)
                .Select(x => new SelectListItem()
                {
                    Text = $"{x.Color}-(Quantity={x.TotalQty+x.TotalPetitQty})",
                    Value = x.Color.Trim()
                }).ToListAsync();
            return colorList;
        }

        public async Task<List<DropDownItem>> DDLOrderWiseColorCustome(string orderNo)
        {
            var colorList = await dbCon.MarkerCuttingPlanMaster_Excel
                .Where(x => x.OrderNo == orderNo)
                .Select(x => new DropDownItem()
                {
                    Text = $"{x.Color}-(Quantity={x.TotalQty+x.TotalPetitQty})",
                    Value = x.Color.Trim(),
                    Custome1 = x.MCPMasterID.ToString(),
                    Custome2= $"{x.TotalQty + x.TotalPetitQty}"

                }).ToListAsync();
            return colorList;
        }

        public async Task<List<SelectListItem>> DDLOrderWiseMarker(string orderNo)
        {
            var markerList = new List<SelectListItem>();
            try
            {
                var markerSizeList = await (from p in dbCon.MarkerCuttingPlanMaster_Excel
                                            join i in dbCon.MarkerCuttingInfo_Excel on p.MCPMasterID equals i.MCPMasterID
                                            where (p.OrderNo == orderNo)
                                            select new MarkerCuttingInfo_Excel()
                                            {
                                                MCInfoID = i.MCInfoID,
                                                MarkerSerial = i.MarkerSerial
                                            }).OrderBy(x => x.MarkerSerial).ToListAsync();

                markerList = markerSizeList.Select(x => new SelectListItem()
                {
                    Text = $"Marker-{x.MarkerSerial}",
                    Value = x.MCInfoID.ToString()
                }).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }            

            return markerList;
        }

        //public async Task<RResult> LotWiseCuttingInfoUpdate(MarkerCuttingPlanMaster_Excel cuttingPlanMaster)
        //{
        //    RResult rResult = new RResult();
        //    try
        //    {
        //        if (cuttingPlanMaster.Dia>0 || cuttingPlanMaster.InspectionPcs>0 || cuttingPlanMaster.PanelRejectPcs>0)
        //        {
        //            var entity = await dbCon.MarkerCuttingPlanMaster_Excel.Where(x => x.OrderNo == cuttingPlanMaster.OrderNo && x.Color == cuttingPlanMaster.Color).FirstAsync();
        //            if (cuttingPlanMaster.Dia > 0)
        //            {
        //                entity.Dia = cuttingPlanMaster.Dia;
        //            }
        //            if (cuttingPlanMaster.InspectionPcs > 0)
        //            {
        //                entity.InspectionPcs = cuttingPlanMaster.InspectionPcs;
        //            }
        //            if (cuttingPlanMaster.PanelRejectPcs > 0)
        //            {
        //                entity.PanelRejectPcs = cuttingPlanMaster.PanelRejectPcs;
        //            }
        //            await dbCon.SaveChangesAsync();
        //            rResult.result = 1;
        //            rResult.message = ReturnMessage.UpdateMessage;
        //        }                

        //    }
        //    catch (Exception e)
        //    {
        //        rResult.result = 0;
        //        rResult.message = ReturnMessage.ErrorMessage;
        //        throw new Exception(e.Message);
        //    }
        //    return rResult;
        //}

        public async Task<RResult> MarkerCuttingPlanMaster_ExcelRemove(string orderNo, string color)
        {
            RResult rResult = new RResult();
            try
            {
                var entity = await dbCon.MarkerCuttingPlanMaster_Excel
                .Include(x => x.MarkerCuttingInfo_Excel)
                .ThenInclude(y => y.MarkerCurringSizes_Excel)
                .Include(x => x.MarkerCuttingInfo_Excel)
                .ThenInclude(z => z.MarkerCuttingConsumption_Excel)
                .Include(x => x.MarkerCuttingFabricDetail_Excel)
                .Where(x => x.OrderNo == orderNo && x.Color == color).FirstOrDefaultAsync();
                if (entity != null)
                {
                    dbCon.MarkerCuttingPlanMaster_Excel.Remove(entity);
                    await dbCon.SaveChangesAsync();                   
                }
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }
            catch (Exception e)
            {
                throw  new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<RResult> MarkerCuttingPlanMaster_ExcelSave(MarkerCuttingPlanMaster_Excel excelData)
        {
            RResult rResult = new RResult();
            try
            {

                var isExistWithSameQuantity = await dbCon.MarkerCuttingPlanMaster_Excel.Where(b => b.OrderNo == excelData.OrderNo
                  && b.Color == excelData.Color
                  && (b.TotalQty + b.TotalPetitQty) == (excelData.TotalQty + excelData.TotalPetitQty)).ToListAsync();
                if (isExistWithSameQuantity.Count > 0)
                {
                    var deleteResult = await this.MarkerCuttingPlanMaster_ExcelRemove(excelData.OrderNo, excelData.Color, (excelData.TotalQty + excelData.TotalPetitQty));
                }


                dbCon.MarkerCuttingPlanMaster_Excel.Add(excelData);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }


        public async Task<RResult> MarkerCuttingPlanMaster_ExcelRemove(string orderNo, string color,int QuantityWithPetit )
        {
            RResult rResult = new RResult();
            try
            {
                var entity = await dbCon.MarkerCuttingPlanMaster_Excel
                .Include(x => x.MarkerCuttingInfo_Excel)
                .ThenInclude(y => y.MarkerCurringSizes_Excel)
                .Include(x => x.MarkerCuttingInfo_Excel)
                .ThenInclude(z => z.MarkerCuttingConsumption_Excel)
                .Include(x => x.MarkerCuttingFabricDetail_Excel)
                .Where(x => x.OrderNo == orderNo && x.Color == color && (x.TotalQty+x.TotalPetitQty)==QuantityWithPetit).FirstOrDefaultAsync();
                if (entity != null)
                {
                    dbCon.MarkerCuttingPlanMaster_Excel.Remove(entity);
                    await dbCon.SaveChangesAsync();
                }
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}

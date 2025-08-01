
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class Mer_StyleMasterRepository : GenericRepository<Mer_StyleMaster>, IMer_StyleMasterRepository
    {
        private MaxcoDBContext dbCon;
        public Mer_StyleMasterRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<MerOrderShipmentSPModel>> GetMerOrderShipment(int ZoneID = 0, string StyleNo="", DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var itemList = new List<MerOrderShipmentSPModel>();
            try
            {              

                   await dbCon.LoadStoredProc("rpt.usp_Get_MerOrderShipment")
                            .WithSqlParam("ZoneID", ZoneID)
                            .WithSqlParam("StyleNo", StyleNo)
                            .WithSqlParam("DateFrom", DateFrom)
                            .WithSqlParam("DateTo", DateTo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<MerOrderShipmentSPModel>() as List<MerOrderShipmentSPModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> GetNexProgramNumber(string Prefix)
        {

            DbParameter NewProgram = null;

            try
            {

                await dbCon.LoadStoredProc("ajt.usp_MEROrderNextProgramNumber")
                      .WithSqlParam("PreFix", Prefix)
                      .WithSqlParam("NewProgram", (dbParam) =>
                      {
                          dbParam.Direction = System.Data.ParameterDirection.Output;
                          dbParam.DbType = System.Data.DbType.AnsiString;
                          dbParam.Size = 30;
                          NewProgram = dbParam;
                      })
                      .ExecuteStoredNonQueryAsync();

                string rtnNewProgram = (string)NewProgram.Value;
                return rtnNewProgram;

                /*
                var outParameter = new SqlParameter("@NewProgram", DbType.String)
                {
                    Direction = ParameterDirection.Output
                };

                await dbCon.Database.ExecuteSqlCommandAsync($"exec ajt.usp_MEROrderNextProgramNumber  '${Prefix}', @NewProgram Varchar(30) OUT", outParameter);
                var result = (string)outParameter.Value;
                return result;
                */

            }
            catch (Exception e)
            {
                var aa = e.Message;
                throw new Exception();
            }
        }

        public async Task<RResult> OrderMasterSave(Mer_StyleMaster model)
        {
            RResult rResult = new RResult();
            try
            {
                await dbCon.Mer_StyleMaster.AddAsync(model);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}

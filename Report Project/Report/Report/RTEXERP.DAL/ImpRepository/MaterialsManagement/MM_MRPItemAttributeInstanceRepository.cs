using DocumentFormat.OpenXml.Vml.Office;
using RTEXERP.Common.Constants;
using RTEXERP.Contracts.BLModels.MaterialsManagement.AttributeInfo;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
   public class MM_MRPItemAttributeInstanceRepository :GenericRepository<MM_MRPItem>, IMM_MRPItemAttributeInstanceRepository
    {
        private MaterialsManagementDBContext dbCon;

        public MM_MRPItemAttributeInstanceRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<MRPAttributes> GetForAttributeInstanceXMLToObject(long AttributeinstanceID)
        {
            var itemList = new List<AttributesXMLSP>();
            MRPAttributes rtnModel = new MRPAttributes();
            XMLSerializer xmlToData = new XMLSerializer();
            try
            {
                await dbCon.LoadStoredProc("MM_MRPItemAttributeSetValues_GetForAttributeInstanceDirect")
                                .WithSqlParam("biAttributeInstanceID", AttributeinstanceID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<AttributesXMLSP>() as List<AttributesXMLSP>;
                             });
                var xmlData = itemList[0].AttributesXML;
                var model = xmlToData.Deserialize<MRPAttributes>(xmlData);
                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        
    }


    public class AttributesXMLSP
    {
        public string AttributesXML { get; set; }
    }
}

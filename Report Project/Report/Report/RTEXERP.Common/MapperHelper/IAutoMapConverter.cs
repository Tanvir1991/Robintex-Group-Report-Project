using System.Collections.Generic;

namespace RTEXERP.Common.MapperHelper
{
    public interface IAutoMapConverter<TSourceObj, TDestinationObj>
                where TSourceObj : class
                where TDestinationObj : class
    {
        TDestinationObj ConvertObject(TSourceObj srcObj);
        List<TDestinationObj> ConvertObjectCollection(IEnumerable<TSourceObj> srcObj);
        List<TDestinationObj> ConvertObjectList(List<TSourceObj> srcObj);
    }
}

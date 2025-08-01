using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RTEXERP.Contracts.Common
{
    
    public class DynamicObjectCast
    {
        //This lives in a helper class
        public T ConvertDynamic<T>(object data)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(data));
        }

       

    }
    

}

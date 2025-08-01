using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.Common
{
    /// <summary>
    /// Any Method Return 
    /// </summary>
    public class RResult
    {
        /// <summary>
        /// Return Result 0="Unsuccessfull" or 1 = Sucessfull
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// Action return message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Single Data
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// Data List
        /// </summary>
        public object dataList { get; set; }

        /// <summary>
        /// When Duplicate Check then Use this
        /// 0 = Unique Data
        /// 1= Duplicate Data
        /// </summary>
        public bool isDuplicate { get; set; }
        public long longId { get; set; }
        public int statusCode { get; set; }
        public string statusMsg { get; set; }

   

    }

    public class RResult<T> where T : class
    {
        /// <summary>
        /// Return Result 0="Unsuccessfull" or 1 = Sucessfull
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// Action return message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Single Data
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// Data List
        /// </summary>
        public object dataList { get; set; }

        /// <summary>
        /// When Duplicate Check then Use this
        /// 0 = Unique Data
        /// 1= Duplicate Data
        /// </summary>
        public bool isDuplicate { get; set; }

        public int statusCode { get; set; }
        public string statusMsg { get; set; }

        public T modelObject { get; set; }
        public List<T> modelObjectList { get; set; }

    }
}

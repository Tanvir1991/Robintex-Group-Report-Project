using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.PageRequest
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public class PaginationRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Sort Sort { get; set; }
        //public PaginationRequest()
        //{
        //    this.Sort = new Sort();
        //}
    }

    public class Sort
    {
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}

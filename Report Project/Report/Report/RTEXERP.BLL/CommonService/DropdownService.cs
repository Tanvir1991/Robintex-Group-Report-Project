using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
 
using System.Collections.Generic;

namespace RTEXERP.BLL.CommonService
{
    public class DropdownService : IDropdownService
    {
        public List<SelectListItem> DefaultDDL()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = RTEXERP.SResources.Resources.Resource.PleaseSelect, Value = "" });
            return list;
        }
        public List<SelectListItem> BooleanDDL(bool? IsIncludeDefaultItem = false, bool? defaultSelected = true)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefaultItem == true)
            {
                list = DefaultDDL();
            }
            list.Add(new SelectListItem() { Text = "True", Value = "true", Selected = true == defaultSelected ? true : false });
            list.Add(new SelectListItem() { Text = "False", Value = "false", Selected = false == defaultSelected ? true : false });
            return list;
        }
        public List<SelectListItem> NumberDDL(int min, int max, bool IsIncludeDefaultItem, int? defaultSelected = 0)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefaultItem == true)
            {
                list = DefaultDDL();
            }
            for (; min <= max; min++)
            {
                list.Add(new SelectListItem() { Text = min.ToString(), Value = min.ToString(), Selected = min == defaultSelected ? true : false });
            }

            return list;
        }

        public List<SelectListItem> NumberDDL(int min, int max, string extraText, bool IsIncludeDefaultItem, int? defaultSelected = 0)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefaultItem == true)
            {
                list = DefaultDDL();
            }
            for (; min <= max; min++)
            {
                list.Add(new SelectListItem() { Text = min.ToString() + extraText, Value = min.ToString(), Selected = min == defaultSelected ? true : false });
            }

            return list;
        }

        public List<SelectListItem> RenderDDL(List<SelectListItem> listItems)
        {
            var list = DefaultDDL();
            list.AddRange(listItems);
            return list;
        }
        public List<DropDownItem> RenderDDLCustome(List<DropDownItem> listItems, bool? IsIncludeDefaultItem)
        {
            var list = new List<DropDownItem>();
            list.Add(new DropDownItem() { Text = RTEXERP.SResources.Resources.Resource.PleaseSelect, Value = "" });
            list.AddRange(listItems);
            return list;
        }
        public List<DropDownItem> RenderDDLCustome(List<DropDownItem> listItems)
        {
            var list = new List<DropDownItem>();
            list.Add(new DropDownItem() { Text = RTEXERP.SResources.Resources.Resource.PleaseSelect, Value = "" });
            list.AddRange(listItems);
            return list;
        }
        public List<SelectListItem> RenderDDL(List<SelectListItem> listItems, bool? IsIncludeDefaultItem = false)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefaultItem == true)
            {
                list = DefaultDDL();
            }
            list.AddRange(listItems);
            return list;
        }


    }
}

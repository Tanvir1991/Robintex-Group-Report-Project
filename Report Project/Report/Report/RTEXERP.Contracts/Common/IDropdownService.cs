using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RTEXERP.Contracts.Common
{
    public interface IDropdownService
    {
        List<SelectListItem> DefaultDDL();
        List<SelectListItem> RenderDDL(List<SelectListItem> listItems);
        List<DropDownItem> RenderDDLCustome(List<DropDownItem> listItems);
        List<DropDownItem> RenderDDLCustome(List<DropDownItem> listItems ,bool? IsIncludeDefaultItem);
        List<SelectListItem> RenderDDL(List<SelectListItem> listItems, bool? IsIncludeDefaultItem);
        List<SelectListItem> BooleanDDL(bool? IsIncludeDefaultItem = false, bool? defaultSelected = true);
        List<SelectListItem> NumberDDL(int min, int max, bool IsIncludeDefaultItem, int? defaultSelected = 0);
        List<SelectListItem> NumberDDL(int min, int max, string extraText, bool IsIncludeDefaultItem, int? defaultSelected = 0);
    }
}

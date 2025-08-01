using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Common.MapperHelper;
using RTEXERP.Contracts.BLModels.AppSecurity;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.AppSecurity;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.DBEntities.dbo;
using RTEXERP.WEB.Controllers;

namespace RTEXERP.WEB.Areas.AppSecurity.Controllers
{
    [Area("AppSecurity")]
    public class AspNetRolesController : BaseController
    {
        private readonly IAspNetRolesService aspNetRolesService;
     
        private readonly IDropdownService dropdownService;
        IAutoMapConverter<AspNetRolesViewModel, AspNetRoles> aspnetRolesVMToDB;
        IAutoMapConverter<AspNetRoles, AspNetRolesViewModel> aspnetRolesDBToVM;
        public AspNetRolesController(IAspNetRolesService aspNetRolesService,
            IDropdownService dropdownService,
            IAutoMapConverter<AspNetRolesViewModel, AspNetRoles> aspnetRolesVMToDB,
            IAutoMapConverter<AspNetRoles, AspNetRolesViewModel> aspnetRolesDBToVM)
        {
         
            this.aspNetRolesService = aspNetRolesService;
            this.aspnetRolesDBToVM = aspnetRolesDBToVM;
            this.aspnetRolesVMToDB = aspnetRolesVMToDB;
            this.dropdownService = dropdownService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            //  var model = new AspNetRolesViewModel();
            // model.CompanyList = dropdownService.RenderDDL(companyInfoService.DDLGetCompanyList());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AspNetRolesViewModel aspNetRolesVM)
        {
            RResult rResult = new RResult();
            try
            {
                if (ModelState.IsValid)
                {


                    if (aspNetRolesVM.Id > 0)
                    {
                        var entity = await aspNetRolesService.GetAspNetRolesById(aspNetRolesVM.Id);
                        entity.Name = aspNetRolesVM.Name;
                        entity.Description = aspNetRolesVM.Description;
                        // entity.NormalizedName = aspNetRolesVM.Name.ToUpper();
                        entity.CompanyId = Session_COMPANY_ID;
                        entity.IsRemoved = false;
                        rResult = await aspNetRolesService.UpdateAspNetRolesWithReturn(entity, true);
                    }
                    else
                    {
                        var entiy = aspnetRolesVMToDB.ConvertObject(aspNetRolesVM);

                        entiy.CreateBy = Session_EMPLOYEE_ID;
                        entiy.CompanyId = Session_COMPANY_ID;
                        rResult = await aspNetRolesService.AddAspNetRoles(entiy);

                    }
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = "Model is Not valid";
                }
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;

            }
            return Json(rResult);
        }

        public JsonResult AspNetRolesList()
        {
            var list = aspNetRolesService.GetAspNetRolesList();
            return Json(list);
        }

        public async Task<IActionResult>Delete(int Id)
        {
            RResult rResult = new RResult();
            try
            {
                var entity = await aspNetRolesService.GetAspNetRolesById(Id);
                entity.IsRemoved = true;
                entity.UpdateBy = Session_EMPLOYEE_ID;
                rResult =await aspNetRolesService.UpdateAspNetRolesWithReturn(entity, true);
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;

            }
            return Json (rResult);
        }

    }
}
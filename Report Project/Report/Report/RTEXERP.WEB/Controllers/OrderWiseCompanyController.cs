using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.DAL.DataContext;
using RTEXERP.WEB.ViewModel;
using StoredProcedureEFCore;

namespace RTEXERP.WEB.Controllers
{
    public class OrderWiseCompanyController : BaseController
    {

        //private DbContext dbCon;
        //public OrderWiseCompanyController(DbContext context)
        //    : base(context)
        //{
        //    dbCon = context;
        //}


        private ReportDBContext dbCon;
        public OrderWiseCompanyController(ReportDBContext context)
           
        {
            dbCon = context;
        }


        public IActionResult OrderWiseCompanyName()
        {
            return View();
        }

        public JsonResult GetOrderListAutoComplete(string OrderNo)
        {
            List<OrderWiseCompanyNameVIewModel> orderList = new List<OrderWiseCompanyNameVIewModel>();
            try
            {
                dbCon.LoadStoredProc("usp_GETOrderWiseCompanyName")
                              .AddParam("OrderNo", OrderNo)

                              .Exec(r => orderList = r.ToList<OrderWiseCompanyNameVIewModel>());


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return Json(orderList);

        }




    }
}
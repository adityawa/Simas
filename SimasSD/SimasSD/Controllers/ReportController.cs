using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimasSD.Models;
namespace SimasSD.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public JsonResult ShowReport()
        {
            string sp_name = "SPS_ListEmployee";
            SysEmployeeBussiness empobj = new SysEmployeeBussiness();
            List<SysEmployeeModel> ls = empobj.GetData<SysEmployeeModel>(sp_name).ToList();

            var JsonResult =Json(new { Data = ls }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }
    }
}
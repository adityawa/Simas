using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimasSD.Models;
using Dapper;
namespace SimasSD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            string sp_name = "SPS_ListEmployee";
            SysEmployeeBussiness empobj = new SysEmployeeBussiness();
            return View(empobj.GetData<SysEmployeeModel>(sp_name));
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            SysEmployeeModel employee = new SysEmployeeModel();
            ViewBag.BranchList = SysEmployeeBussiness.GetBranchList();
            ViewBag.TitleList = SysEmployeeBussiness.GetTitleList();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(SysEmployeeModel empModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string sp = "SPI_SysEmployee";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@EmpyBranchID", empModel.EmpyBranchID);
                    param.Add("@EmpyTitleID", empModel.EmpyTitleID);
                    param.Add("@EmpyName", empModel.EmpyName);
                    param.Add("@EmpyGender", empModel.EmpyGender);
                    param.Add("@Active", empModel.Active);
                    int inserted = new SysEmployeeBussiness().Insert<SysEmployeeModel>(sp, empModel, param);
                    if (inserted > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Transaction Failed";
                        return View(empModel);
                    }
                }
                else
                {
                    return View(empModel);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            string sSql = "select * from SysEmployee where EmpyID=@id";
            SysEmployeeModel sysemployee = new SysEmployeeBussiness().GetDataByID<SysEmployeeModel>(sSql, id.ToString());
            SysEmployeeModel employee = new SysEmployeeModel();
            ViewBag.BranchList = SysEmployeeBussiness.GetBranchList();
            ViewBag.TitleList = SysEmployeeBussiness.GetTitleList();
            return View(sysemployee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(SysEmployeeModel empModel)
        {
            try
            {
                string sp = "SPU_SysEmployee";
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpyBranchID", empModel.EmpyBranchID);
                param.Add("@EmpyTitleID", empModel.EmpyTitleID);
                param.Add("@EmpyName", empModel.EmpyName);
                param.Add("@EmpyGender", empModel.EmpyGender);
                param.Add("@Active", empModel.Active);
                param.Add("@EmpyID", empModel.EmpyID);
                int updated = new SysEmployeeBussiness().Update<SysEmployeeModel>(sp, empModel, param);
                if (updated > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Transaction Failed";
                    return View(empModel);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            string sSql = "select * from SysEmployee where EmpyID=@id";
            SysEmployeeModel sysemployee = new SysEmployeeBussiness().GetDataByID<SysEmployeeModel>(sSql, id.ToString());
            return View(sysemployee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(SysEmployeeModel emp)
        {
            try
            {
                SysEmployeeBussiness employeeBLL = new SysEmployeeBussiness();

                string sSql = "Delete from SysEmployee where EmpyID=@EmpyID";
                int deleted = employeeBLL.Delete<SysEmployeeModel>(sSql, emp);
                if (deleted > 0)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Transaction Failed";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}

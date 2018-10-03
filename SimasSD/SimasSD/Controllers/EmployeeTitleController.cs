using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimasSD.Models;
namespace SimasSD.Controllers
{
    public class EmployeeTitleController : Controller
    {
        // GET: EmployeeTitle
        public ActionResult Index()
        {
            SysEmployeeTitleBussiness empyTtlBLL = new SysEmployeeTitleBussiness();

            return View(empyTtlBLL.GetData<SysEmployeeTitleModel>("select * from SysEmployeeTitle where Active='true' order By EmpyTitleID asc"));
        }

        // GET: EmployeeTitle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeTitle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTitle/Create
        [HttpPost]
        public ActionResult Create(SysEmployeeTitleModel empyTtlMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SysEmployeeTitleBussiness empyTitBLL = new SysEmployeeTitleBussiness();

                    string sSql = "INSERT INTO SysEmployeeTitle (EmpyTitleID, EmpyTitleName, Active, UpdatedBy) values (dbo.GeneratorID('emptitle'), @EmpyTitleName, @Active,'SYSADMIN')";
                    int inserted = empyTitBLL.Insert<SysEmployeeTitleModel>(sSql, empyTtlMdl);
                    if (inserted > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Transaction Failed";
                        return View();
                    }  
                }
                else
                {
                    
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                return View();
            }
        }

        // GET: EmployeeTitle/Edit/5
        public ActionResult Edit(int id)
        {
            string sSql = "select EmpyTitlePK, EmpyTitleID, EmpyTitleName, Active from SysEmployeeTitle where EmpyTitleID=@id";
            SysEmployeeTitleModel sysempTtl = new SysEmployeeTitleBussiness().GetDataByID<SysEmployeeTitleModel>(sSql, id.ToString());
            return View(sysempTtl);
           
        }

        // POST: EmployeeTitle/Edit/5
        [HttpPost]
        public ActionResult Edit(SysEmployeeTitleModel empTtlMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SysEmployeeTitleBussiness empyTtlBLL = new SysEmployeeTitleBussiness();

                    string sSql = "UPDATE SysEmployeeTitle SET EmpyTitleName=@EmpyTitleName, Active=@Active WHERE EmpyTitleID=@EmpyTitleID";
                    int updated = empyTtlBLL.Update<SysEmployeeTitleModel>(sSql, empTtlMdl);
                    if (updated > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Transaction Failed";
                        return View();
                    }
                }
                else
                {
                    return View();
                    
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeTitle/Delete/5
        public ActionResult Delete(int id)
        {
            string sSql = "select EmpyTitlePK, EmpyTitleID, EmpyTitleName, Active from SysEmployeeTitle where EmpyTitleID=@id";
            SysEmployeeTitleModel sysempTtl = new SysEmployeeTitleBussiness().GetDataByID<SysEmployeeTitleModel>(sSql, id.ToString());
            return View(sysempTtl);
        }

        // POST: EmployeeTitle/Delete/5
        [HttpPost]
        public ActionResult Delete(SysEmployeeTitleModel empyTtl)
        {
            try
            {
                // TODO: Add delete logic here
                SysEmployeeTitleBussiness empyTtlBLL = new SysEmployeeTitleBussiness();

                string sSql = "Delete from SysEmployeeTitle where EmpyTitleID=@EmpyTitleID";
                int deleted = empyTtlBLL.Delete<SysEmployeeTitleModel>(sSql, empyTtl);
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

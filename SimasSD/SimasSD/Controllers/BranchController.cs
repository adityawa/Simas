using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimasSD.Models;
namespace SimasSD.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult Index()
        {
            SysBranchBussiness brnchBLL = new SysBranchBussiness();
            
            return View(brnchBLL.GetData<SysBranchModel>("select * from SysBranch where Active='true' order By BranchID asc"));
        }

        // GET: Branch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        [HttpPost]
        public ActionResult Create(SysBranchModel brnc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SysBranchBussiness branchBLL = new SysBranchBussiness();
                
                    string sSql = "INSERT INTO SysBranch (BranchID, BranchName, Active, UpdatedBy) values (dbo.GeneratorID('branch'), @BranchName, @Active,'SYSADMIN')";
                    int inserted = branchBLL.Insert<SysBranchModel>(sSql, brnc);
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
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                return View();
            }
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(int id)
        {
            string sSql = "select BranchPK, BranchID, BranchName, Active from SysBranch where BranchID=@id";
            SysBranchModel sysbranch = new SysBranchBussiness().GetDataByID<SysBranchModel>(sSql, id.ToString());
            return View(sysbranch);
        }

        // POST: Branch/Edit/5
        [HttpPost]
        public ActionResult Edit(SysBranchModel brnc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SysBranchBussiness branchBLL = new SysBranchBussiness();

                    string sSql = "UPDATE SysBranch SET BranchName=@BranchName, Active=@Active WHERE BranchID=@BranchID";
                    int updated = branchBLL.Update<SysBranchModel>(sSql, brnc);
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
;                }
                   
            }
            catch
            {
                return View();
            }
        }

        // GET: Branch/Delete/5
        public ActionResult Delete(int id)
        {
            string sSql = "select BranchPK, BranchID, BranchName, Active from SysBranch where BranchID=@id";
            SysBranchModel sysbranch = new SysBranchBussiness().GetDataByID<SysBranchModel>(sSql, id.ToString());
            return View(sysbranch);
        }

        // POST: Branch/Delete/5
        [HttpPost]
        public ActionResult Delete(SysBranchModel brnc)
        {
            try
            {
                // TODO: Add delete logic here
                SysBranchBussiness branchBLL = new SysBranchBussiness();

                string sSql = "Delete from SysBranch where BranchID=@BranchID";
                int deleted = branchBLL.Delete<SysBranchModel>(sSql, brnc);
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

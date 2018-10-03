using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Dapper;
using System.Web.Mvc;
namespace SimasSD.Models
{
    public class SysEmployeeModel : BaseModel
    {
       // private readonly List<SysBranchModel> _branchList;
        //private readonly List<SysEmployeeTitleModel> _titleList;
        public Guid EmpyPK { get; set; }
        [Display(Name = "Employee ID")]
        public string EmpyID { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public string EmpyBranchID { get; set; }
        //public IEnumerable<SelectListItem> BranchData
        //{
        //    get
        //    {
        //        return SysEmployeeBussiness.GetBranchList();
        //    }
        //    set { }
        //}

        [Required]
        [Display(Name = "Title")]
        public string EmpyTitleID { get; set; }
        //public IEnumerable<SelectListItem> TitleData
        //{
        //    get
        //    {
        //        return SysEmployeeBussiness.GetTitleList();
        //    }
        //    set { }
        //}

        [Required]
        [Display(Name = "Employee Name")]
        public string EmpyName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string EmpyGender { get; set; }




    }

    public class SysEmployeeBussiness : BaseBussiness
    {
        public static IEnumerable<SelectListItem> GetBranchList()
        {
            string sSql_EmpyBranch = "Select BranchID, BranchName from SysBranch where Active='true'";
            var branch = new SysBranchBussiness().GetData<SysBranchModel>(sSql_EmpyBranch);
            var selectBranchList = new List<SelectListItem>();
            foreach (var item in branch)
            {
                selectBranchList.Add(new SelectListItem
                {
                    Value = item.BranchID,
                    Text = item.BranchName
                });
            }

            return selectBranchList;
        }

        public static IEnumerable<SelectListItem> GetTitleList()
        {
            string sSql_EmpyTitle = "Select EmpyTitleID, EmpyTitleName from SysEmployeeTitle where Active='true'";
            var branch = new SysEmployeeTitleBussiness().GetData<SysEmployeeTitleModel>(sSql_EmpyTitle);
            var selectTitleList = new List<SelectListItem>();
            foreach (var item in branch)
            {
                selectTitleList.Add(new SelectListItem
                {
                    Value = item.EmpyTitleID,
                    Text = item.EmpyTitleName
                });
            }

            return selectTitleList;
        }
        public override IList<T> GetData<T>(string sSql)
        {
            List<T> ls = new List<T>();
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            using (sqlcon)
            {
                ls = sqlcon.Query<T>(sSql, commandType: CommandType.StoredProcedure).ToList();
            }
            return ls;
        }
        public override int Insert<T>(string sSql, T obj, DynamicParameters param)
        {
            //example using Dapper with Stored Procedure
            int resultAffected = 0;
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            try
            {
                using (sqlcon)
                {
                   
                    resultAffected = sqlcon.Execute(sSql, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

            return resultAffected;
        }


        public override int Update<T>(string sSql, T obj, DynamicParameters param)
        {
            //example using Dapper with Stored Procedure
            int resultAffected = 0;
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            try
            {
                using (sqlcon)
                {

                    resultAffected = sqlcon.Execute(sSql, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return resultAffected;
        }
    }
}
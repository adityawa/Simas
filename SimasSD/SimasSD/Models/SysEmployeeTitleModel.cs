using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SimasSD.Models
{
    public class SysEmployeeTitleModel : BaseModel
    {
        public Guid EmpyTitlePK { get; set; }
        [Display(Name = "Employee Title ID")]
        public string EmpyTitleID { get; set; }
        [Required]
        [Display(Name = "Employee Title Name")]
        public string EmpyTitleName { get; set; }
    }

    public class SysEmployeeTitleBussiness : BaseBussiness { }
}
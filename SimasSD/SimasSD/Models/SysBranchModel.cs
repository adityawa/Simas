using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SimasSD.Models
{
    public class SysBranchModel : BaseModel
    {
        public Guid BranchPK { get; set; }

        [Display(Name = "Branch ID")]
        public string BranchID { get; set; }
        [Required]
        [Display(Name ="Branch Name")]
       
        public string BranchName { get; set; }
    }

    public class SysBranchBussiness :BaseBussiness
    {
        
    }
}
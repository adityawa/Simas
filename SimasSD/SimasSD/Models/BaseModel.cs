using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimasSD.Models
{
    public class BaseModel
    {
        public bool Active { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
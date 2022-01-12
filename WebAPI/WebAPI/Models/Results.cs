using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Results
    {
        

        public int IndexNumber { get; set; }
        public string Result { get; set; }
        public string FullName { get; set; }
        public string NameWithInitials { get; set; }
        public string Address { get; set; }
        public DateTime ValidTill { get; set; }
        public bool CategoryA { get; set; }
        public bool CategoryB { get; set; }
        public bool CategoryC { get; set; }
        public string ValidTillDateFormat { get; set; }
        public string CategoryList { get; set; }
    }
}
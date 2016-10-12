using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaudaWebAPI4.Models
{
    public class ManageModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDisplayName { get; set; }
        public string CategoryImage { get; set; }
        public int StoreID { get; set; }
    }
}
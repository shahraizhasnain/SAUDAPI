using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sauda.SharedModels
{
    public class LoginViewModel
    {
        public int StoreID { get; set; }
        [Required]
        public string StoreUsername { get; set; }
        [Required]
        public string StorePassword { get; set; }
    }
}
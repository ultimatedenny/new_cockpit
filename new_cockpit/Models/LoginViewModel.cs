using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace new_cockpit.Models
{
    public class LoginViewModel
    {
        public string UseID { get; set; }
        public string UsePass { get; set; }
        public bool isWinAuth { get; set; }
    }
}
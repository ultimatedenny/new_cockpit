using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace new_cockpit.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AsDashboard { get; set; }
    }
}
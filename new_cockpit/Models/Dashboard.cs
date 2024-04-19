using System.Collections.Generic;

namespace new_cockpit.Models
{
    public class Dashboard
    {
        // Dashboard
        public List<Program> RightSideData { get; set; }
        public List<Program> LeftSideData { get; set; }

        // For settings page
        public List<Setting> ListDashboard { get; set; }
        public List<Setting> ListApplication { get; set; }

        public List<QMS> ListQMS { get; set; }
        public List<OMS> ListOMS { get; set; }
        public List<MMS> ListMMS { get; set; }
        public List<SCMS> ListSCMS { get; set; }

        public string SystemEnvironment { get; set; }
        public string UseID { get; set; }
        public string UsePass { get; set; }

        public List<Setting> ListDashboardSet { get; set; }
        public List<Setting> ListApplicationSet { get; set; }

        public string QMS_Menu { get; set; }
        public string OMS_Menu { get; set; }
        public string MMS_Menu { get; set; }
        public string SCMS_Menu { get; set; }

    }
}
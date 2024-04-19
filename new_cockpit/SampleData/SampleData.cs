using new_cockpit.Models;
using System.Collections.Generic;

namespace new_cockpit.SampleData
{
    public static class SampleData
    {
        public static List<Program> DisplayedListItemOnRightSide()
        {
            List<Program> listRightSide = new List<Program>();

            Program itService = new Program();
            itService.Id = 1;
            itService.Name = "IT Service";
            itService.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            itService.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program productionReport = new Program();
            productionReport.Id = 2;
            productionReport.Name = "Production Report";
            productionReport.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            productionReport.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program realtime = new Program();
            realtime.Id = 3;
            realtime.Name = "Real Time";
            realtime.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            realtime.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program wipPaint = new Program();
            wipPaint.Id = 4;
            wipPaint.Name = "WIP Paint";
            wipPaint.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            wipPaint.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program lineNC = new Program();
            lineNC.Id = 5;
            lineNC.Name = "Line NC";
            lineNC.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            lineNC.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program autoReporting = new Program();
            autoReporting.Id = 6;
            autoReporting.Name = "Auto Reporting";
            autoReporting.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            autoReporting.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program fgwh = new Program();
            fgwh.Id = 7;
            fgwh.Name = "FGWH";
            fgwh.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            fgwh.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program ss10 = new Program();
            ss10.Id = 8;
            ss10.Name = "SS 10";
            ss10.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            ss10.Url = "https://cockpitdashboard.000webhostapp.com/";

            listRightSide.Add(itService);
            listRightSide.Add(productionReport);
            listRightSide.Add(realtime);
            listRightSide.Add(wipPaint);
            listRightSide.Add(lineNC);
            listRightSide.Add(autoReporting);
            listRightSide.Add(fgwh);
            listRightSide.Add(ss10);

            return listRightSide;
        }

        public static List<Program> DisplayedListItemOnLeftSide()
        {
            List<Program> listLeftSide = new List<Program>();

            Program productionReport = new Program();
            productionReport.Id = 1;
            productionReport.Name = "Production Report";
            productionReport.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            productionReport.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program autoReporting = new Program();
            autoReporting.Id = 2;
            autoReporting.Name = "Auto Reporting";
            autoReporting.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            autoReporting.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program wipPaint = new Program();
            wipPaint.Id = 3;
            wipPaint.Name = "WIP Paint";
            wipPaint.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            wipPaint.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program itService = new Program();
            itService.Id = 4;
            itService.Name = "NEW IT Service";
            itService.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            itService.Url = "https://cockpitdashboard.000webhostapp.com/";

            listLeftSide.Add(itService);
            listLeftSide.Add(productionReport);
            listLeftSide.Add(wipPaint);
            listLeftSide.Add(autoReporting);

            Program productionReport1 = new Program();
            productionReport1.Id = 5;
            productionReport1.Name = "Production Report 1";
            productionReport1.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            productionReport1.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program autoReporting1 = new Program();
            autoReporting1.Id = 6;
            autoReporting1.Name = "Auto Reporting 1";
            autoReporting1.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            autoReporting1.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program wipPaint1 = new Program();
            wipPaint1.Id = 7;
            wipPaint1.Name = "WIP Paint 1";
            wipPaint1.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            wipPaint1.Url = "https://cockpitdashboard.000webhostapp.com/";

            Program itService1 = new Program();
            itService1.Id = 8;
            itService1.Name = "NEW IT Service 1";
            itService1.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
            itService1.Url = "https://cockpitdashboard.000webhostapp.com/";

            listLeftSide.Add(itService1);
            listLeftSide.Add(productionReport1);
            listLeftSide.Add(wipPaint1);
            listLeftSide.Add(autoReporting1);

            return listLeftSide;
        }

        public static List<Setting> ListDashboard()
        {
            List<Setting> listDisplayedDashboard = new List<Setting>();

            Setting item1 = new Setting();
            item1.Id = 1;
            item1.Name = "Line Operation System";
            item1.AsDashboard = false;

            Setting item2 = new Setting();
            item2.Id = 2;
            item2.Name = "ECS";
            item2.AsDashboard = false;

            Setting item3 = new Setting();
            item3.Id = 3;
            item3.Name = "FP Monitoring Dashboard";
            item3.AsDashboard = false;

            Setting item4 = new Setting();
            item4.Id = 4;
            item4.Name = "IQS";
            item4.AsDashboard = false;

            Setting item5 = new Setting();
            item5.Id = 5;
            item5.Name = "Production Performance";
            item5.AsDashboard = false;

            listDisplayedDashboard.Add(item1);
            listDisplayedDashboard.Add(item2);
            listDisplayedDashboard.Add(item3);
            listDisplayedDashboard.Add(item4);
            listDisplayedDashboard.Add(item5);

            return listDisplayedDashboard;
        }

        public static List<Setting> ListApplication()
        {
            List<Setting> listSetDashboard = new List<Setting>();

            Setting item1 = new Setting();
            item1.Id = 1;
            item1.Name = "Prod. Report";
            item1.AsDashboard = false;

            Setting item2 = new Setting();
            item2.Id = 2;
            item2.Name = "Auto Reporting";
            item2.AsDashboard = false;

            Setting item3 = new Setting();
            item3.Id = 3;
            item3.Name = "WIP Paint";
            item3.AsDashboard = false;

            Setting item4 = new Setting();
            item4.Id = 4;
            item4.Name = "IT Service";
            item4.AsDashboard = false;

            listSetDashboard.Add(item1);
            listSetDashboard.Add(item2);
            listSetDashboard.Add(item3);
            listSetDashboard.Add(item4);

            return listSetDashboard;
        }

        public static List<QMS> ListQMS()
        {
            List<QMS> listQMS = new List<QMS>();

            var id = 0;
            for (int i = 0; i < 16; i++)
            {
                id++;

                QMS item = new QMS();
                item.Id = id;
                item.Name = "Item " + id;
                item.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
                item.Url = "https://cockpitdashboard.000webhostapp.com/";

                listQMS.Add(item);
            }

            return listQMS;
        }

        public static List<OMS> ListOMS()
        {
            List<OMS> listOMS = new List<OMS>();

            var id = 0;
            for (int i = 0; i < 16; i++)
            {
                id++;

                OMS item = new OMS();
                item.Id = id;
                item.Name = "Item " + id;
                item.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
                item.Url = "https://cockpitdashboard.000webhostapp.com/";

                listOMS.Add(item);
            }

            return listOMS;
        }

        public static List<MMS> ListMMS()
        {
            List<MMS> listMMS = new List<MMS>();

            var id = 0;
            for (int i = 0; i < 16; i++)
            {
                id++;

                MMS item = new MMS();
                item.Id = id;
                item.Name = "Item " + id;
                item.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
                item.Url = "https://cockpitdashboard.000webhostapp.com/";

                listMMS.Add(item);
            }

            return listMMS;
        }

        public static List<SCMS> ListSCMS()
        {
            List<SCMS> listSCMS = new List<SCMS>();

            var id = 0;
            for (int i = 0; i < 16; i++)
            {
                id++;

                SCMS item = new SCMS();
                item.Id = id;
                item.Name = "Item " + id;
                item.ImageUrl = "https://cockpitdashboard.000webhostapp.com/Image1.png";
                item.Url = "https://cockpitdashboard.000webhostapp.com/";

                listSCMS.Add(item);
            }

            return listSCMS;
        }
    }
}
using new_cockpit.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Configuration;
using System;
using System.Web.Security;

namespace new_cockpit.Controllers
{
    public class MainController : Controller
    {

        Dashboard dashboard = new Dashboard();
         Action.LoginAction _adfmAction = new Action.LoginAction();

        Class.SysUtl.WindowsAuth winAut = new Class.SysUtl.WindowsAuth();
        // GET: Main
        public ActionResult Indexold()
        {
            if(Session["UserName"] == null)
            {
                Session["UserId"] = "GUEST";
                Session["UserName"] = "GUEST";
            }
            if(string.IsNullOrEmpty(Session["UserName"].ToString()))
            {
                Session["UserId"] = "GUEST";
                Session["UserName"] = "GUEST";
            }

            LoadData();
            return View(dashboard);
        }

        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                Session["UserId"] = "GUEST";
                Session["UserName"] = "GUEST";
            }
            if (string.IsNullOrEmpty(Session["UserName"].ToString()))
            {
                Session["UserId"] = "GUEST";
                Session["UserName"] = "GUEST";
            }

            LoadData();
            return View(dashboard);
        }


        public void LoadData()
        {
            //var rightSideData = SampleData.SampleData.DisplayedListItemOnRightSide();
            //var leftSideData = SampleData.SampleData.DisplayedListItemOnLeftSide();

            
            //var listDashboard = SampleData.SampleData.ListDashboard();
            //var listApplication = SampleData.SampleData.ListApplication();

            List<Setting> listDisplayedDashboard = new List<Setting>();
            List<Setting> listDisplayedApplication = new List<Setting>();
            List<Program> rightSideData = new List<Program>();
            List<Program> leftSideData = new List<Program>();

            List<Setting> listDisplayedDashboardSet = new List<Setting>();
            List<Setting> listDisplayedApplicationSet = new List<Setting>();

            Setting item1 = new Setting();
            item1.Id = 1;
            item1.Name = "Prod. Report";
            item1.AsDashboard = false;

            string sql = @"
                declare @UserID varchar(100)='" + Session["UserId"].ToString() + @"'
                select a.*,isnull(b.UserId,'') as UserId from ApplicationList a
                left join ApplicationFavorit b on a.AppKey=b.AppKey and UserId=@UserID

                select b.* from ApplicationFavorit a
                left join ApplicationList b on a.AppKey = b.AppKey
                where UPPER(a.UserId) = UPPER(@UserID)";
            DataSet dsLs = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConStr"].ToString(), CommandType.Text, sql);

            foreach (DataRow drDash in dsLs.Tables[0].Select("AppType='DASHBOARD' and UserId=''")) //.Select("AppCategory='OMS'"))
            {
                Setting SItem = new Setting();
                SItem.Id = Convert.ToInt32(drDash["AppKey"].ToString());
                SItem.Name = drDash["AppName"].ToString();
                SItem.AsDashboard = false;
                listDisplayedDashboard.Add(SItem);
            }

            foreach (DataRow drDashSet in dsLs.Tables[0].Select("AppType='DASHBOARD' and UserId<>''")) //.Select("AppCategory='OMS'"))
            {
                Setting SItem = new Setting();
                SItem.Id = Convert.ToInt32(drDashSet["AppKey"].ToString());
                SItem.Name = drDashSet["AppName"].ToString();
                SItem.AsDashboard = false;
                listDisplayedDashboardSet.Add(SItem);
            }

            foreach (DataRow drApp in dsLs.Tables[0].Select("AppType='APPLICATION' and UserId=''")) //.Select("AppCategory='OMS'"))
            {
                Setting SItem = new Setting();
                SItem.Id = Convert.ToInt32(drApp["AppKey"].ToString());
                SItem.Name = drApp["AppName"].ToString();
                SItem.AsDashboard = false;
                listDisplayedApplication.Add(SItem);
            }

            foreach (DataRow drAppSet in dsLs.Tables[0].Select("AppType='APPLICATION' and UserId<>''")) //.Select("AppCategory='OMS'"))
            {
                Setting SItem = new Setting();
                SItem.Id = Convert.ToInt32(drAppSet["AppKey"].ToString());
                SItem.Name = drAppSet["AppName"].ToString();
                SItem.AsDashboard = false;
                listDisplayedApplicationSet.Add(SItem);
            }


            foreach (DataRow drRight in dsLs.Tables[1].Select("AppType='DASHBOARD'")) //.Select("AppCategory='OMS'"))
            {
                Program itServiceR = new Program();
                itServiceR.Id = Convert.ToInt32(drRight["AppKey"].ToString());
                itServiceR.Name = drRight["AppName"].ToString();
                itServiceR.ImageUrl = "/Images/Icon/" + drRight["AppIcon"].ToString(); ;
                itServiceR.Url = drRight["AppPath"].ToString();

                rightSideData.Add(itServiceR);
            }

            foreach (DataRow drLeft in dsLs.Tables[1].Select("AppType='APPLICATION'")) //.Select("AppCategory='OMS'"))
            {
                Program itServiceL = new Program();
                itServiceL.Id = Convert.ToInt32(drLeft["AppKey"].ToString());
                itServiceL.Name = drLeft["AppName"].ToString();
                itServiceL.ImageUrl = "/Images/Icon/new/" + drLeft["AppIcon"].ToString(); ;
                itServiceL.Url = drLeft["AppPath"].ToString();
                if (drLeft["AppClass"].ToString() == "WEB")
                    itServiceL.Target = "_Blank";
                else
                    itServiceL.Target = "_Self";

                leftSideData.Add(itServiceL);
            }




            dashboard.ListDashboard = listDisplayedDashboard;
            dashboard.ListApplication = listDisplayedApplication;

            dashboard.ListDashboardSet = listDisplayedDashboardSet;
            dashboard.ListApplicationSet = listDisplayedApplicationSet;

            dashboard.RightSideData = rightSideData;
            dashboard.LeftSideData = leftSideData;
            //dashboard.SystemEnvironment = Properties.Settings.Default.SystemEnvironment;
            dashboard.SystemEnvironment = System.Configuration.ConfigurationManager.AppSettings["SystemServer"];

            // Pilars


            List<OMS> lsOMS = new List<OMS>();
            List<QMS> lsQMS = new List<QMS>();
            List<MMS> lsMMS = new List<MMS>();
            List<SCMS> lsSCMS = new List<SCMS>();

            sql = "select * from ApplicationList where AppType='APPLICATION' order by AppSeq";
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConStr"].ToString(), CommandType.Text, sql);

            int SeqQ = 0,SeqO=0,SeqM=0,SeqS=0;
            dashboard.QMS_Menu = "<div class='row'>";
            dashboard.OMS_Menu = "<div class='row'>";
            dashboard.MMS_Menu = "<div class='row'>";
            dashboard.SCMS_Menu = "<div class='row'>";

            foreach (DataRow dr in ds.Tables[0].Rows) //.Select("AppCategory='OMS'"))
            {
                switch (dr["AppCategory"].ToString())
                {
                    case "OMS":
                        OMS OMSitem = new OMS();
                        OMSitem.Id = Convert.ToInt32(dr["AppKey"].ToString());
                        OMSitem.Name = dr["AppName"].ToString();
                        OMSitem.ImageUrl = "/Images/Icon/new/" + dr["AppIcon"].ToString(); //"https://cockpitdashboard.000webhostapp.com/Image1.png";
                        if (dr["AppClass"].ToString() == "WEB")
                            OMSitem.Target = "_Blank";
                        else
                            OMSitem.Target = "_Self";
                        OMSitem.Url = dr["AppPath"].ToString();
                        lsOMS.Add(OMSitem);

                        if (SeqO % 4 == 0 && SeqO > 1)
                            dashboard.OMS_Menu += @"</div><div class='row'>";

                        dashboard.OMS_Menu += @" <div class='col-lg-3 col-md-3 margin-b-30'>
                                                            <a href = " + OMSitem.Url + " target = " + OMSitem.Target + @" class='no-underline'>
                                                    <div>
                                                        <img src = " + OMSitem.ImageUrl + @" style='width:auto; height:auto; object-fit: scale-down;' class='img-responsive position-c c-pilar__img-shadow' />
                                                    </div>
                                                    <div class='c-side-list__item-name'>
                                                        " + OMSitem.Name + @"
                                                    </div>
                                                </a>
                                            </div>";

                        SeqO++;

                        break;

                    case "QMS":
                        QMS QMSitem = new QMS();
                        QMSitem.Id = Convert.ToInt32(dr["AppKey"].ToString());
                        QMSitem.Name = dr["AppName"].ToString();
                        QMSitem.ImageUrl = "/Images/Icon/new/" + dr["AppIcon"].ToString();
                        if (dr["AppClass"].ToString() == "WEB")
                            QMSitem.Target = "_Blank";
                        else
                            QMSitem.Target = "_Self";
                        QMSitem.Url = dr["AppPath"].ToString();
                        lsQMS.Add(QMSitem);

                        if (SeqQ % 4 == 0 && SeqQ > 1)
                            dashboard.QMS_Menu += @"</div><div class='row'>";

                        dashboard.QMS_Menu += @" <div class='col-lg-3 col-md-3 margin-b-30'>
                                                            <a href = " + QMSitem.Url + " target = " + QMSitem.Target + @" class='no-underline'>
                                                    <div>
                                                        <img src = " + QMSitem.ImageUrl + @" style='width:auto; height:auto; object-fit: scale-down;' class='img-responsive position-c c-pilar__img-shadow' />
                                                    </div>
                                                    <div class='c-side-list__item-name'>
                                                        " + QMSitem.Name + @"
                                                    </div>
                                                </a>
                                            </div>";

                        SeqQ++;

                        break;

                    case "MMS":
                        MMS MMSitem = new MMS();
                        MMSitem.Id = Convert.ToInt32(dr["AppKey"].ToString());
                        MMSitem.Name = dr["AppName"].ToString();
                        MMSitem.ImageUrl = "/Images/Icon/new/" + dr["AppIcon"].ToString();
                        if (dr["AppClass"].ToString() == "WEB")
                            MMSitem.Target = "_Blank";
                        else
                            MMSitem.Target = "_Self";
                        MMSitem.Url = dr["AppPath"].ToString();
                        lsMMS.Add(MMSitem);

                        if (SeqM % 4 == 0 && SeqM > 1)
                            dashboard.MMS_Menu += @"</div><div class='row'>";

                        dashboard.MMS_Menu += @" <div class='col-lg-3 col-md-3 margin-b-30'>
                                                            <a href = " + MMSitem.Url + " target = " + MMSitem.Target + @" class='no-underline'>
                                                    <div>
                                                        <img src = " + MMSitem.ImageUrl + @" style='width:auto; height:auto; object-fit: scale-down;' class='img-responsive position-c c-pilar__img-shadow' />
                                                    </div>
                                                    <div class='c-side-list__item-name'>
                                                        " + MMSitem.Name + @"
                                                    </div>
                                                </a>
                                            </div>";

                        SeqM++;

                        break;

                    case "SCMS":
                        SCMS SCMSitem = new SCMS();
                        SCMSitem.Id = Convert.ToInt32(dr["AppKey"].ToString());
                        SCMSitem.Name = dr["AppName"].ToString();
                        SCMSitem.ImageUrl = "/Images/Icon/new/" + dr["AppIcon"].ToString();
                        if (dr["AppClass"].ToString() == "WEB")
                            SCMSitem.Target = "_Blank";
                        else
                            SCMSitem.Target = "_Self";
                        SCMSitem.Url = dr["AppPath"].ToString();
                        lsSCMS.Add(SCMSitem);

                        if (SeqS % 4 == 0 && SeqS > 1)
                            dashboard.SCMS_Menu += @"</div><div class='row'>";

                        dashboard.SCMS_Menu += @" <div class='col-lg-3 col-md-3 margin-b-30'>
                                                            <a href = " + SCMSitem.Url + " target = " + SCMSitem.Target + @" class='no-underline'>
                                                    <div>
                                                        <img src = " + SCMSitem.ImageUrl + @" style='width:auto; height:auto; object-fit: scale-down;' class='img-responsive position-c c-pilar__img-shadow' />
                                                    </div>
                                                    <div class='c-side-list__item-name'>
                                                        " + SCMSitem.Name + @"
                                                    </div>
                                                </a>
                                            </div>";

                        SeqS++;

                        break;
                }

            }

            dashboard.QMS_Menu += "</div>";

            var listOMS = lsOMS;//SampleData.SampleData.ListOMS();
            var listQMS = lsQMS; //SampleData.SampleData.ListQMS();
            var listMMS = lsMMS;// SampleData.SampleData.ListMMS();
            var listSCMS = lsSCMS;// SampleData.SampleData.ListSCMS();
            dashboard.ListOMS = listOMS;
            dashboard.ListQMS = listQMS;
            dashboard.ListMMS = listMMS;
            dashboard.ListSCMS = listSCMS;
           
        }


        //[HttpPost]
        //public ActionResult Index(Dashboard model)
        //{
        //    bool loginRtn = winAut.WinAuth(model.UseID, model.UsePass);
        //    if (loginRtn)
        //    {
        //        TempData["MSG"] = "Success Access!- Login - " + DateTime.Now.ToString() + "";
        //        return RedirectToAction("Index", "Main");
        //    }
        //    else
        //    {
        //        TempData["MSG"] = "Unauthorized Access!- Login - " + DateTime.Now.ToString() + "";
        //        LoadData();
        //        return View(dashboard);
        //    }

        //}

        public JsonResult LoginUser(string UserId, string Password)
        {
            bool rtn = winAut.WinAuth(UserId, Password);
            if (rtn)
            {
                string[] txtArray = winAut.fullDisplyName.Split(' ');
                string firstName = txtArray[0];
                Session.Add("UserId", UserId);
                Session["UserName"]= firstName;
                return Json(new { isSuccess = true, message = "login successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { isSuccess = false, message = "User or password is not match." }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveData(string StrData)
        {
            if(Session["UserName"] == null)
            {
                return Json(new { isSuccess = false, message = "your session has been timeout, please re-login first." }, JsonRequestBehavior.AllowGet);
            }

            if (Session["UserName"].ToString() == "GUEST")
            {
                return Json(new { isSuccess = false, message = "unable to change GUEST layout" }, JsonRequestBehavior.AllowGet);
            }

            if (Session["UserId"] == null)
            {
                return Json(new { isSuccess = false, message = "unable to change GUEST layout" }, JsonRequestBehavior.AllowGet);
            }

            string SQL = @"declare @Data varchar(max)='" + StrData + @"'
		                        ,@UserID varchar(100)='" + Session["UserId"].ToString() + @"'

                        delete from ApplicationFavorit where UserId=@UserID

                        insert into ApplicationFavorit (UserId,AppKey,CreBy,CreDat)
                        select @UserID,Val,@UserID,getdate() from ufn_String_To_Table(@Data,',',0) where isnull(Val,'')<>''";
            Int32 rtn = SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConStr"].ToString(), CommandType.Text, SQL);
            if(rtn>=0)
            {
                return Json(new { isSuccess = true, message = "Layout data has been saved." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isSuccess = false, message = "Error found!" }, JsonRequestBehavior.AllowGet);
            }
            
        }



        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Main/Create
       [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //bejo tambahkan action logout() disini
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("index", "main");
        }
    }
}

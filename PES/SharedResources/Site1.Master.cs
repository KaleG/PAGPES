using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PES.SharedResources
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!IsPostBack && Session["SelectedLanguage"] == null)
                //{
                //    Session["SelectedLanguage"] = "AM";
                //}
                /// Response.Write(Session["SelectedLanguage"].ToString());
                if (Convert.ToInt32(Session["UserRole"]) == 4)
                {
                    DivMidTermColleagueEvaluation.Visible = false;
                    DivReport.Visible = false;
                    DivSetting.Visible = false;
                    DivEmployeeEvaluation.Visible = false;
                    //DivmyEmployeesFeedBAck.Visible = false;
                    DivAnnualEvaluationREport.Visible = false;
                }
                if (Convert.ToInt32(Session["UserRole"]) == 3)
                {
                    //DivReport.Visible = false;
                    DivSetting.Visible = false;
                }

                currentPageName.InnerText = Session["PageTitle"].ToString();
                if (!IsPostBack)
                {
                    theLoginUserName.Text = theLoginUserName.Text + " Hello" + " " + Session["LogInUserName"].ToString();
                }

                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);

                DataAccess.EvaluationDisclosure des = (from de in db.EvaluationDisclosures
                                                       where de.EvaluatedEmployeId == loggerId &&
                                                        de.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                                       select de).SingleOrDefault();
                if (des != null && des.IDontMind == false)
                {
                    NavEvaluationByLineMgr.Visible = false;
                }
            }
            catch (Exception exxx) {
                string ohh = exxx.Message;
            }
        }
        
        protected void btnLogOut_Click(object sender, EventArgs e)
        {                 
            Session.Remove("EvaluationPeriod");
            Session["UserLoggedInID1"] = null;
            Session.Remove("UserLoggedInID1");
            Session.Remove("LogedInUserCompanyId");
            Session.Remove("SelectedLanguage");
            Session.Remove("LogInUserName");
            Session.Remove("UserRole");
            Response.Redirect("~/Presentation/Home.aspx");
        }

        protected void BtnChangeLanguage_Click(object sender, EventArgs e)
        {
            if (Session["SelectedLanguage"].ToString() == "AM")
            {
                 Session.Remove("SelectedLanguage");
                //string k1 = Session["SelectedLanguage"].ToString();
                //Session.Clear();
                Session["SelectedLanguage"] = "EN";
                string k2 = Session["SelectedLanguage"].ToString();
            }
            else if (Session["SelectedLanguage"].ToString() == "EN")
            {
                //string k1 = Session["SelectedLanguage"].ToString();
                Session.Remove("SelectedLanguage");
                //Session.Clear();
                Session["SelectedLanguage"] = "AM";
                string k2 = Session["SelectedLanguage"].ToString();               
            }            
        }

        
        protected void BtnSelectPeriod_Click(object sender, EventArgs e)
        {
            Session["EvaluationPeriod"] = DDLEvaluatedEmployee.SelectedValue;
            //Response.Redirect(Request.Url.ToString());
            DDLEvaluatedEmployee.SelectedIndex = DDLEvaluatedEmployee.Items.IndexOf(DDLEvaluatedEmployee.Items.FindByValue(DDLEvaluatedEmployee.SelectedValue));
            // this.Page_Load(this, EventArgs.Empty);

        }

        protected void theLoginUserName_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}
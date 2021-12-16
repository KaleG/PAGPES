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
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack && Session["SelectedLanguage"] == null)
            //{
            //    Session["SelectedLanguage"] = "AM";
            //}
            /// Response.Write(Session["SelectedLanguage"].ToString());
            if (Convert.ToInt32(Session["UserRole"]) == 4) 
            {
                DivMidTermColleagueEvaluation.Visible = false;
            } 
            if (Convert.ToInt32(Session["UserRole"]) == 3 || Convert.ToInt32(Session["UserRole"]) == 4) 
            {
                DivReport.Visible = false;
            } 
        }
        
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("UserLoggedInID1");
            Response.Redirect("Login.aspx");
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
    }
}
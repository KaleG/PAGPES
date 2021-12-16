using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class UserProfile : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
            if (!IsPostBack)
            {
                TbxUserName.Text = Session["LogInUserName"].ToString();
            }
        }

        protected void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            DataAccess.UsersLogIn validUser = (from em in db.UsersLogIns where em.Id == Convert.ToInt32(Session["UserLoggedInID1"]) select em).SingleOrDefault();
            if (validUser.Pwd == TbxOldPassword.Text.ToString()) 
            {
                validUser.UserName = TbxUserName.Text.ToString();
                validUser.Pwd = TbxNewPass.Text.ToString();

                db.SubmitChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PES.Presentation
{
    public partial class UserManagement : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["PageTitle"] = this.Title.ToString();
            //GridView1.Columns[0]. = false;
        }

        protected void BtnREgister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["SelectedRowId"] == null)
                {
                    DataAccess.Employee employe = (from y in db.Employees where y.CompanyId == TbxCompanyID.Text.ToString() select y).SingleOrDefault();
                    DataAccess.UsersLogIn userlogin = (from x in db.UsersLogIns where x.CompanyId == TbxCompanyID.Text.ToString() select x).SingleOrDefault();

                    if (employe == null && userlogin == null)
                    {
                        DataAccess.Employee newEmpl = new DataAccess.Employee();
                        newEmpl.EName = TbxFirstNameEN.Text.ToString();
                        newEmpl.ENameAM = TbxFirstNameAM.Text.ToString();
                        newEmpl.ELName = TbxLastNameEN.Text.ToString();
                        newEmpl.ELNameAM = TbxLastNameAM.Text.ToString();
                        newEmpl.CompanyId = TbxCompanyID.Text.ToString();

                        db.Employees.InsertOnSubmit(newEmpl);

                        DataAccess.UsersLogIn newuse = new DataAccess.UsersLogIn();

                        newuse.CompanyId = TbxCompanyID.Text.ToString();
                        newuse.UserName = TbxFirstNameEN.Text.ToString() + TbxLastNameEN.Text.ToString();
                        newuse.Pwd = "12345";
                        newuse.IsActive = "1";
                        newuse.UserRole = Convert.ToInt32(DDLUSerRole.SelectedValue);

                        db.UsersLogIns.InsertOnSubmit(newuse);

                        DataAccess.Employee_LineManager elm = (from elmm in db.Employee_LineManagers
                                                               where elmm.employeeID == Convert.ToInt32(Session["SelectedRowId"])
                         && elmm.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                               select elmm).SingleOrDefault();
                        if (elm != null)
                        {
                            elm.employeeID = Convert.ToInt32(Session["SelectedRowId"]);
                            elm.LineManager = Convert.ToInt32(DDLLineMgr.SelectedValue);
                            elm.period = Convert.ToInt32(Session["EvaluationPeriod"]);
                        }
                        else
                        {
                            DataAccess.Employee_LineManager newPair = new DataAccess.Employee_LineManager();
                            newPair.employeeID = Convert.ToInt32(Session["SelectedRowId"]);
                            newPair.LineManager = Convert.ToInt32(DDLLineMgr.SelectedValue);
                            newPair.period = Convert.ToInt32(Session["EvaluationPeriod"]);

                            db.Employee_LineManagers.InsertOnSubmit(newPair);
                        }
                        db.SubmitChanges();
                    }
                }
                else
                {
                    var employe = (from y in db.Employees where y.CompanyId == TbxCompanyID.Text.ToString() select y).ToList();
                    var userlogin = (from x in db.UsersLogIns where x.CompanyId == TbxCompanyID.Text.ToString() select x).ToList();

                    if (employe.Count == 1 && userlogin.Count == 1)
                    {
                        DataAccess.Employee updateEmp = (from empm in db.Employees where empm.Id == Convert.ToInt32(Session["SelectedRowId"]) select empm).SingleOrDefault();

                        updateEmp.EName = TbxFirstNameEN.Text.ToString();
                        updateEmp.ENameAM = TbxFirstNameAM.Text.ToString();
                        updateEmp.ELName = TbxLastNameEN.Text.ToString();
                        updateEmp.ELNameAM = TbxLastNameAM.Text.ToString();
                        updateEmp.CompanyId = TbxCompanyID.Text.ToString();

                        DataAccess.UsersLogIn upuser = (from uu in db.UsersLogIns where uu.CompanyId == Session["CompanyIDState"].ToString() select uu).SingleOrDefault();
                        upuser.CompanyId = TbxCompanyID.Text.ToString();
                        upuser.UserRole = Convert.ToInt32(DDLUSerRole.SelectedValue);

                        DataAccess.Employee_LineManager elm = (from elmm in db.Employee_LineManagers
                                                               where elmm.employeeID == Convert.ToInt32(Session["SelectedRowId"])
                         && elmm.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                               select elmm).SingleOrDefault();
                        if (elm != null)
                        {
                            elm.employeeID = Convert.ToInt32(Session["SelectedRowId"]);
                            elm.LineManager = Convert.ToInt32(DDLLineMgr.SelectedValue);
                            elm.period = Convert.ToInt32(Session["EvaluationPeriod"]);
                        }
                        else
                        {
                            DataAccess.Employee_LineManager newPair = new DataAccess.Employee_LineManager();
                            newPair.employeeID = Convert.ToInt32(Session["SelectedRowId"]);
                            newPair.LineManager = Convert.ToInt32(DDLLineMgr.SelectedValue);
                            newPair.period = Convert.ToInt32(Session["EvaluationPeriod"]);
                            db.Employee_LineManagers.InsertOnSubmit(newPair);
                        }
                        db.SubmitChanges();
                    }
                    GridView1.DataBind();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbxFirstNameEN.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            TbxFirstNameAM.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            TbxLastNameEN.Text = GridView1.SelectedRow.Cells[2].Text.ToString();
            TbxLastNameAM.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
            TbxCompanyID.Text = GridView1.SelectedRow.Cells[5].Text.ToString();

            
            Session["SelectedRowId"] = GridView1.SelectedRow.Cells[0].Text.ToString();
            Session["CompanyIDState"] = GridView1.SelectedRow.Cells[5].Text.ToString();

            DataAccess.UsersLogIn ulin = (from uu in db.UsersLogIns where uu.CompanyId == GridView1.SelectedRow.Cells[5].Text.ToString() select uu).SingleOrDefault();
            int selectedUserRole = Convert.ToInt32(ulin.UserRole);
            string selectedUserRoleNAme = ((from ur in db.LKUsersRoles where ur.Id == selectedUserRole select ur).SingleOrDefault().RoleName).ToString();
            DDLUSerRole.SelectedIndex = DDLUSerRole.Items.IndexOf(DDLUSerRole.Items.FindByText(selectedUserRoleNAme));
            
            DataAccess.Employee_LineManager armgr = (from emp_armg in db.Employee_LineManagers where emp_armg.employeeID == Convert.ToInt32(Session["SelectedRowId"]) select emp_armg).SingleOrDefault();
            if (armgr != null)
            {
                int armgrId = Convert.ToInt32(armgr.LineManager);
                DataAccess.Employee LineName = (from lnae in db.Employees where lnae.Id == armgrId select lnae).SingleOrDefault();
                string LineNames = LineName.EName + " " + LineName.ELName + " " + LineName.CompanyId;
                DDLLineMgr.SelectedIndex = DDLLineMgr.Items.IndexOf(DDLLineMgr.Items.FindByText(LineNames));
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            DataAccess.Employee DeletEmp = (from empm in db.Employees where empm.Id == Convert.ToInt32(Session["SelectedRowId"]) select empm).SingleOrDefault();
            DataAccess.UsersLogIn Deluser = (from uu in db.UsersLogIns where uu.CompanyId == Session["CompanyIDState"].ToString() select uu).SingleOrDefault();
            DataAccess.Employee_LineManager delelm = (from elmm in db.Employee_LineManagers
                                                   where elmm.employeeID == Convert.ToInt32(Session["SelectedRowId"])
             && elmm.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                   select elmm).SingleOrDefault();

            db.Employees.DeleteOnSubmit(DeletEmp);
            db.UsersLogIns.DeleteOnSubmit(Deluser);
            db.Employee_LineManagers.DeleteOnSubmit(delelm);

            db.SubmitChanges();

            GridView1.DataBind();
        }


        protected void Search(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["PerformaceEvaluationConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.CommandText = "SELECT ContactName, City, Country FROM Customers WHERE ContactName LIKE '%' + @ContactName + '%'";

                    //SqlDataSource1_EmployeList.ConnectionString = "ConnectionStrings:PerformaceEvaluationConnectionString1";
                    //SqlDataSource1_EmployeList.SelectCommand = "SELECT [Id], [EName], [ELName], [CompanyId], [ENameAM], [ELNameAM] FROM [Employees] " +
                    //  "where EName LIKE '%' + @ContactName + '%' or ELName LIKE '%' + @ContactName + '%' ";
                    cmd.CommandText = "SELECT [Id], [EName], [ELName], [CompanyId], [ENameAM], [ELNameAM] FROM [Employees] " +
                                           "where EName LIKE '%' + @ContactName + '%' or ELName LIKE '%' + @ContactName + '%' ";


                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ContactName", txtSearch.Text.Trim());
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        GridView1.DataSourceID = null;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void BtnResetUserNameAndPassword_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Employee empSelected = (from empm in db.Employees where empm.Id == Convert.ToInt32(Session["SelectedRowId"]) select empm).SingleOrDefault();
                DataAccess.UsersLogIn userlogin = (from x in db.UsersLogIns where x.CompanyId == empSelected.CompanyId select x).SingleOrDefault();
                userlogin.UserName = empSelected.EName + empSelected.ELName;
                userlogin.Pwd = "12345";
                db.SubmitChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
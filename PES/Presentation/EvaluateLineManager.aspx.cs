using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PES.Presentation
{
    public partial class EvaluateLineManager : System.Web.UI.Page
    {
        DataAccess.PerformanceEvaluationDBDataContext db = new DataAccess.PerformanceEvaluationDBDataContext();        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserLoggedInID1"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                Session["PageTitle"] = this.Title.ToString();

                
                
                int MyLineManagerId = Convert.ToInt32((from x in db.Employee_LineManagers
                                                       where x.employeeID == Convert.ToInt32(Session["loggerId"]) &&
                   x.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                       select x).SingleOrDefault().LineManager);
                if (!IsPostBack)
                {
                    LblMyLineManagerNAme.InnerText = LblMyLineManagerNAme.InnerText +" "+ (from L in db.Employees where L.Id == MyLineManagerId select L).SingleOrDefault().EName.ToString()+" "+ (from L in db.Employees where L.Id == MyLineManagerId select L).SingleOrDefault().ELName.ToString();
                }
                if (!IsPostBack)
                {
                    var checkExist = (from x in db.EmployeesToLineMGREvaluationForms
                                      where x.LineManagerId == MyLineManagerId &&
                                                                         x.EmployeeId == Convert.ToInt32(Session["loggerId"]) &&
                                          x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                      select x).SingleOrDefault();
                    if (checkExist != null)
                    {
                        TbxDirectOperational.Text = checkExist.DirectJobRElated.ToString();
                        TbxAdministrative.Text = checkExist.AdministrativeRElative.ToString();
                        TbxStaffDevelopemtn.Text = checkExist.StaffDevelopement.ToString();
                        TbxGeneral2.Text = checkExist.Generaln.ToString();
                    }
                }

                var EpointsAM = (from ev in db.LKEmployeesToLineMGREvaluations where ev.DataTypes == 3 select ev).ToList();
                int loggerId = Convert.ToInt32((from Em in db.Employees where Em.CompanyId == Session["LogedInUserCompanyId"].ToString() select Em).SingleOrDefault().Id);
                Session["LoggedINEMployee"] = loggerId;

                int rows = EpointsAM.Count;
                int cols = 9;

                int rowcounter = 1;

                foreach (var eAM in EpointsAM)
                {
                    TableRow tr = new TableRow();

                    for (int i = 0; i < cols; i++)
                    {
                        TableCell c = new TableCell();
                        if (i == 0)
                        {
                            c.Controls.Add(new Label() { ID = "K" + rowcounter.ToString(), Text = rowcounter.ToString() });
                            tr.Cells.Add(c);
                        }
                        if (i == 1)
                        {
                            if (Session["SelectedLanguage"].ToString() == "AM")
                            {
                                c.Controls.Add(new Label() { ID = (eAM.Id.ToString() + eAM.DataTypes.ToString()), Text = eAM.EvaluationNameAmharic.ToString() });
                                tr.Cells.Add(c);
                            }
                            else
                            {
                                c.Controls.Add(new Label() { ID = (eAM.Id.ToString() + eAM.DataTypes.ToString()), Text = eAM.EvaluationName.ToString() });
                                tr.Cells.Add(c);
                            }
                        }
                        if (i != 0 && i != 1 && i != 8)
                        {
                            var evaluated = (from evd in db.EmployeesToLineMGREvaluations
                                             where evd.EvaluationPointName == eAM.Id
                                             && evd.LineManagerId == MyLineManagerId && 
                                             evd.EmployeeId == loggerId &&
             evd.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                             select evd).SingleOrDefault();
                            if (evaluated != null && Convert.ToInt32(evaluated.EvaluationPointGiven) == i)
                            {
                                if (Session["SelectedLanguage"].ToString() == "AM")
                                {
                                    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), Checked = true, GroupName = eAM.EvaluationNameAmharic.ToString() });
                                    tr.Cells.Add(c);
                                }
                                else
                                {
                                    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), Checked = true, GroupName = eAM.EvaluationName.ToString() });
                                    tr.Cells.Add(c);
                                }
                            }
                            else
                            {
                                if (Session["SelectedLanguage"].ToString() == "AM")
                                {
                                    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), GroupName = eAM.EvaluationNameAmharic.ToString() });
                                    tr.Cells.Add(c);
                                }
                                else
                                {
                                    c.Controls.Add(new RadioButton() { ID = (rowcounter + "AM" + i).ToString(), GroupName = eAM.EvaluationName.ToString() });
                                    tr.Cells.Add(c);
                                }
                            }
                        }
                        if (i == 8)
                        {
                            c.Controls.Add(new Label() { ID = ("AM" + rowcounter).ToString(), Text = eAM.Id.ToString() });
                            tr.Cells.Add(c);
                            tr.Cells[8].Visible = false;
                        }
                    }
                    Table1.Rows.Add(tr);
                    rowcounter++;
                }



            }
            catch (Exception ex)
            {
                string eee = ex.Message;
            }
        }

        protected void BtnClearTable_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                string selectedLanguage = Session["SelectedLanguage"].ToString();
                string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
                int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;
                int MyLineManagerId = Convert.ToInt32((from x in db.Employee_LineManagers
                                                       where x.employeeID == Convert.ToInt32(Session["loggerId"]) &&
                   x.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                       select x).SingleOrDefault().LineManager);

                List<DataAccess.EmployeesToLineMGREvaluation> ToBeDeleted = (from cex in db.EmployeesToLineMGREvaluations
                                                                             where cex.EmployeeId == evaluatorId &&
                                                                             cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                                             cex.LineManagerId == MyLineManagerId
                                                                             select cex).ToList();

                db.EmployeesToLineMGREvaluations.DeleteAllOnSubmit(ToBeDeleted);
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            } catch (Exception ex){
                Console.Write(ex.Message);
            }
        }

        protected void BtnSaveTable_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                string selectedLanguage = Session["SelectedLanguage"].ToString();
                string loggedINCompanyId = Session["LogedInUserCompanyId"].ToString();
                int evaluatorId = (from Em in db.Employees where Em.CompanyId == loggedINCompanyId select Em).SingleOrDefault().Id;
                int MyLineManagerId = Convert.ToInt32((from x in db.Employee_LineManagers
                                                       where x.employeeID == Convert.ToInt32(Session["loggerId"]) &&
                   x.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                       select x).SingleOrDefault().LineManager);

                int co = Table1.Rows.Count;
                for (int k = 1; k < co; k++)
                {
                    DataAccess.EmployeesToLineMGREvaluation ep = new DataAccess.EmployeesToLineMGREvaluation();
                    ep.EmployeeId = evaluatorId;
                    ep.LineManagerId = MyLineManagerId;
                    ep.EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]);
                    ep.EvaluationDate = DateTime.Now.Date;
                    Label lblQid = (Label)Table1.Rows[k].Cells[8].FindControl("AM" + k.ToString());
                    ep.EvaluationPointName = Convert.ToInt32(lblQid.Text);
                    ep.isSubmitted = true;

                    DataAccess.EmployeesToLineMGREvaluation checkExistance = (from cex in db.EmployeesToLineMGREvaluations
                                                                             where cex.EmployeeId == evaluatorId &&
                                                                             cex.LineManagerId == MyLineManagerId &&
                                                                             cex.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"]) &&
                                                                             cex.EvaluationPointName == Convert.ToInt32(lblQid.Text)
                                                                             select cex).FirstOrDefault();
                    if (checkExistance != null)
                    {
                        for (int i = 2; i < 8; i++)
                        {
                            TableCell tc = Table1.Rows[k].Cells[i];
                            Label theId = (Label)Table1.Rows[k].Cells[0].FindControl("K" + k.ToString());
                            RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + "AM" + i);
                            bool ischecked = rb.Checked;
                            if (ischecked)
                            {
                                char t = rb.ID.Last();
                                checkExistance.EvaluationPointGiven = t.ToString();
                            }
                            db.SubmitChanges();
                        }

                    }
                    else
                    {
                        for (int i = 2; i < 8; i++)
                        {
                            TableCell tc = Table1.Rows[k].Cells[i];
                            Label theId = (Label)Table1.Rows[k].Cells[0].FindControl("K" + k.ToString());
                            RadioButton rb = (RadioButton)tc.FindControl(theId.Text.ToString() + "AM" + i.ToString());
                            bool ischecked = rb.Checked;
                            if (ischecked)
                            {
                                char t = rb.ID.Last();
                                ep.EvaluationPointGiven = t.ToString();
                            }
                        }
                        db.EmployeesToLineMGREvaluations.InsertOnSubmit(ep);
                        db.SubmitChanges();
                    }
                }
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        protected void BtnClearForm_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                int MyLineManagerId = Convert.ToInt32((from x in db.Employee_LineManagers
                                                       where x.employeeID == Convert.ToInt32(Session["loggerId"]) &&
                   x.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                       select x).SingleOrDefault().LineManager);

                var checkExist = (from x in db.EmployeesToLineMGREvaluationForms
                                  where x.LineManagerId ==  MyLineManagerId &&                                  
    x.EmployeeId ==  Convert.ToInt32(Session["loggerId"])&&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkExist != null)
                {
                    db.EmployeesToLineMGREvaluationForms.DeleteOnSubmit(checkExist);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        protected void BtnSaveForm_Click(object sender, EventArgs e)
        {
            if (Session["UserLoggedInID1"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                int MyLineManagerId = Convert.ToInt32((from x in db.Employee_LineManagers
                                                       where x.employeeID == Convert.ToInt32(Session["loggerId"]) &&
                   x.period == Convert.ToInt32(Session["EvaluationPeriod"])
                                                       select x).SingleOrDefault().LineManager);

                var checkExist = (from x in db.EmployeesToLineMGREvaluationForms
                                  where x.EmployeeId == Convert.ToInt32(Session["loggerId"])
    && x.LineManagerId == MyLineManagerId &&
    x.EvaluationPeriod == Convert.ToInt32(Session["EvaluationPeriod"])
                                  select x).SingleOrDefault();
                if (checkExist != null)
                {
                    checkExist.EvaluationDate = DateTime.Now.Date;
                    checkExist.DirectJobRElated = TbxDirectOperational.Text.ToString();
                    checkExist.AdministrativeRElative = TbxAdministrative.Text.ToString();
                    checkExist.StaffDevelopement = TbxStaffDevelopemtn.Text.ToString();
                    checkExist.Generaln = TbxGeneral2.Text.ToString();
                }
                else
                {
                    DataAccess.EmployeesToLineMGREvaluationForm AEN = new DataAccess.EmployeesToLineMGREvaluationForm()
                    {
                        EmployeeId = Convert.ToInt32(Session["loggerId"]),
                        LineManagerId = MyLineManagerId,
                        EvaluationPeriod = Convert.ToInt32(Session["EvaluationPeriod"]),
                        EvaluationDate = DateTime.Now.Date,
                        DirectJobRElated = TbxDirectOperational.Text.ToString(),
                        AdministrativeRElative = TbxAdministrative.Text.ToString(),
                        StaffDevelopement = TbxStaffDevelopemtn.Text.ToString(),
                        Generaln = TbxGeneral2.Text.ToString()
                    };
                    db.EmployeesToLineMGREvaluationForms.InsertOnSubmit(AEN);
                }
                db.SubmitChanges();
                Response.Write("<script>alert('Data Successfully Saved');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wring contact system admin');</script>");
            }
        }
    }
}
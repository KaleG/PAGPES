<%@ Page Title="Employee by Line Manager Evalualtion" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="LineManagersEvaluationReport.aspx.cs" Inherits="PES.Presentation.LineManagersEvaluationReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
     <table style="border: thin dotted #00FFFF; margin-bottom: 5px;margin-top: 5px; width: 96%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
         <tr>
            <td class="formTable">
                <asp:DropDownList ID="DDLEvaluatedEmployee" runat="server" BackColor="#C3CDDB" DataSourceID="SqlDataSource1_LineManagersEmployee"
                    DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                    Font-Names="Book Antiqua" OnDataBound="DDLEvaluatedEmployee_DataBound">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1_LineManagersEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT * FROM [View_EmployessList]">
                </asp:SqlDataSource>
            </td>
            <td class="formTable">
                <asp:Button ID="BtnSelectEmployee" runat="server" Text="Get Line Manager Feedback" CssClass="btn btn-primary" OnClick="BtnSelectEmployee_Click" Width="100%" Height="30px" />
            </td>
        </tr>
    </table>
    
        <div class="col-lg-12" id="Div1" style="margin-top: 2%" runat="server">
            <input id="BtnAreaOfForms" style="color: #cc7a00; width:99%;" onclick="ShowHide()" type="button" value="Area of achievements/Outstanding Performance" class="btn btn-default btnFormSectoin" />
            <div id="DivAreaOfForms" class="divformSections" style="display: none">
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Direct operational related " ID="LblAdditionalEN"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxDirectOpertional" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label1" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Administrative related" ID="Label2"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxAdministrative" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label3" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Client Handling related " ID="Label4"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxClientHandling" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label5" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="General " ID="Label6"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxGeneral" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>                

            </div>
            <input id="BtnAreaOfTables" style="color: #cc7a00; width:99%;" onclick="ShowHide2()" type="button" value="Area of achievements/Outstanding Performance" class="btn btn-default btnFormSectoin" />
            <div id="DivAreaOfTables" class="divformSections" style="display: none">
                <asp:Table Style="width: 95%; margin-left: 2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table1" runat="server">
                    <asp:TableHeaderRow ID="englishHeader" runat="server">

                        <asp:TableHeaderCell># </asp:TableHeaderCell>
                        <asp:TableHeaderCell>Performance Factor </asp:TableHeaderCell>
                        <asp:TableHeaderCell>N/A () </asp:TableHeaderCell>
                        <asp:TableHeaderCell>Unsatisfactory (ተቀባይነት የሌለው) </asp:TableHeaderCell>
                        <asp:TableHeaderCell>Needs Improvement (መሻሻል ይፈልጋል)</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Fully Successful (የሚጠበቅበት ደርሷል)</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Commendable ()</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Outstanding ()</asp:TableHeaderCell>

                    </asp:TableHeaderRow>
                </asp:Table>
               
            </div>
            <input id="BtnAreaOfYesNo" style="color: #cc7a00;width:99%;" onclick="ShowHide3()" type="button" value="Rating Officers General Comment and Notes " class="btn btn-default btnFormSectoin" />
            <div id="DivAreaOfYesNo" class="divformSections" style="display: none">
                <h5 style="margin-left: 2%; font-family: 'Book Antiqua'">The Rating Officials is responsible for completing the following certifications as appropriate</h5>
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="label" Text=" " ID="Label7" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="1.	The rated employee is performing at the Fully Successful level or above, and should be granted the next step within the Grade." ID="Label8"></asp:Label>

                    <asp:RadioButtonList ID="Q1G" runat="server">
                       <asp:ListItem Text="Yes" Value="true"/>
                       <asp:ListItem Text="No" Value="false"/>
                    </asp:RadioButtonList>                    
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label9" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="2.	The employee has demonstrated outstanding performance and should be granted the next two-step within the Grade." ID="Label10"></asp:Label>
                    <asp:RadioButtonList ID="Q2G" runat="server">
                       <asp:ListItem Text="Yes" Value="true"/>
                       <asp:ListItem Text="No" Value="false"/>
                    </asp:RadioButtonList>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label11" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="3.	The employee has demonstrated unsatisfactory performance that he/she needs to improve and do not deserve step increase. " ID="Label12"></asp:Label>
                   <asp:RadioButtonList ID="Q3G" runat="server">
                       <asp:ListItem Text="Yes" Value="true"/>
                       <asp:ListItem Text="No" Value="false"/>
                    </asp:RadioButtonList>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelll" Text=" " ID="Label13" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="4.	The employee has demonstrated the ability to perform the responsibilities assigned at the next level of the career ladder and should be promoted when eligible (must have received a summary rating of Fully Successful or higher).  " ID="Label14"></asp:Label>
                    <asp:RadioButtonList ID="Q4G" runat="server">
                       <asp:ListItem Text="Yes" Value="true"/>
                       <asp:ListItem Text="No" Value="false"/>
                    </asp:RadioButtonList>
                </div>              

            </div>
            <asp:Button ID="BtnExporttoPdf" runat="server" OnClick="BtnExporttoPdf_Click" style="color: #cc7a00;width:99%;" class="btn btn-default btnFormSectoin" Text="Export to Pdf" />       

        </div>
    </div>
    <script>

        function ShowHide() {
            if (document.getElementById("DivAreaOfForms").style.display !== "none") {
                document.getElementById("DivAreaOfForms").style.display = "none";
            }
            else {
                document.getElementById("DivAreaOfForms").style.display = "block";
            }
        }

        function ShowHide2() {
            if (document.getElementById("DivAreaOfTables").style.display !== "none") {
                document.getElementById("DivAreaOfTables").style.display = "none";
            }
            else {
                document.getElementById("DivAreaOfTables").style.display = "block";
            }
        }

        function ShowHide3() {
            if (document.getElementById("DivAreaOfYesNo").style.display !== "none") {
                document.getElementById("DivAreaOfYesNo").style.display = "none";
            }
            else {
                document.getElementById("DivAreaOfYesNo").style.display = "block";
            }
        }

    </script>
</asp:Content>

<%@ Page Title="UnSubmitted Evaluation" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="ReportUnSubmittedEvaluation.aspx.cs" Inherits="PES.Presentation.ReportUnSubmittedEvaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="row" style="width:95%;margin-left:2%;">
        <div class="col-lg-6">
            <h5>UnSubmitted Evaluations</h5>
            <asp:ListBox ID="ListBox1" runat="server" Font-Names="Book Antiqua" Height="100%" Width="95%" Style="margin-left: 10px;" Rows="15"></asp:ListBox>

        </div>
        <div class="col-lg-6">
            <h5>Submitted Evaluations</h5>
            <asp:ListBox ID="ListBox2" runat="server" Font-Names="Book Antiqua" Height="100%" Width="95%" Style="margin-left: 10px;" Rows="15"></asp:ListBox>
        </div>
    </div>

     <div class="row" style="width:95%;margin-left:2%;">
     <table style="border: thin dotted #00FFFF; margin-bottom: 15px;margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
         <tr>
            <td class="formTable">
                <asp:DropDownList ID="DDLEvaluatedEmployee" runat="server" BackColor="#C3CDDB" DataSourceID="SQLSEmployeesList"
                    DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                    Font-Names="Book Antiqua">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1_LineManagersEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT * FROM [View_LineMAnagersEmployes] WHERE ([LineManager] = @LineManager)">
                    <SelectParameters>
                        <asp:SessionParameter Name="LineManager" SessionField="LoggedINEMployee" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SQLSEmployeesList" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT [FullENName], [Id] FROM [View_EmployessList]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Button ID="BtnSelectEmployee" runat="server" Text="Select Evaluator" CssClass="btn btn-primary" OnClick="BtnSelectEmployee_Click" Width="100%" Height="30px" />
            </td>
        </tr>
    </table>
          </div>

     <div class="row" style="width:95%;margin-left:2%;">
        <div class="col-lg-6">
            <h5>UnSubmitted Evaluations</h5>
            <asp:ListBox ID="ListBox3" runat="server" Font-Names="Book Antiqua" Height="100%" Width="95%" Style="margin-left: 10px;" Rows="15"></asp:ListBox>

        </div>
        <div class="col-lg-6">
            <h5>Submitted Evaluations</h5>
            <asp:ListBox ID="ListBox4" runat="server" Font-Names="Book Antiqua" Height="100%" Width="95%" Style="margin-left: 10px;" Rows="15"></asp:ListBox>
        </div>
    </div>


</asp:Content>

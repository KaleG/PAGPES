<%@ Page Title="" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="AllEmployeesReport.aspx.cs" Inherits="PES.Presentation.AllEmployeesReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="border: thin dotted #00FFFF; margin-bottom: 15px;margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
         <tr>  
             <td>
               <!-- <asp:Button ID="BtnSelectEvaluator" runat="server" Text="Selected Evaluator" CssClass="btn btn-primary" OnClick="BtnSelectEvaluator_Click" Width="100%" Height="30px" />-->
                 <asp:Label CssClass="label label-info" Width="100%" Height="30px" ID="Label2" runat="server" Text="Select Evaluator" Font-Size="Medium"></asp:Label>
            </td>
             <td class="formTable">
                <asp:DropDownList ID="DDLEvaluators" runat="server" BackColor="#C3CDDB" 
                    CssClass="" DataSourceID="SQLSEmployeesList"
                    DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                    Font-Names="Book Antiqua">
                    <asp:ListItem>--Select Evaluator </asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SQLSEvaluatorList" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT * FROM [View_EmployessList]"></asp:SqlDataSource>
            </td>
             <td>
               <!-- <asp:Button ID="BtnSelectEmployee" runat="server" Text="Selected Employee" CssClass="btn btn-primary" OnClick="BtnSelectEmployee_Click" Width="100%" Height="30px" />-->
                 <asp:Label ID="Label1" CssClass="label label-info" Width="100%" Height="30px" runat="server" Text="Select Employee" Font-Size="Medium"></asp:Label>
            </td>

              <td class="formTable">
                <asp:DropDownList ID="DDLEvaluatedEmployee" runat="server" BackColor="#C3CDDB" 
                    CssClass="" DataSourceID="SQLSEmployeesList"
                    DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                    Font-Names="Book Antiqua">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SQLSEmployeesList" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT * FROM [View_EmployessList]"></asp:SqlDataSource>
            </td>
             <td>
               <!--- <asp:Button ID="Button1" runat="server" Text="Selected Employee" CssClass="btn btn-primary" OnClick="BtnSelectEmployee_Click" Width="100%" Height="30px" /> -->
                <asp:Button ID="BtnGetReport" runat="server" Text="Get Report" CssClass="btn btn-primary" OnClick="BtnGetReport_Click" Width="100%" Height="30px" />
            </td>           
        </tr>
    </table>

    <asp:Table Style="width:95%; margin-left:2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table1" runat="server">
        <asp:TableHeaderRow ID="englishHeader" runat="server">

            <asp:TableHeaderCell># </asp:TableHeaderCell>
            <asp:TableHeaderCell>Evaluation Points (የምዘና ነጥቦች) </asp:TableHeaderCell>
            <asp:TableHeaderCell>Unacceptable (ተቀባይነት የሌለው) </asp:TableHeaderCell>
            <asp:TableHeaderCell>Need Improvement (መሻሻል ይፈልጋል)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Meet Expectations (የሚጠበቅበት ደርሷል)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Exceeds Expectations (ከሚጠበቀው በላይ ነው)</asp:TableHeaderCell>

        </asp:TableHeaderRow>

    </asp:Table>

</asp:Content>

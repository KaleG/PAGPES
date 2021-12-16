<%@ Page Title="Line Manager by Employee Evaluation" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="MyEmployesEvaluation.aspx.cs" Inherits="PES.Presentation.MyEmployesEvaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="border: thin dotted #00FFFF; margin-bottom: 5px;margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
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
                <asp:Button ID="BtnSelectEmployee" runat="server" Text="Get selected empployee feed back" CssClass="btn btn-primary" OnClick="BtnSelectEmployee_Click" Width="100%" Height="30px" />
            </td>
        </tr>
    </table>
     <asp:Button ID="BtnExporttoPdf" runat="server" OnClick="BtnExporttoPdf_Click" style="color: #cc7a00; width: 95%; margin-left: 2%;" class="btn btn-default btnFormSectoin" Text="Export to Pdf" />       

        <div class="col-lg-12" id="Div1" style="" runat="server">

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="ቀጥታ ከስራ ጋር በተያያዘ " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
                <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Direct operational related " ID="LblAdditionalEN"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="TbxDirectOperational" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
            </div>

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="አስተዳደራዊ/ የአመራር ስራ ጋር በተያያዘ " ID="Label1" ForeColor="Black"></asp:Label>
                <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Administrative/ Supervision related" ID="Label2"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="TbxAdministrative" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
            </div>

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="የሰራተኞችን ችሎታ ከማዳበር /ከማብቃት አንጻር " ID="Label3" ForeColor="Black"></asp:Label>
                <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Staff development related " ID="Label4"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="TbxStaffDevelopemtn" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
            </div>

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="አጠቃላይ ነገሮች " ID="Label5" ForeColor="Black"></asp:Label>
                <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="General " ID="Label6"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="TbxGeneral2" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
            </div>
                        

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
</asp:Content>

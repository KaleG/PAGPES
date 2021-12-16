<%@ Page Title="Evaluate Line Manager" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluateLineManager.aspx.cs" Inherits="PES.Presentation.EvaluateLineManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="col-lg-12" id="Div1" style="" runat="server">

             <div class="row" style="width: 95%; margin-left: 2%;">
                <h5 style="color: #cc7a00;" id="LblMyLineManagerNAme" runat="server">Your area manager is </h5>
            </div>

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

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                    <div class="col-lg-2 col-lg-offset-4">
                        <asp:LinkButton ID="BtnClearForm" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="BtnClearForm_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:LinkButton ID="BtnSaveForm" runat="server" OnClientClick="return dataSaved()" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="BtnSaveForm_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                    </div>
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

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                    <div class="col-lg-2 col-lg-offset-4">
                        <asp:LinkButton ID="BtnClearTable" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="BtnClearTable_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:LinkButton ID="BtnSaveTable" runat="server" OnClientClick="return dataSaved()" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="BtnSaveTable_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                    </div>
                </div>
            </div>
    <script>
        function dataSaved() {
            //alert("Data Successfully Updated");
            var i = "";
        }
    </script>
</asp:Content>

<%@ Page Title="Work plan for next year" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="WorkPlanforNextYear.aspx.cs" Inherits="PES.Presentation.WorkPlanforNextYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-lg-12">
            <table style="border: thin dotted #cc7a00; margin-bottom: 15px; margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
                <tr>
                    <td class="formTable">
                        <h5 style="" runat="server">አላማዎች  Smart Objective</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="TbxSmartObjective" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formTable">
                        <h5 style="" runat="server">አላማዎችን የመፈፀም የሚከተሉአቸው የአፈፃፀም ስልቶች  Action Plan</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="TbxActionPlan" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td class="formTable">
                        <h5 style="" runat="server">የመጨረሻ ውጤት /ግብ    End Result </h5>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxEndResult" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="formTable">
                        <h5 style="" runat="server">የጊዜ ገደብ  መጀመሪያ  Time Frame Start </h5>
                    </td>
                    <td>
                        <asp:TextBox TextMode="Date" ID="Calendar1TimeFrameStart" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="formTable">
                        <h5 style="" runat="server">የጊዜ ገደብ መጨረሻ   Time Frame End </h5>
                    </td>
                    <td>
                        <asp:TextBox TextMode="Date" ID="Calendar1TimeFrameEnd" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                    </td>
                </tr>               

                 <tr>
                    <td class="formTable">
                        <asp:LinkButton ID="BtnREgister" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" Text="Register/Update" OnClientClick="successfullysaved()" OnClick="BtnREgister_Click" BorderColor="#cc7a00" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Register/Update</asp:LinkButton>
                    </td>
                    <td class="formTable">
                        <asp:LinkButton ID="BtnDelete" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" Text="Delete" OnClientClick="successfullysaved()" OnClick="BtnDelete_Click" BorderColor="#cc7a00" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Delete</asp:LinkButton>
                    </td>
                </tr>

            </table>
        </div>
    </div>

    <div class="row">
    <div class="col-lg-12" style="width:95%;margin-left:2%;">
    <asp:GridView Style="margin-top: 5px" ID="GridView1" runat="server" class="table table-bordered table-condensed table-responsive table-hover " AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1_WorkPlans" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" Font-Size="14px" AllowSorting="True" AllowPaging="True" PageSize="20">
        <AlternatingRowStyle BackColor="#f5f8fa"></AlternatingRowStyle>
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>
            <asp:BoundField DataField="EmployeId" HeaderText="EmployeId" SortExpression="EmployeId" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="SmartObjective" HeaderText="SmartObjective" SortExpression="SmartObjective"></asp:BoundField>

            <asp:BoundField DataField="ActionPlan" HeaderText="ActionPlan" SortExpression="ActionPlan"></asp:BoundField>
            <asp:BoundField DataField="EndResult" HeaderText="EndResult" SortExpression="EndResult"></asp:BoundField>
            <asp:BoundField DataField="TimeFrameStart" HeaderText="TimeFrameStart" SortExpression="TimeFrameStart"></asp:BoundField>
            <asp:BoundField DataField="TimeFrameEnd" HeaderText="TimeFrameEnd" SortExpression="TimeFrameEnd"></asp:BoundField>

        </Columns>
        <EditRowStyle BackColor="#7C6F57"></EditRowStyle>

        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#E3EAEB" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="white"></RowStyle>

        <SelectedRowStyle BackColor="#E3EAEB" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
    </asp:GridView>
        </div>
        </div>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1_WorkPlans" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT * FROM [WorkPlanforNextYear] WHERE ([EmployeId] = @EmployeId)">
        <SelectParameters>
            <asp:SessionParameter SessionField="loggerId" Name="EmployeId" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <script>
        function successfullysaved() {
           // alert("Data Successfully Saved");
            var i = "";
        }
    </script>

</asp:Content>

<%@ Page Title="Evaluate you Colleague" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="MidTermEvaluationSheet.aspx.cs" Inherits="PES.Presentation.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" DataSourceID="EvaluationPointsData" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" ForeColor="#333333" GridLines="None" Width="95%" style="margin-left:2%;">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="EvaluationName" HeaderText="EvaluationName" SortExpression="EvaluationName" />
            <asp:TemplateField HeaderText="Unacceptable">
                <FooterTemplate>
                    <asp:Button Style="width=100%" CssClass="btn btn-primary" ID="Button1" runat="server" Text="Button" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:RadioButton ID="RbUnacceptable" runat="server" OnCheckedChanged="RbUnacceptable_CheckedChanged" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Need improvement">
                <ItemTemplate>
                    <asp:RadioButton ID="RbMeetexpectations" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Meet expectations">
                <ItemTemplate>
                    <asp:RadioButton ID="RbExceedsexpectations" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Exceeds expectations">
                <ItemTemplate>
                    <asp:RadioButton ID="IdExceedsexpectations" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    
    <asp:SqlDataSource ID="EvaluationPointsData" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString %>" SelectCommand="SELECT * FROM [LKEvaluationPoints] WHERE ([Language] = @Language)">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="EN" Name="Language" SessionField="SelectedLanguage" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

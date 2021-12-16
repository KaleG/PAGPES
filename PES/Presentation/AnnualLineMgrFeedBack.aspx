<%@ Page Title="Annual Line Manager Feedback" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="AnnualLineMgrFeedBack.aspx.cs" Inherits="PES.Presentation.AnnualLineMgrFeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12" id="Div1" style="" runat="server">

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
                <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Direct operational related Performance" ID="LblAdditionalEN"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="TbxDirectOperational" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
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
            <h5 style="margin-left:2%; font-family: 'Book Antiqua'">Select Evaluating Colleagues</h5>
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
        </div>
</asp:Content>

<%@ Page Title="Annual colleague feedback" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="AnnualColleagueFeedBack.aspx.cs" Inherits="PES.Presentation.AnnualColleagueFeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12" id="viewParticipantsRegion" style="margin-left: 1%" runat="server">
            <h5 style="font-family: 'Book Antiqua'">Select Evaluating Colleagues</h5>

            <table style="border: thin dotted #00FFFF; width: 95%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px; margin-top: inherit; margin-right: inherit; margin-bottom: inherit; margin-left: 10px;">

                <tr>
                    <td class="formTable">
                        <asp:DropDownList ID="DDLParticipants" runat="server" BackColor="#C3CDDB"
                            CssClass="dropdown" DataSourceID="SqlDataSource1_evaluatorsSelection"
                            DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                            Font-Names="Book Antiqua" OnDataBound="DDLParticipants_DataBound">
                        </asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1_evaluatorsSelection" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT [FullENName], [Id] FROM [View_EmployessList]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:Button ID="BtnAddEvaluatorColleague" runat="server" Text="Send Request" CssClass="btn btn-primary" OnClick="BtnAddEvaluatorColleague_Click" Width="100%" Height="30px" />
                    </td>
                </tr>
                <tr>
                    <td class="formTable" colspan="2">
                        <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" DataSourceID="SqlDataSource1_SelectedColleagues" DataTextField="EvaluatorFullName" DataValueField="Id" Font-Names="Book Antiqua" Height="100%" Width="100%" Style="margin-left: 0px;" Rows="6"></asp:ListBox>
                    </td>
                </tr>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1_SelectedColleagues" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT * FROM [View_employe_EvaluatorCollueage] WHERE (([EmployeeId] = @EmployeeId) AND ([period] = @period))">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="loggerId" Name="EmployeeId" Type="Int32"></asp:SessionParameter>
                        <asp:SessionParameter SessionField="EvaluationPeriod" Name="period" Type="Int32"></asp:SessionParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
                <tr>
                    <td class="formTable">
                        <asp:LinkButton ID="btnGetSelected" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn"  OnClick="btnGetSelected_Click" BorderColor="#cc7a00" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Get Selected</asp:LinkButton>
                    </td>
                    <td class="formTable">
                        <asp:LinkButton ID="BtnRemoveColleage" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn btn-warning"  OnClick="BtnRemoveColleage_Click" BorderColor="#cc7a00" BorderStyle="Dotted"><span class="glyphicon glyphicon-remove"></span> Remove Selection</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12" id="Div1" style="margin-top: 2%" runat="server">

            <asp:Table Style="width: 95%; margin-left: 2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table1" runat="server">
                <asp:TableHeaderRow ID="englishHeader" runat="server">

                    <asp:TableHeaderCell># </asp:TableHeaderCell>
                    <asp:TableHeaderCell>Evaluation Points (የምዘና ነጥቦች) </asp:TableHeaderCell>
                    <asp:TableHeaderCell>Unacceptable (ተቀባይነት የሌለው) </asp:TableHeaderCell>
                    <asp:TableHeaderCell>Need Improvement (መሻሻል ይፈልጋል)</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Meet Expectations (የሚጠበቅበት ደርሷል)</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Exceeds Expectations (ከሚጠበቀው በላይ ነው)</asp:TableHeaderCell>

                </asp:TableHeaderRow>

            </asp:Table>

            <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="እባክዎ ሌሎች ከስራ አፈፃፀሞ ጋር የተያያዙ ነገሮች ካሉ ያብራሩ፡፡ ተጨማሪ ገጽ መጠቀም ይችላሉ፡፡ " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
                <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Please specify any thing in relation to your performance. You can use additional page too!" ID="LblAdditionalEN"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="TARAdditionalPoints" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
            </div>

        </div>
    </div>
    <script>
        $(document).ready(function () {
            if (ViewState["Inserted"] == "False") {
                alert("Selected employee can not be evaluator");
            }
            else {
                alert("Data Successfully Saved");
            }
        });
        function successfullysaved() {
            alert("Data Successfully Saved");
        }

        
    </script>
</asp:Content>

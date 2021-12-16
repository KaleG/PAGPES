<%@ Page Title="Your Plan for the Next 6 Month" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="Next6MonthPlans.aspx.cs" Inherits="PES.Presentation.Next6MonthPlans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style=" width:95%; margin-left:2%;background-color: #f2f2f2; margin-bottom: 5px;margin-top: 5px; height: 21px">
    <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:16px;" class="label" Text="ከዚህ የሚከተሉት ላይ ለሚቀጥሉት ስድስት ወራት በአትኩሮት መስራት እፈልጋለሁ፡፡" ID="LblIntroHeaderAM" ForeColor="Black"></asp:Label>
    <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:16px;" class="label" Text="I would like to focus on the following for the next six months" ID="LblIntroHeaderEN"></asp:Label>
     </div> 

    <asp:Table Style="width:95%; margin-left:2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table1" runat="server">
        <asp:TableHeaderRow ID="englishHeader" runat="server">

            <asp:TableHeaderCell># </asp:TableHeaderCell>
            <asp:TableHeaderCell>Major Focus Areas  (የምዘና ነጥቦች) </asp:TableHeaderCell>
            <asp:TableHeaderCell>Top Priority (ከፍተኛ ቅድሚያ) </asp:TableHeaderCell>
            <asp:TableHeaderCell>Medium Priority (መካከለኛ  ቅድሚያ)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Lower Priority (መጨረሻ ቅድሚያ)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Remark (ማስታወሻ)</asp:TableHeaderCell>

        </asp:TableHeaderRow>

    </asp:Table>

    <div class="row" style=" width:95%; margin-left:2%;background-color: #f2f2f2; margin-bottom: 25px;margin-top: 25px; height: 100px">
        <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="እባክዎ ሌሎች ከስራ አፈፃፀሞ ጋር የተያያዙ ነገሮች ካሉ ያብራሩ፡፡ ተጨማሪ ገጽ መጠቀም ይችላሉ፡፡  " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
        <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="Please specify any thing in relation to your performance. You can use additional page too! " ID="LblAdditionalEN"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="TARAdditionalPoints" TextMode="MultiLine" cols="20" rows="3" runat="server"></asp:TextBox>
    </div>


    <div class="row" style="width:95%; margin-left:2%; overflow-y: scroll; background-color: #f2f2f2; margin-bottom: 40px;margin-top: 40px; height: 100px">
        <div class="col-lg-2 col-lg-offset-3">
            <asp:Button Style="width: 100%; margin: 5px;" CssClass="btn btn-primary" ID="btnCleare" runat="server" Text="Clear" OnClick="btnCleare_Click" />
        </div>
        <div class="col-lg-2">
            <asp:Button Style="width: 100%; margin: 5px;" CssClass="btn btn-primary" ID="BtnSave" runat="server" Text="Save" OnClientClick="successfullysaved()" OnClick="BtnSave_Click" />
        </div>
        <div class="col-lg-2">
            <asp:Button Style="width: 100%; margin: 5px;" CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Submit"  OnClientClick="successfullysaved()" OnClick="BtnSave_Click" />
        </div>
    </div>
    

    <script>
        function successfullysaved() {
            alert("Data Successfully Saved");
        }
</script>

</asp:Content>

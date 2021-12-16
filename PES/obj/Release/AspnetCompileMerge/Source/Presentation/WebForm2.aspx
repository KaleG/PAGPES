<%@ Page Title="Evaluate your Performance" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="PES.Presentation.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" style="overflow-y:scroll">
    
    <div class="row" style=" width:95%; margin-left:2%;background-color: #f2f2f2; margin-bottom: 5px;margin-top: 5px; height: 21px">
    <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:16px;" class="label" Text="እባክዎ ከዚህ በታች ያሉት ነጥቦች ላይ ተመርኩዘው እራስዎን ይመዝኑ፡፡ የምዘናዎን ምክንያት ለቅርብ ሃላፊዎ ያብራሩ፡፡" ID="LblIntroHeaderAM" ForeColor="Black"></asp:Label>
    <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:16px;" class="label" Text="Kindly refer the evaluation points under each category and rate your performance accordingly. Justify your rating to your line manager during discussion." ID="LblIntroHeaderEN"></asp:Label>
     </div>  

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

    <div class="row" style=" width:95%; margin-left:2%;background-color: #f2f2f2; margin-bottom: 25px;margin-top: 25px; height: 100px">
        <asp:Label runat="server" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="እባክዎ ሌሎች ከስራ አፈፃፀሞ ጋር የተያያዙ ነገሮች ካሉ ያብራሩ፡፡ ተጨማሪ ገጽ መጠቀም ይችላሉ፡፡ " ID="LblAdditionalAM" ForeColor="Black"></asp:Label>
        <asp:Label runat="server" ForeColor="Black" style="font-family:'Book Antiqua';font-size:14px;" class="label" Text="Please specify any thing in relation to your performance. You can use additional page too!" ID="LblAdditionalEN"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="TARAdditionalPoints" TextMode="MultiLine" cols="20" rows="3" runat="server"></asp:TextBox>
        
    </div>


    <div class="row" style="width:95%; margin-left:2%; background-color: #f5f8fa; margin-bottom: 40px;margin-top: 40px; height: 40px">
        <div class="col-lg-2 col-lg-offset-3">
            <asp:LinkButton ID="btnCleare" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClientClick="successfullysaved()" OnClick="btnCleare_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
        </div>
        <div class="col-lg-2">
            <asp:LinkButton ID="BtnSave" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClientClick="successfullysaved()" OnClick="BtnSave_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
        </div>
        <div class="col-lg-2">
            <asp:LinkButton ID="btnSubmit" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Submit" OnClientClick="successfullysaved()" OnClick="btnSubmit_Click" ><span class="glyphicon glyphicon-ok"></span> Submit </asp:LinkButton>
        </div>
    </div>
 <script>
     function successfullysaved() {
         alert("Data Successfully Saved");
     }

         $(document).ready(function () {
             $('#_Table1').dataTable();
        });
 </script>  

</asp:Content>

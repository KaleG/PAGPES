
<%@ Page Title="Performance Evaluation Sheet" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="AnnualPESheet.aspx.cs" Inherits="PES.Presentation.AnnualPESheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="width: 95%; margin-left: 2%;">
        <div class="col-lg-12">
            <input id="BtnAreaOfAchievement" style="color: #cc7a00;"  onclick="ShowHide()" type="button" value="Area of achievements/Outstanding Performance" class="btn btn-default btnFormSectoin" />
            <div id="DivAreaOfAchievemtn" class="divformSections" style="display: none">
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="ከስራ ሃላፊነት ጋር ቀጥታ የሚገናኙ" ID="LblDirectJobdRElatedAM" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Direct job related " ID="LblDirectJobRElatfedEN"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARDirectJobRElated" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                    </div>
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px;">

                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="በቁጥር ለሚተመኑ ስራዎች ብቻ
(በቁጥር የሚተመኑ ስራዎችን በተመለከተ ከቅርብ አለቃዎ ማብራሪያ ያገኛሉ፡፡ማስታወሻ ቁጥሮች ብቸኛ የስራ አፈፃፀም አመልካቾች አይደሉም፡፡)"
                        ID="Label121" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Only for quantifiable works 
(You will receive a guideline from your line managers regarding quantifiable activities please note that 
Numbers are not the only performance indicator)"
                        ID="Label22" ForeColor="Black"></asp:Label>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelqq" Text="በቀጥታ እኔ ያከናወንኳቸው ተግባራቶች በቁጥር" ID="LblDirectJobREdlatedAM" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Number of Assignment/ Activities Handled directly by myself  " ID="LblDirectJobdRElatedEN"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARNumOfAssigmentSelf" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labeltt" Text="ከሌሎች የስራ ባልደረቦቼ ጋር ያከናወንኳቸው ተግባራቶች በቁጥር" ID="LblDirectJobRElatedAM1" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Number of Assignment/ Activities handled together with another colleague  " ID="LblDirectJobRElatedEN1"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARNumOfAssigmentSelfTogether" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labely" Text="Number of Assignment/ Activities handled together with another colleague " ID="LblDirectJrobRElatedAM2" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Percentage of Assignment/ Activities that I performed within the KPI" ID="LblDirectJobRElatedEN2"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARNumOfAssigmentSelfKPI" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ማስታወሻ" ID="LblDirectJorbRElatedAM2" ForeColor="Black"></asp:Label>
                    <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="ማስታወሻ " ID="LblDirectJobRElatedEN3"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARREmark" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                    <div class="col-lg-2 col-lg-offset-4">
                        <asp:LinkButton ID="LinkButton3" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="LinkButton3_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:LinkButton OnClientClick="return successfullysaved()" ID="LinkButton4" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="LinkButton4_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                    </div>
                </div>

            </div>


            <input id="BtnAreaOfImrovement" style="color: #cc7a00;" onclick="ShowHide2()" type="button" value="Areas of improvement" class="btn btn-default btnFormSectoin" />
            <div id="DivAreaOfImrovement" class="divformSections" style="display: none">

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px;">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="በቁጥር የሚተመኑ ክፍተቶች   Gaps in Quantifiable form"
                        ID="Label1" ForeColor="Black"></asp:Label>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px;">

                    <div class="col-lg-12">
                        <table style="border: thin dotted #00FFFF; margin-bottom: 15px; margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
                            <tr>
                                <td class="formTable">
                                    <h5 style="" runat="server">ስህተቶች  Number of errors in relation to assigned work</h5>
                                </td>
                                <td>
                                    <asp:TextBox ID="TbxNumOfError" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTable">
                                    <h5 style="" runat="server">ጉዳቶች  Number of damages</h5>
                                </td>
                                <td>
                                    <asp:TextBox ID="TbxNumOfDamage" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTable">
                                    <h5 style="" runat="server">መዘግየቶች  Delays caused due to me </h5>
                                </td>
                                <td>
                                    <asp:TextBox ID="TbxNumbOfDelay" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="formTable">
                                    <h5 style="" runat="server">ሌሎች  Others </h5>
                                </td>
                                <td>
                                    <asp:TextBox ID="TbxOther" runat="server" CssClass="form-control formTbx"></asp:TextBox>
                                </td>
                            </tr>


                        </table>
                    </div>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ማስታወሻ  Remark" ID="Label2" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TarRemarkS2" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px;">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="የአለፈው አመት  የግል እና የ ዲፖርትመንት የስራ እቅድ አፈፃፀም / እባክዎ የአለፈው አመት እቅድዎን ያያይዙ/
                        Last Year Individual and/or Departmental Objective revision"
                        ID="TARLastObjective" ForeColor="Black"></asp:Label>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ያለፈውን የአመት ስራ እቅድ እና የድርጊት መርሃ ግብር አዘጋጅተዋል? ምን ያህል ነበሩ? ስንቶቹን አሳክተዋል?
                        Have you set an objective and action plan for the last? If yes how many were they? And how many of them have you achieved?"
                        ID="Label3" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARLastObejctiveAndActionPlan" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="የእቅድ አፈፃፀሞን እንዴት ይመዝኑታል?
/አይመለከተኝም/ተቀባይነት የሌለው/መሻሻል ይፈልጋል/የሚጠበቅበት ደርሷል/ከሚጠበቀው በላይ ነው/ የምዘናዎን ምክንያት ለቅርብ አለቃዎ ያብራሩ፡፡  How do you measure your objective achievement performance? 
(N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together."
                        ID="Label4" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARMeasureAchivment" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="እቅዶን ለማሳካት  ምን ስልት ተጠቅመዋል?  What strategy did you use for the effective implementation?" ID="Label5" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARStrategy" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለመጪው አመት አቅድ መሳካት ምን አቅደዋል
                        What do you plan for effective objective achievement in the new year?"
                        ID="Label6" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TARNextPlan" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                    <div class="col-lg-2 col-lg-offset-4">
                        <asp:LinkButton ID="LinkButton1" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:LinkButton ID="LinkButton2" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="LinkButton2_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                    </div>
                </div>

            </div>

            <input id="BtnAdministrativeRelatedIssues" style="color: #cc7a00;" onclick="ShowHide3()" type="button" value="Administrative related  issues performance revision" class="btn btn-default btnFormSectoin" />
            <div id="DivAdministrativeRelatedIssues" class="divformSections" style="display: none">
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px;">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labeli" Text="አስተዳደራዊ ደንቦችና መመሪያዎችን ማክበር፣የሃላፊነት ስሜት፣የስራ ሰአት ማክበር፣ስለመቅረት 
                        ወይም ስለማርፈድ ለቅርብ አለቃ ማሳወቅ፣አመት ፈቃድን በአግባቡና በእቅድ መጠቀም፣ታዛዥነት፣የተለያዮ ስራዎች ላይ እገዛ ለማድረግ በጐ ፈቃደኝነትን ማሳየት፣የተለያዮ የውስጥ እና የውጭ ስልጠናዎች ላይ ለመሳተፍ ፍላጐት ማሳየት እንዲሁም በአግባቡ መገኘት፣ተገቢ የስራ ልብስ ለብሶ መገኘት፣የድርጅቱን ንብረት በአግባቡ መጠቀም፣ለመልካም ተግባራቶች ምሳሌ መሆን/   (Adhered to company rules and regulations, Punctual to start work, proper dressing, proper allocation/planning of annual leave, Responsible attitude,  Training attendance, Willingness to assist at various tasks, Proper use of company property, Serving as an example for good practices…..)"
                        ID="Label8" ForeColor="Black"></asp:Label>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="አስተዳደራዊ ጉዳዮች በተመለከተ የስራ አፈፃፀሞን እንዴት ይመዝኑታል?
/አይመለከተኝም/ተቀባይነት የሌለው/መሻሻል ይፈልጋል/የሚጠበቅበት ደርሷል/ከሚጠበቀው በላይ ነው/ የምዘናዎን ምክንያት ለቅርብ አለቃዎ ያብራሩ፡፡
  How do you measure your performance?
(N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together.
"
                        ID="Label9" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxAdministrativePerfomance" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለመጪው አመት መልካም አፈፃፀም ምን አቅደዋል?
 What do you plan for effective Administrative related issues performance achievement in the new year?"
                        ID="Label10" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxAdministrativeNextPlan" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                    <div class="col-lg-2 col-lg-offset-4">
                        <asp:LinkButton ID="LinkButton5" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="LinkButton5_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:LinkButton ID="LinkButton6" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="LinkButton6_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                    </div>
                </div>
            </div>

            <input id="BtnPAGReputationMarketingRelated" style="color: #cc7a00;" onclick="ShowHide4()" type="button" value="PAG reputation/Marketing  related performance revision" class="btn btn-default btnFormSectoin" />
            <div id="DivPAGReputationMarketingRelated" class="divformSections" style="display: none">
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px;">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labeli" Text="/በስራዎ ጥራት/ ብዛት ላይ የደንበኞች እርካታ፣ከደንበኞች ጋር ያለ ሙያዊ ተግባቦት፣በአካል፣በስልክ እንዲሁም በኢሜል በግልጽ እና በንቃት የመግባባት ችሎታ፣አዲስ ገበያን ለማምጣት ያለ አስተዋጽኦ፣ነባር ደንበኞችን የማቆየት ብቃት/   (Client satisfaction with quality/quantity of work, professional communication with the client, Communicate clearly and intelligently in person, through email and during telephone, Contribution to bring new market, Ability to maintain existing client….)"
                        ID="Label11" ForeColor="Black"></asp:Label>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለፖን አፍሪክ ግሎባል ገበያ ወይም ጥሩ ስም ያሎት አስተዋጽኦ / የስራ አፈፃፀሞን እንዴት ይመዝኑታል?
/አይመለከተኝም/ተቀባይነት የሌለው/መሻሻል ይፈልጋል/የሚጠበቅበት ደርሷል/ከሚጠበቀው በላይ ነው/ የምዘናዎን ምክንያት ለቅርብ አለቃዎ ያብራሩ፡፡
How do you measure your performance?
(N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together."
                        ID="Label12" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="tbxMarketingRElatedPerformance" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለመጪው አመት መልካም አፈፃፀም ምን አቅደዋል?
What do you plan for effective PAG reputation/Marketing related performance achievement in the new year?"
                        ID="Label13" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxMarketingRElatedPlan" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                    <div class="col-lg-2 col-lg-offset-4">
                        <asp:LinkButton ID="LinkButton7" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="LinkButton7_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:LinkButton ID="LinkButton8" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="LinkButton8_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                    </div>
                </div>
            </div>

            <input id="BtnOverallPerformance" style="color: #cc7a00;" onclick="ShowHide5()" type="button" value="Overall performance/General performance revision" class="btn btn-default btnFormSectoin" />
            <div id="DivOverallPerformance" class="divformSections" style="display: none">
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px;">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labeli" Text="/ሌሎችን ለማሰልጠን አስተዋጽኦ ማድረግ፣በጫና ውስጥም ያለምንም ወይም በትንሽ ቁጥጥር የተሰጣቸውን ተግባራቶች ማከናወን፣ችግርን የመፍታት ችሎታ፣ተጨማሪ ስራዎችን የመቀበል ፈቃደኝነት፣የደህንነት መርሆችን  ለመተግበር ያለ  ጽናት/ቁርጠኝነት፣ገንቢ የሆኑ/ የሚያሻሽሉ እርማቶችን መቀበል መቻል፣ የመግባባት ክህሎት/ ከሌሎች ጋር መልካም የስራ ግንኙነት የመፍጠር ክህሎት፣አጠቃላይ የስራ አፈፃፀም/   (Contribution to train others, performs assigned duties with little or no supervision even under pressure, Problem-solving, Willingness to accept additional assignment, Commitment and adherence to safety procedure, Accept constructive criticism, Interpersonal skill/ Relation with Other…..)"
                        ID="Label14" ForeColor="Black"></asp:Label>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለሌሎች አጠቃላይ የስራ አፈፃፀሞን እንዴት ይመዝኑታል?
/አይመለከተኝም/ተቀባይነት የሌለው/መሻሻል ይፈልጋል/የሚጠበቅበት ደርሷል/ከሚጠበቀው በላይ ነው/ የምዘናዎን ምክንያት ለቅርብ አለቃዎ ያብራሩ፡፡
How do you measure your performance?
(N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together.
"
                        ID="Label15" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxOverAllGeneralPerformace" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለመጪው አመት መልካም አፈፃፀም ምን አቅደዋል?
What do you plan for effective overall/ General performance achievement in the new year?"
                        ID="Label16" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxOverAllGeneralPlan" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                    <div class="col-lg-2 col-lg-offset-4">
                        <asp:LinkButton ID="LinkButton9" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="LinkButton9_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:LinkButton ID="LinkButton10" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="LinkButton10_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                    </div>
                </div>
            </div>

            <input id="BtnAdditionalPointRelatedtoPagGeneral" style="color: #cc7a00;" onclick="ShowHide6()" type="button" value="Additional points Related with PAG  in general" class="btn btn-default btnFormSectoin" />
         
            <div id="DivAdditionalPointRelatedtoPagGeneral" class="divformSections" style="display: none">

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="መበረታታታ ያለባቸው   Good practices"
                        ID="Label17" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxGoodPractice" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="መሻሻል ያለባቸው   Areas to be reviewed"
                        ID="Label19" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxAreasREviewed" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>

                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="የሰራተኛው አስተያየት   Employee Statement"
                        ID="Label18" ForeColor="Black"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TbxEmployeeStatement" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                </div>
                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                    <div class="col-lg-2 col-lg-offset-4">
                        <asp:LinkButton ID="LinkButton11" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="LinkButton11_Click"><span class="glyphicon glyphicon-remove"></span> Clear </asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:LinkButton ID="LinkButton12" OnClientClick="return successfullysaved()" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="LinkButton12_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                    </div>
                </div>
            </div>

            <div>
                <asp:Button ID="BtnSubmittAll" OnClick="BtnSubmittAll_Click"  OnClientClick="return successfullysubmitted()" runat="server" Text="Submit all Forms" CssClass="btn btn-warning btnFormSectoin" />
            </div>

        </div>
    </div>

    <script>

        function ShowHide() {
            if (document.getElementById("DivAreaOfAchievemtn").style.display !== "none") {
                document.getElementById("DivAreaOfAchievemtn").style.display = "none";
            }
            else {
                document.getElementById("DivAreaOfAchievemtn").style.display = "block";
            }
        }

        function ShowHide2() {
            if (document.getElementById("DivAreaOfImrovement").style.display !== "none") {
                document.getElementById("DivAreaOfImrovement").style.display = "none";
            }
            else {
                document.getElementById("DivAreaOfImrovement").style.display = "block";
            }
        }
        function ShowHide3() {
            if (document.getElementById("DivAdministrativeRelatedIssues").style.display !== "none") {
                document.getElementById("DivAdministrativeRelatedIssues").style.display = "none";
            }
            else {
                document.getElementById("DivAdministrativeRelatedIssues").style.display = "block";
            }
        }
        function ShowHide4() {
            if (document.getElementById("DivPAGReputationMarketingRelated").style.display !== "none") {
                document.getElementById("DivPAGReputationMarketingRelated").style.display = "none";
            }
            else {
                document.getElementById("DivPAGReputationMarketingRelated").style.display = "block";
            }
        }
        function ShowHide5() {
            if (document.getElementById("DivOverallPerformance").style.display !== "none") {
                document.getElementById("DivOverallPerformance").style.display = "none";
            }
            else {
                document.getElementById("DivOverallPerformance").style.display = "block";
            }
        }
        function ShowHide6() {
            if (document.getElementById("DivAdditionalPointRelatedtoPagGeneral").style.display !== "none") {
                document.getElementById("DivAdditionalPointRelatedtoPagGeneral").style.display = "none";
            }
            else {
                document.getElementById("DivAdditionalPointRelatedtoPagGeneral").style.display = "block";
            }
        }

        function successfullysaved() {
            var i = "";
           // alert("Data Successfully Updated");
        }


        function successfullysubmitted() {
            var i = "";
           // alert("Form Successfully Submitted");
        }

    </script>
</asp:Content>

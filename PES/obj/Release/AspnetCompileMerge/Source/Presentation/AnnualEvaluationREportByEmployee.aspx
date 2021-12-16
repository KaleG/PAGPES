<%@ Page Title="Annual Evaluation Report" Language="C#" MasterPageFile="~/SharedResources/Site1.Master" AutoEventWireup="true" CodeBehind="AnnualEvaluationREportByEmployee.aspx.cs" Inherits="PES.Presentation.AnnualEvaluationREportByEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <table style="border: thin dotted #00FFFF; margin-bottom: 5px; margin-top: 5px; width: 95%; margin-left: 2%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px;">
            <tr>
                <td class="formTable">
                    <asp:DropDownList ID="DDLEvaluatedEmployee" runat="server" BackColor="#C3CDDB" DataSourceID="SqlDataSource1_LineManagersEmployee"
                        DataTextField="FullENName" DataValueField="Id" Height="30px" Width="100%"
                        Font-Names="Book Antiqua" OnDataBound="DDLEvaluatedEmployee_DataBound">                        
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1_LineManagersEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>" SelectCommand="SELECT [Id], [FullENName] FROM [View_EmployessList]"></asp:SqlDataSource>
                </td>
                <td class="formTable">
                    <asp:Button ID="BtnSelectEmployee" runat="server" Text="Get selected empployee feed back" CssClass="btn btn-default" OnClick="BtnSelectEmployee_Click" Width="100%" Height="30px" />
                </td>
                
            </tr>
        </table>
            <asp:Button ID="BtnExporttoPdf" runat="server" OnClick="BtnExporttoPdf_Click" style="color: #cc7a00;width:95%;margin-left:2%;" class="btn btn-default btnFormSectoin" Text="Export to Pdf" />       
         <div id="DivheaderTxts" class="row" style="display:none; width: 95%; margin-left: 2%;" runat="server">
                <h4 style="color: #cc7a00;" id="Lbl1" runat="server">PAG PERFORMANCE EVALUATION SHEET</h4>
                <h5 style="color: #cc7a00;" id="LblEmployeeName" runat="server"></h5>
                <h5 style="color: #cc7a00;" id="LblDate" runat="server"> </h5>
            </div>

    <h5 style="color: #cc7a00;display:none;" id="H1" runat="server">Area of achievments / outstanding performance </h5>
    <h5 style="color: #cc7a00;display:none;" id="H2" runat="server">Areas of Improvement </h5>
    <h5 style="color: #cc7a00;display:none;" id="H3" runat="server">Administrative related issues performance revision </h5>
    <h5 style="color: #cc7a00;display:none;" id="H4" runat="server">PAG reputation/Marketing related performance revision </h5>
    <h5 style="color: #cc7a00;display:none;" id="H5" runat="server">Overall performance/General Performance Revision </h5>
    <h5 style="color: #cc7a00;display:none;" id="H6" runat="server">Addition Points Related with PAG in General </h5>
    <h5 style="color: #cc7a00;display:none;" id="H7" runat="server">Plans for next Year</h5>

   

        <div class="row" style="width: 95%; margin-left: 2%;">
            <div class="col-lg-12">
                <h4>Employees Performance Evaluation Sheets</h4>
             <input id="BtnAreaOfAchievement" style="color: #cc7a00;" onclick="ShowHide()" type="button" value="Area of achievements/Outstanding Performance" class="btn btn-default btnFormSectoin" />
               <div id="DivAreaOfAchievemtn" class="divformSections" style="display: none" runat="server">
                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <div><asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="ከስራ ሃላፊነት ጋር ቀጥታ የሚገናኙ" ID="LblDirectJobdRElatedAM" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Direct job related " ID="LblDirectJobRElatfedEN"></asp:Label>
                        </div><asp:TextBox CssClass="form-control" ID="TARDirectJobRElated" TextMode="MultiLine" Columns="100"  Rows="3" runat="server"></asp:TextBox>
                    </div>
                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px;">

                      <div>  <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="በቁጥር ለሚተመኑ ስራዎች ብቻ
(በቁጥር የሚተመኑ ስራዎችን በተመለከተ ከቅርብ አለቃዎ ማብራሪያ ያገኛሉ፡፡ማስታወሻ ቁጥሮች ብቸኛ የስራ አፈፃፀም አመልካቾች አይደሉም፡፡)"
                            ID="Label121" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Only for quantifiable works 
(You will receive a guideline from your line managers regarding quantifiable activities please note that 
Numbers are not the only performance indicator)"
                            ID="Label22" ForeColor="Black"></asp:Label>
                    </div></div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                      <div>  <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelqq" Text="በቀጥታ እኔ ያከናወንኳቸው ተግባራቶች በቁጥር" ID="LblDirectJobREdlatedAM" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Number of Assignment/ Activities Handled directly by myself  " ID="LblDirectJobdRElatedEN"></asp:Label>
                       </div> <asp:TextBox CssClass="form-control" ID="TARNumOfAssigmentSelf" TextMode="MultiLine"  Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                       <div>  <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labeltt" Text="ከሌሎች የስራ ባልደረቦቼ ጋር ያከናወንኳቸው ተግባራቶች በቁጥር" ID="LblDirectJobRElatedAM1" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Number of Assignment/ Activities handled together with another colleague  " ID="LblDirectJobRElatedEN1"></asp:Label>
                       </div>  <asp:TextBox CssClass="form-control" ID="TARNumOfAssigmentSelfTogether" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>
                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <div> <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labely" Text="Number of Assignment/ Activities handled together with another colleague " ID="LblDirectJrobRElatedAM2" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Percentage of Assignment/ Activities that I performed within the KPI" ID="LblDirectJobRElatedEN2"></asp:Label>
                        </div> <asp:TextBox CssClass="form-control" ID="TARNumOfAssigmentSelfKPI" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <div> <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ማስታወሻ" ID="LblDirectJorbRElatedAM2" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Remark " ID="LblDirectJobRElatedEN3"></asp:Label>
                        </div> <asp:TextBox CssClass="form-control" ID="TARREmark" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                </div>

                <input id="BtnAreaOfImrovement" style="color: #cc7a00;" onclick="ShowHide2()" type="button" value="Areas of improvement" class="btn btn-default btnFormSectoin" />
                <div id="DivAreaOfImrovement" class="divformSections" style="display: none" runat="server">

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
                        <asp:TextBox CssClass="form-control" ID="TarRemarkS2" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="form-control" ID="TARLastObejctiveAndActionPlan" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="የእቅድ አፈፃፀሞን እንዴት ይመዝኑታል?
/አይመለከተኝም/ተቀባይነት የሌለው/መሻሻል ይፈልጋል/የሚጠበቅበት ደርሷል/ከሚጠበቀው በላይ ነው/ የምዘናዎን ምክንያት ለቅርብ አለቃዎ ያብራሩ፡፡  How do you measure your objective achievement performance? 
(N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together."
                            ID="Label4" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TARMeasureAchivment" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="እቅዶን ለማሳካት  ምን ስልት ተጠቅመዋል?  What strategy did you use for the effective implementation?" ID="Label5" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TARStrategy" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለመጪው አመት አቅድ መሳካት ምን አቅደዋል
                        What do you plan for effective objective achievement in the new year?"
                            ID="Label6" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TARNextPlan" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>



                </div>

                <input id="BtnAdministrativeRelatedIssues" style="color: #cc7a00;" onclick="ShowHide3()" type="button" value="Administrative related  issues performance revision" class="btn btn-default btnFormSectoin" />
                <div id="DivAdministrativeRelatedIssues" class="divformSections" style="display: none" runat="server">
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
                        <asp:TextBox CssClass="form-control" ID="TbxAdministrativePerfomance" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለመጪው አመት መልካም አፈፃፀም ምን አቅደዋል?
 What do you plan for effective PAG reputation/Marketing related performance achievement in the new year?
(N/A/unacceptable/need improvement/ meet expectation/ Exceed expectation) Please put your justification together.
"
                            ID="Label10" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxAdministrativeNextPlan" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                </div>

                <input id="BtnPAGReputationMarketingRelated" style="color: #cc7a00;" onclick="ShowHide4()" type="button" value="PAG reputation/Marketing  related performance revision" class="btn btn-default btnFormSectoin" />
                <div id="DivPAGReputationMarketingRelated" class="divformSections" style="display: none" runat="server">
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
                        <asp:TextBox CssClass="form-control" ID="tbxMarketingRElatedPerformance" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለመጪው አመት መልካም አፈፃፀም ምን አቅደዋል?
What do you plan for effective PAG reputation/Marketing related performance achievement in the new year?"
                            ID="Label13" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxMarketingRElatedPlan" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                </div>

                <input id="BtnOverallPerformance" style="color: #cc7a00;" onclick="ShowHide5()" type="button" value="Overall performance/General performance revision" class="btn btn-default btnFormSectoin" />
                <div id="DivOverallPerformance" class="divformSections" style="display: none" runat="server">
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
                        <asp:TextBox CssClass="form-control" ID="TbxOverAllGeneralPerformace" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="ለመጪው አመት መልካም አፈፃፀም ምን አቅደዋል?
What do you plan for effective overall/ General performance achievement in the new year?"
                            ID="Label16" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxOverAllGeneralPlan" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                </div>

                <input id="BtnAdditionalPointRelatedtoPagGeneral" style="color: #cc7a00;" onclick="ShowHide6()" type="button" value="Additional points Related with PAG  in general" class="btn btn-default btnFormSectoin" />
                <div id="DivAdditionalPointRelatedtoPagGeneral" class="divformSections" style="display: none" runat="server">

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="መበረታታታ ያለባቸው   Good practices"
                            ID="Label17" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxGoodPractice" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="መሻሻል ያለባቸው   Areas to be reviewed"
                            ID="Label19" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxAreasREviewed" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 25px; margin-top: 25px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="የሰራተኛው አስተያየት   Employee Statement"
                            ID="Label18" ForeColor="Black"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxEmployeeStatement" TextMode="MultiLine" Columns="100" Rows="3" runat="server"></asp:TextBox>
                    </div>

                </div>

            </div>
        </div>


        <div class="row" style="width: 95%; margin-left: 2%;">
            <div class="col-lg-12">
                <h4>Employees Plan for Next Year</h4>
                <input id="BtnAreaOfNextYearPlan" style="color: #cc7a00;" onclick="ShowHideNextYearPlan()" type="button" value="Employees Plan for Next Year" class="btn btn-default btnFormSectoin" />

                <div class="row" id="DivAreaOfNextYearPlan" style="display: none;" runat="server">
                    <div class="col-lg-12" style="width: 95%; margin-left: 2%;">
                        <asp:GridView Style="margin-top: 5px" ID="GridView1" runat="server" class="table table-bordered table-condensed table-responsive table-hover " AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1_WorkPlans" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Size="14px" AllowSorting="True" AllowPaging="True">
                            <AlternatingRowStyle BackColor="#f5f8fa"></AlternatingRowStyle>
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>

                                <asp:BoundField DataField="EmployeId" HeaderText="EmployeId" SortExpression="EmployeId"></asp:BoundField>
                                <asp:BoundField DataField="SmartObjective" HeaderText="SmartObjective" SortExpression="SmartObjective"></asp:BoundField>
                                <asp:BoundField DataField="ActionPlan" HeaderText="ActionPlan" SortExpression="ActionPlan"></asp:BoundField>

                                <asp:BoundField DataField="EndResult" HeaderText="EndResult" SortExpression="EndResult"></asp:BoundField>
                                <asp:BoundField DataField="TimeFrameStart" HeaderText="TimeFrameStart" SortExpression="TimeFrameStart"></asp:BoundField>
                                <asp:BoundField DataField="TimeFrameEnd" HeaderText="TimeFrameEnd" SortExpression="TimeFrameEnd"></asp:BoundField>
                                <asp:BoundField DataField="EvaluationPlanPeriod" HeaderText="EvaluationPlanPeriod" SortExpression="EvaluationPlanPeriod"></asp:BoundField>

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
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1_WorkPlans" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT * FROM [WorkPlanforNextYear] WHERE (([EmployeId] = @EmployeId) AND ([EvaluationPlanPeriod] = @EvaluationPlanPeriod))">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DDLEvaluatedEmployee" PropertyName="SelectedValue" Name="EmployeId" Type="Int32"></asp:ControlParameter>
                                <asp:SessionParameter SessionField="EvaluationPeriod" Name="EvaluationPlanPeriod" Type="Int32"></asp:SessionParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="width: 95%; margin-left: 2%;">
            <div class="col-lg-12">
                

                <h4>Line Manager Feed Back</h4>
                <input id="BtnAreaOfForms" style="color: #cc7a00;" onclick="ShowHideDiv11()" type="button" value="Area of achievements/Outstanding Performance" class="btn btn-default btnFormSectoin" />
                <div id="DivAreaOfForms" class="divformSections" style="display: none" runat="server">
                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label7" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Direct operational related " ID="Label20"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxDirectOpertional" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label21" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Administrative related" ID="Label23"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxAdministrative" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label24" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="Client Handling related " ID="Label25"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxClientHandling" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label26" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="General " ID="Label27"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxGeneral" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                    </div>
                </div>
                <input id="BtnAreaOfTables" style="color: #cc7a00;" onclick="ShowHide22()" type="button" value="Area of achievements/Outstanding Performance - with performace factor" class="btn btn-default btnFormSectoin" />
                <div id="DivAreaOfTables" class="divformSections" style="display: none" runat="server">
                    <asp:Table Style="width: 95%; margin-left: 2%" class="table table-condensed table-hover table-striped table-bordered table-responsive" ID="Table12" runat="server">
                        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server">
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
                <input id="BtnAreaOfYesNo" style="color: #cc7a00;" onclick="ShowHide33()" type="button" value="Rating Officers General Comment and Notes " class="btn btn-default btnFormSectoin" />
                <div id="DivAreaOfYesNo" class="divformSections" style="display: none" runat="server">
                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="label" Text=" " ID="Label28" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="1.	The rated employee is performing at the Fully Successful level or above, and should be granted the next step within the Grade." ID="Label29"></asp:Label>

                        <asp:RadioButtonList ID="Q1G" runat="server">
                            <asp:ListItem Text="Yes" Value="true" />
                            <asp:ListItem Text="No" Value="false" />
                        </asp:RadioButtonList>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label30" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="2.	The employee has demonstrated outstanding performance and should be granted the next two-step within the Grade." ID="Label31"></asp:Label>
                        <asp:RadioButtonList ID="Q2G" runat="server">
                            <asp:ListItem Text="Yes" Value="true" />
                            <asp:ListItem Text="No" Value="false" />
                        </asp:RadioButtonList>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label32" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="3.	The employee has demonstrated unsatisfactory performance that he/she needs to improve and do not deserve step increase. " ID="Label33"></asp:Label>
                        <asp:RadioButtonList ID="Q3G" runat="server">
                            <asp:ListItem Text="Yes" Value="true" />
                            <asp:ListItem Text="No" Value="false" />
                        </asp:RadioButtonList>
                    </div>

                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelll" Text=" " ID="Label34" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="4.	The employee has demonstrated the ability to perform the responsibilities assigned at the next level of the career ladder and should be promoted when eligible (must have received a summary rating of Fully Successful or higher).  " ID="Label35"></asp:Label>
                        <asp:RadioButtonList ID="Q4G" runat="server">
                            <asp:ListItem Text="Yes" Value="true" />
                            <asp:ListItem Text="No" Value="false" />
                        </asp:RadioButtonList>
                    </div>
                </div>

                <h4>Employees - Colleague FeedBack </h4>
                <input id="BtnAreaOfColleagueFeedBAck" style="color: #cc7a00;" onclick="show11()" type="button" value="Colleague Feedback" class="btn btn-default btnFormSectoin" />
                <div class="row" id="DivAreaOfColleagueFeedBAck" style="" runat="server">
                    <div class="col-lg-12" style="width: 95%; margin-left: 2%;">
                        <table style="border: thin dotted #00FFFF; width: 99%; font-family: 'Book Antiqua'; line-height: normal; padding-top: inherit; padding-right: inherit; padding-bottom: inherit; padding-left: 10px; margin-top: inherit; margin-right: inherit; margin-bottom: inherit; margin-left: 10px; margin-top: 2%;">
                            <tr>
                                <td class="formTable" colspan="2">
                                    <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" DataSourceID="SqlDataSource1_SelectedColleagues" DataTextField="EvaluatorFullName" DataValueField="Id" Font-Names="Book Antiqua" Height="100%" Width="100%" Style="margin-left: 0px;" Rows="6"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="formTable">
                                    <asp:LinkButton ID="btnGetSelected" runat="server" Style="width: 98%; margin: 5px;" CssClass="btn" OnClick="btnGetSelected_Click" BorderColor="#cc7a00" BorderStyle="Dotted"><span class="glyphicon glyphicon-ok"></span> Get Selected</asp:LinkButton>
                                </td>
                            </tr>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource1_SelectedColleagues" ConnectionString='<%$ ConnectionStrings:PerformaceEvaluationConnectionString1 %>' SelectCommand="SELECT * FROM [View_employe_EvaluatorCollueage] WHERE (([EmployeeId] = @EmployeeId) AND ([period] = @period))">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLEvaluatedEmployee" PropertyName="SelectedValue" Name="EmployeeId" Type="Int32"></asp:ControlParameter>
                                    <asp:SessionParameter SessionField="EvaluationPeriod" Name="period" Type="Int32"></asp:SessionParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </table>
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

                                <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 5px; margin-top: 5px; height: 25px">
                                    <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="" ID="LblIdontMind" ForeColor="Black"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <h4>To Be Completed by CEO </h4>
                <input id="BtnAreaCEO" style="color: #cc7a00;" onclick="" type="button" value="CEO Comment" class="btn btn-default btnFormSectoin" />
                <div id="DivAreaOfCEO" class="divformSections" style="display: block" runat="server">
                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelll" Text=" " ID="Label36" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="labelii" Text="1.	I support the rating manager and employee’s evaluation." ID="Label37"></asp:Label>
                        <asp:RadioButtonList ID="RbtCEOComment" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes" />
                            <asp:ListItem Text="No" Value="No" />
                        </asp:RadioButtonList>
                    </div>
                    <div class="row" style="width: 95%; margin-left: 2%; background-color: #f2f2f2; margin-bottom: 40px; margin-top: 40px; height: 100px">
                        <asp:Label runat="server" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text=" " ID="Label38" ForeColor="Black"></asp:Label>
                        <asp:Label runat="server" ForeColor="Black" Style="font-family: 'Book Antiqua'; font-size: 14px;" class="" Text="YES because/ MAY BE/ NO because " ID="Label39"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="TbxCEOComment" TextMode="MultiLine" cols="20" Rows="3" runat="server"></asp:TextBox>
                    </div>
                    <div id="DivCEoSection" runat="server" class="row" style="width: 95%; margin-left: 2%; background-color: #f5f8fa; margin-bottom: 5px; margin-top: 5px; height: 40px">
                        <div class="col-lg-2 col-lg-offset-4">
                            <asp:LinkButton ID="TbxClear" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn" Text="Clear" OnClick="TbxClear_Click"><span class="glyphicon glyphicon-remove"></span> Clear / Delete </asp:LinkButton>
                        </div>
                        <div class="col-lg-2">
                            <asp:LinkButton ID="TbxSave" runat="server" Style="width: 100%; margin: 5px;" CssClass="btn " Text="Save" OnClick="TbxSave_Click"><span class="glyphicon glyphicon-floppy-save"></span> Save </asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        
        <script>
            function ShowHide() {
                if (document.getElementById("<%=DivAreaOfAchievemtn.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAreaOfAchievemtn.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAreaOfAchievemtn.ClientID %>").style.display = "block";
                }
            }

            function ShowHide2() {
                if (document.getElementById("<%=DivAreaOfImrovement.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAreaOfImrovement.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAreaOfImrovement.ClientID %>").style.display = "block";
                }
            }

            function ShowHide3() {
                if (document.getElementById("<%=DivAdministrativeRelatedIssues.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAdministrativeRelatedIssues.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAdministrativeRelatedIssues.ClientID %>").style.display = "block";
                }
            }

            function ShowHide4() {
                if (document.getElementById("<%=DivPAGReputationMarketingRelated.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivPAGReputationMarketingRelated.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivPAGReputationMarketingRelated.ClientID %>").style.display = "block";
                }
            }
            function ShowHide5() {
                if (document.getElementById("<%=DivOverallPerformance.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivOverallPerformance.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivOverallPerformance.ClientID %>").style.display = "block";
                }
            }

            function ShowHide6() {
                if (document.getElementById("<%=DivAdditionalPointRelatedtoPagGeneral.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAdditionalPointRelatedtoPagGeneral.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAdditionalPointRelatedtoPagGeneral.ClientID %>").style.display = "block";
                }
            }

            function ShowHideNextYearPlan() {
                if (document.getElementById("<%=DivAreaOfNextYearPlan.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAreaOfNextYearPlan.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAreaOfNextYearPlan.ClientID %>").style.display = "block";
                }
            }

            function ShowHideAreaOfColleagueFeedBAck() {
                if (document.getElementById("<%=DivAreaOfColleagueFeedBAck.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAreaOfColleagueFeedBAck.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAreaOfColleagueFeedBAck.ClientID %>").style.display = "block";
                }
            }

            function ShowHideDiv11() {
                if (document.getElementById("<%=DivAreaOfForms.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAreaOfForms.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAreaOfForms.ClientID %>").style.display = "block";
                }
            }

            function ShowHide22() {
                if (document.getElementById("<%=DivAreaOfTables.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAreaOfTables.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAreaOfTables.ClientID %>").style.display = "block";
                }
            }

            function ShowHide33() {
                if (document.getElementById("<%=DivAreaOfYesNo.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAreaOfYesNo.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAreaOfYesNo.ClientID %>").style.display = "block";
                }
            }

             function show11() {
                if (document.getElementById("<%=DivAreaOfColleagueFeedBAck.ClientID %>").style.display !== "none") {
                    document.getElementById("<%=DivAreaOfColleagueFeedBAck.ClientID %>").style.display = "none";
                }
                else {
                    document.getElementById("<%=DivAreaOfColleagueFeedBAck.ClientID %>").style.display = "block";
                }
            }


            function successfullysaved() {
                alert("Data Successfully Updated");
            }

            function ShowPrintPreview() {

                debugger;
               // document.getElementById("DivAreaOfAchievemtn").hidden = false;
               // document.getElementById("DivAreaOfImrovement") = false;
                   
                var panel0 = document.getElementById("<%=DivheaderTxts.ClientID %>");
                var panelH1 = document.getElementById("<%=H1.ClientID %>");
                var panelH2 = document.getElementById("<%=H2.ClientID %>");
                var panelH3 = document.getElementById("<%=H3.ClientID %>");
                var panelH4 = document.getElementById("<%=H4.ClientID %>");
                var panelH5 = document.getElementById("<%=H5.ClientID %>");
                var panelH6 = document.getElementById("<%=H6.ClientID %>");
                var panelH7 = document.getElementById("<%=H7.ClientID %>");
                var panel = document.getElementById("<%=DivAreaOfAchievemtn.ClientID %>");
                //            panel.style.visibility = "visible";               
                var panel2 = document.getElementById("<%=DivAreaOfImrovement.ClientID%>");
                var panel3 = document.getElementById("<%=DivAdministrativeRelatedIssues.ClientID%>");
                var panel4 = document.getElementById("<%=DivPAGReputationMarketingRelated.ClientID%>");
                var panel5 = document.getElementById("<%=DivOverallPerformance.ClientID%>");
                var panel6 = document.getElementById("<%=DivAdditionalPointRelatedtoPagGeneral.ClientID%>");
                var panel7 = document.getElementById("<%=DivAreaOfNextYearPlan.ClientID%>");
                //var panel8 = document.getElementById("<%=DivAreaOfColleagueFeedBAck.ClientID%>");
               // var panel9 = document.getElementById("<%=DivAreaOfForms.ClientID%>");
               // var panel10 = document.getElementById("<%=DivAreaOfTables.ClientID%>");
               // var panel11 = document.getElementById("<%=DivAreaOfYesNo.ClientID%>");
               
                panel.style = 'preview-message';
                var printWindow = window.open(panel, '', 'height=700,width=1100');
                printWindow.document.styleSheets = 'preview-message';
                printWindow.document.write('<html><head><title>DIV Contents</title>');
                printWindow.document.write('</head><body >');
                printWindow.document.write(panel0.innerHTML);
                printWindow.document.write(panelH1.innerHTML);
                printWindow.document.write(panel.innerHTML);
                printWindow.document.write(panelH2.innerHTML);
                printWindow.document.writeln(panel2.innerHTML);
                printWindow.document.write(panelH3.innerHTML);
                printWindow.document.writeln(panel3.innerHTML);
                printWindow.document.write(panelH4.innerHTML);
                printWindow.document.writeln(panel4.innerHTML);
                printWindow.document.write(panelH5.innerHTML);
                printWindow.document.writeln(panel5.innerHTML);
                printWindow.document.write(panelH6.innerHTML);
                printWindow.document.writeln(panel6.innerHTML);
                printWindow.document.write(panelH7.innerHTML);
                printWindow.document.writeln(panel7.innerHTML);
                //printWindow.document.writeln(panel8.innerHTML);
               // printWindow.document.writeln(panel9.innerHTML);
               // printWindow.document.writeln(panel10.innerHTML);
                //printWindow.document.writeln(panel11.innerHTML);
                
                printWindow.document.write('</body></html>');
                printWindow.document.close();
                setTimeout(function () {
                    printWindow.print();
                }, 1000);
                return false;               
            }

        </script>
</asp:Content>

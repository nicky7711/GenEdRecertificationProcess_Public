<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminRubricQuestionnaire.aspx.cs" Inherits="CIS4396Solution.AdminRubricQuestionnaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div class="card">
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2 text-center">
                        <div class="page-header">
                            <h1>Administrative Questionnaire</h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 text-center">
                        <div class="page-heading">
                            <h2>Instructions</h2>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <p>
                            Please answer each of the questions below to the best of your ability. Your answers can be saved and this page returned
                            to at a later date by clicking the "Save Progress" button near the top of the page. After everything has been answered,
                            please select whether you feel the Course should Pass, Fail, or be put on Probation in the final area along with an 
                            explanation for that choice. Ensure all questions have been answered before submitting your Questionnaire.
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2 text-center">
                        <div class="page-header">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 text-center">
                        <div class="page-heading">
                            <h2>Questions</h2>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <div class="pull-right">
                            <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="btnSave" Text="Save progress" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <div class="panel-group" id="accordion">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Section 1: Review of Syllabi for Fidelity and Consistency</a>
                                    </h4>
                                </div>
                                <div id="collapse1" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <fieldset>
                                                <legend>Course Information</legend>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>Fidelity to original proposal for Syllabi included in this Portfolio</h4>
                                                    <div style="margin-left: 5%">
                                                        <asp:RadioButtonList CssClass="radio" ID="radioFidelity1" runat="server" required="true">
                                                            <asp:ListItem Value="High">Yes, there was a high level of fidelity to the original proposal</asp:ListItem>
                                                            <asp:ListItem Value="Acceptable">There was an acceptable level of fidelity to the original proposal</asp:ListItem>
                                                            <asp:ListItem Value="Great">There was a great deal of variance from the original proposal</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>If you indicated that there was a great deal of variance from the original proposal, please outline where there was variance that is potentially problematic</h4>
                                                    <asp:CheckBoxList CssClass="checkbox" ID="chkVariance" runat="server">
                                                        <asp:ListItem Value="Readings">Readings have significantly changed</asp:ListItem>
                                                        <asp:ListItem Value="Size">Course size has significantly changed</asp:ListItem>
                                                        <asp:ListItem Value="Assignments">Assignments have significantly changed</asp:ListItem>
                                                        <asp:ListItem Value="Description">Course description has significantly changed</asp:ListItem>
                                                        <asp:ListItem Value="Outcomes">Stated learning outcomes have significantly changed</asp:ListItem>
                                                        <asp:ListItem Value="Other">Other:</asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </div>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>Please elaborate on why you find the discrepancies to be potentially problematic</h4>
                                                    <asp:TextBox CssClass="form-control" ID="txtDiscrepancy" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                    <br />
                                                    <h4>If other departments or colleges submitted Portfolios for this course, was there consistency between Syllabi included in various Portfolios??</h4>
                                                    <asp:RadioButtonList CssClass="radio" ID="radioPortfolios" runat="server">
                                                        <asp:ListItem Value="High">There was a high level of consistency between sections in different departments</asp:ListItem>
                                                        <asp:ListItem Value="Consistent">Sections were mostly consistent between different departments</asp:ListItem>
                                                        <asp:ListItem Value="Inconsistent">Sections were mostly inconsistent between different departments</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <div class="row">
                                            <fieldset>
                                                <legend>Department Information</legend>
                                                <div class="col-md-4" style="text-align: left">
                                                    <div style="margin-left: 5%">
                                                        <h4>Was there consistency between sections within the department(s)?</h4>
                                                        <asp:RadioButtonList CssClass="radio" ID="radioConsistency1" runat="server">
                                                            <asp:ListItem Value="High">There was a high level of consistency between sections</asp:ListItem>
                                                            <asp:ListItem Value="Consistent">Sections were mostly consistent</asp:ListItem>
                                                            <asp:ListItem Value="Inconsistent">Sections were mostly inconsistent</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>If you indicated that there was a great deal of inconsistency between sections, please outline where there was inconsistency that is potentially problematic</h4>
                                                    <asp:CheckBoxList CssClass="checkbox" ID="chkInconsistency" runat="server">
                                                        <asp:ListItem Value="Readings">Readings varied greatly between sections</asp:ListItem>
                                                        <asp:ListItem Value="Size">Course size varied greatly between sections</asp:ListItem>
                                                        <asp:ListItem Value="Assignments">Assignments varied greatly between sections</asp:ListItem>
                                                        <asp:ListItem Value="Descriptions">Course descriptions vary significantly between sections.</asp:ListItem>
                                                        <asp:ListItem Value="Outcomes">Stated learning outcomes varied greatly between sections</asp:ListItem>
                                                        <asp:ListItem Value="Other">Other:</asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </div>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>Please elaborate on why you find the discrepancies to be potentially problematic</h4>
                                                    <asp:TextBox CssClass="form-control" ID="txtProblematic" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                    <br />
                                                    <h4>If you selected mostly inconsistent, please outline where you saw inconsistencies</h4>
                                                    <asp:TextBox CssClass="form-control" ID="txtOutline" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Section 2: Narrative</a>
                                    </h4>
                                </div>
                                <div id="collapse2" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <fieldset>
                                                <legend>Fidelity Information</legend>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>The narrative recognizes and acknowledges issues with FIDELITY to the original proposal within the department(s) included in the Portfolio</h4>
                                                    <div style="margin-left: 5%">
                                                        <asp:RadioButtonList CssClass="radio" ID="radioFidelity2" runat="server">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                            <asp:ListItem Value="High">There was a high level of FIDELITY to the original proposal</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>If yes, does the narrative propose a plan for achieving greater FIDELITY?</h4>
                                                    <asp:RadioButtonList CssClass="radio" ID="radioFidelity3" runat="server">
                                                        <asp:ListItem Value="Feasbile">Yes, and the plan is feasible</asp:ListItem>
                                                        <asp:ListItem Value="NotFeasible">Yes, but the plan is not feasible</asp:ListItem>
                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>If you found the plan for improving fidelity to the original proposal is not feasible, please explain why</h4>
                                                    <asp:TextBox CssClass="form-control" ID="txtFidelity" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <div class="row">
                                            <fieldset>
                                                <legend>Consistency</legend>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>The narrative recognizes and acknowledges issues with CONSISTENCY between sections within the department(s) included in the Portfolio</h4>
                                                    <div style="margin-left: 5%" style="text-align: left">
                                                        <asp:RadioButtonList CssClass="radio" ID="radioConsistency2" runat="server">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                            <asp:ListItem Value="High">There was a high level of fidelity to the original proposal</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>If yes, does the narrative outline a plan for improving CONSISTENCY?</h4>
                                                    <asp:RadioButtonList CssClass="radio" ID="radioConsistency3" runat="server">
                                                        <asp:ListItem Value="Feasible">Yes, and the plan is feasible</asp:ListItem>
                                                        <asp:ListItem Value="NotFeasible">Yes, but the plan is not feasible</asp:ListItem>
                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-md-4" style="text-align: left">
                                                    <h4>If you indicated that the plan for improving CONSISTENCY is not feasible, please explain why</h4>
                                                    <asp:TextBox CssClass="form-control" ID="txtConsistency" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">Section 3: Program and Area Learning Goals</a>
                                    </h4>
                                </div>
                                <div id="collapse3" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <fieldset>
                                                <legend>Program Learning Goals</legend>
                                                <div class="col-md-8">
                                                    <h4>Did the sections under review meet the following required program learning goals, as evidenced by the syllabi, assignments and student work?</h4>
                                                    <table class="table table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th></th>
                                                                <th>Yes</th>
                                                                <th>No</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>Critical Thinking (where critical thinking is defined as: The ability to think critically, recognize an object of investigation, 
                                                    frame questions about it, and interrogate assumptions—explicit or implicit. Critical thinking includes the evaluation of evidence, 
                                                    analysis and synthesis of multiple sources, and reflection on varied perspectives. Critical thinking generates a well-developed investigation
                                                    that incorporates supporting and countering claims. A student engaged in critical thinking produces an informed account, a hypothesis for 
                                                    further study, or the solution to a problem.)</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes1" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo1" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Communication Skills (where communications is defined as: The ability to effectively use spoken and written language to construct a message
                                                    that demonstrates the communicator has established clear goals and has considered her or his audience. Effective messages are organized and
                                                    presented in a style appropriate to the context.)</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes2" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo2" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Information Literacy (where information literacy is defined as: A spectrum of abilities, including the ability to recognize and articulate
                                                    information needs; to locate, critically evaluate, and organize information for a specific purpose; and to recognize and reflect on the
                                                    ethical use of information.)</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes3" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo3" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="col-md-4">
                                                    <table>
                                                        <thead>
                                                            <tr>
                                                                <td>
                                                                    <h4>Please outline your reasoning for answering "no" for each learning goal</h4>
                                                                </td>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control" ID="txtAnswerNo1" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <div class="row">
                                            <fieldset>
                                                <legend>Area Learning Goals</legend>
                                                <div class="col-md-8">
                                                    <h4>Did the sections under review meet the following area learning goals, as evidenced by the syllabi, assignments and sampled student work?</h4>
                                                    <table class="table table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th></th>
                                                                <th>Yes</th>
                                                                <th>No</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td><asp:Label ID="lblQuestion1" runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes4" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo4" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td><asp:Label ID="lblQuestion2" runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes5" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo5" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td><asp:Label ID="lblQuestion3" runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes6" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo6" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td><asp:Label ID="lblQuestion4" runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes7" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo7" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td><asp:Label ID="lblQuestion5" runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes8" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo8" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="col-md-4">
                                                    <table>
                                                        <thead>
                                                            <tr>
                                                                <td>
                                                                    <h4>Please outline your reasons for answering "no" for each learning goal</h4>
                                                                </td>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control" ID="txtAnswerNo2" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <div class="row">
                                            <fieldset>
                                                <legend>Additional Program Learning Goals</legend>
                                                <div class="col-md-8">
                                                    <h4>Did the sections meet the following additional program learning goals, as evidenced by the syllabi, assignments and sampled student work?</h4>
                                                    <table class="table table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th></th>
                                                                <th>Yes</th>
                                                                <th>No</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>Contextualized Learning (Within GenEd, students who contextualize learning understand and integrate historical, contemporary, and cultural
                                                phenomena and their underlying principles in two broad applications. First, contextual learners recognize the interaction of complex forces
                                                that give rise to specific phenomena. Second, contextual learners understand and analyze related events, artifacts, practices and concepts
                                                across geographic, chronological and cultural boundaries.)</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes9" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo9" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Interdisciplinary Thinking (Within GenEd, students who use interdisciplinary thinking recognize the world presents problems, topics, or issues
                                 too complex to be satisfactorily addressed though a single lens. Thus, interdisciplinary thinkers apply multiple perspectives, paradigms, and
                                 frameworks to problems, topics, or issue.)</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes10" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo10" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Scientific and Quantitative Reasoning (Within GenEd, students who exercise quantitative and scientific reasoning use and apply these reasoning
                                 processes to explain phenomena in the context of everyday life. Quantitative reasoning includes statistical and/or logical problem-solving,
                                 the relationships between quantities, and the use and misuse of quantitative data. Scientific reasoning introduces students to the evolution
                                 and interdependence of science and technology and includes problem identification, hypothesis evaluation, experimentation, interpretation of
                                 results and the use and misuse of scientific data.)</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes11" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo11" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Civic Engagement (Within GenEd, students open to civic engagement view themselves as connected to local and global communities where they participate
                                 in activities that address issues of public concern. Critically engaged students define issues, pose, probe, and solve problems with an awareness of
                                 and an inclusion of the diverse values and interests.)</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes12" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo12" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Lifelong Learning (GenEd cultivates these skills and abilities throughout the required undergraduate curriculum, and students will experience these ways
                                 of being though readings, discussions, activities, and classes throughout GenEd.)</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkYes13" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkNo13" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="col-md-4">
                                                    <table>
                                                        <thead>
                                                            <tr>
                                                                <td>
                                                                    <h4>Please provide any comments you feel may be helpful.</h4>
                                                                </td>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control" ID="txtComments" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">Section 4: Final Recommendation</a>
                                    </h4>
                                </div>
                                <div id="collapse4" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <fieldset>
                                                <legend>Recommended Action</legend>
                                                <div class="col-md-12" style="text-align: left">
                                                    <asp:RadioButtonList ID="radioRecommendation" runat="server">
                                                        <asp:ListItem Value="Pass"> Pass: The course portfolio is approved with no changes required</asp:ListItem>
                                                        <asp:ListItem Value="Probation">Probation: Changes in the course, assignment design and/or attention to course coherency required. 
                                                  Two deadlines will be provided to course developers. The first deadline requires a plan of redress and the
                                                  second deadline requires submission of materials for committee’s review and vote</asp:ListItem>
                                                        <asp:ListItem Value="No Pass"> No pass: Course shows significant deficiencies and should be removed from the inventory.</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-md-12" style="text-align: left">
                                                    <h5>Please provide any final comments or feedback not included in the above sections. Comments may include
                                        highlighting assignments you felt were exceptional, any indications that there may be issues with quality
                                        of instruction, significant gaps in the portfolio or narrative which impeded your evaluation, or a lack of
                                        professionalism in the syllabi under review.</h5>
                                                    <br />
                                                    <asp:TextBox CssClass="form-control" ID="txtFinalComments" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 col-md-8 col-md-offset-2">
                        <div class="pull-right">
                          <%--  <asp:Button CssClass="btn btn-danger btnCancel" runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" />--%>
                            <asp:Button CssClass="btn btn-lg btn-primary" runat="server" ID="btnSubmit" Width="100%" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



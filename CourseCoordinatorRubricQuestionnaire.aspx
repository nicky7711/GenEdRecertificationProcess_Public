<%@ Page Title="" Language="C#" MasterPageFile="~/CourseCoordinator.Master" AutoEventWireup="true" CodeBehind="CourseCoordinatorRubricQuestionnaire.aspx.cs" Inherits="CIS4396Solution.CourseCoordinatorRubricQuestionnaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div class="card">
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2 text-center">
                        <div class="page-header">
                            <h1>Questionnaire:
                                <asp:Label ID="lblCourse" runat="server"></asp:Label>
                            </h1>
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
                        <p style="text-align: justify;">
                            Please answer each of the questions below to the best of your ability. This information is necessary to determine individuals who are key in
                            completing the General Education Recertification process. Your answers can be saved and this page returned to at a later date by clicking the
                             "Save Progress" button near the top of the page. Please check that all files you wish to submit have been uploaded. Ensure all questions have
                             been answered before submitting.
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="page-header"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <div id="myCarousel" data-interval="false" class="carousel" style="height: 350px;">
                            <!-- Wrapper for slides -->
                            <div class="carousel-inner" role="listbox">
                                <div class="item active" style="text-align: left;">
                                    <div class="carouselItem">
                                        <h4 class="page-heading">1. Please list the faculty who taught this course, and indicate whether they are T/TT, NTT, adjunct faculty or a TA.</h4>
                                        <asp:TextBox ID="txtFaculty" CssClass="form-control carousel-textbox" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                        <br />
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-info progress-bar-striped" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 25%">
                                                <span class="sr-only">25% Complete</span>
                                            </div>
                                        </div>
                                        <div style="text-align: center;">
                                            <button type="button" id="myBtn1" class="btn btn-success">Next</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="item" style="text-align: left;">
                                    <div class="carouselItem">
                                        <h4 class="page-heading">2. If syllabi from fewer than two thirds of faculty who have taught the course are represented in this portfolio, please explain why.</h4>
                                        <asp:TextBox ID="txtFewer" CssClass="form-control carousel-textbox" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                        <br />
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-info progress-bar-striped" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 50%">
                                                <span class="sr-only">50% Complete</span>
                                            </div>
                                        </div>
                                        <div style="text-align: center;">
                                            <button type="button" id="myBtn2" class="btn btn-danger">Back</button>
                                            <button type="button" id="myBtn3" class="btn btn-success">Next</button>
                                        </div>
                                    </div>
                                </div>

                                <div class="item" style="text-align: left;">
                                    <div class="carouselItem">
                                        <h4 class="page-heading">3. Please list the sections that were assigned a teaching assistant or grading assistant and the number of assistants assigned.</h4>
                                        <asp:TextBox ID="txtTA" CssClass="form-control carousel-textbox" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                        <br />
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-info progress-bar-striped" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 75%">
                                                <span class="sr-only">75% Complete</span>
                                            </div>
                                        </div>
                                        <div style="text-align: center;">
                                            <button type="button" id="myBtn4" class="btn btn-danger">Back</button>
                                            <button type="button" id="myBtn5" class="btn btn-success">Next</button>
                                        </div>

                                    </div>
                                </div>

                                <div class="item" style="text-align: left;">
                                    <div class="carouselItem">
                                        <h4 class="page-heading">4. Please let us know individuals who took part in coordinating & compiling this portfolio as we would like to work with them again.</h4>
                                        <asp:TextBox ID="txtIndividual" CssClass="form-control carousel-textbox" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                        <br />
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-info progress-bar-striped" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                                                <span class="sr-only">100% Complete</span>
                                            </div>
                                        </div>
                                        <div style="text-align: center;">
                                            <button type="button" id="myBtn6" class="btn btn-danger">Back</button>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <div class="pull-right">
                            <asp:Button CssClass="btn btn-success" ID="btnSave" runat="server" Text="Save Progress" OnClick="btnSave_Click" />
                            <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="page-header"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 text-center">
                        <div class="page-heading">
                            <h2>Uploaded Files</h2>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <asp:GridView ID="gvFiles" runat="server" AllowSorting="true" OnSorting="gvFiles_Sorting" AllowPaging="true" OnPageIndexChanging="gvFiles_PageIndexChanging" PageSize="10"
                            AutoGenerateColumns="False" GridLines="None" CssClass="table table-responsive table-hover" BackColor="White">
                            <Columns>
                                <asp:BoundField DataField="FileId" Visible="false" />
                                <asp:BoundField DataField="FileNm" HeaderStyle-BackColor="#e6e6e6" SortExpression="FileNm" HeaderStyle-ForeColor="Black" HeaderText="File Name" HeaderStyle-CssClass="text-center" ItemStyle-Width="35%"></asp:BoundField>
                                <asp:BoundField DataField="ItemType" HeaderStyle-BackColor="#e6e6e6" SortExpression="ItemType" HeaderStyle-ForeColor="Black" HeaderText="Item Type" HeaderStyle-CssClass="text-center" ItemStyle-Width="35%"></asp:BoundField>
                                <asp:BoundField DataField="CreateDt" HeaderStyle-BackColor="#e6e6e6" SortExpression="CreateDt" HeaderStyle-ForeColor="Black" HeaderText="Submitted" HeaderStyle-CssClass="text-center" ItemStyle-Wrap="true" ItemStyle-Width="30%">
                                    <ItemStyle Wrap="True" Width="15%"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle VerticalAlign="Bottom" CssClass="GridPager" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#202723" />
                            <HeaderStyle BackColor="#202723" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

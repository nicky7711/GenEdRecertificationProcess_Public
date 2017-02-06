<%@ Page Title="" Language="C#" MasterPageFile="~/CourseCoordinator.Master" AutoEventWireup="true" CodeBehind="CourseCoordinatorHome.aspx.cs" Inherits="CIS4396Solution.CourseCoordinatorHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function openDeadlineModal() {
            $('#Deadline').modal('show');
        }
    </script>
    <style type="text/css">
        .hidden {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div class="card">
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2 text-center">
                        <div class="page-header">
                            <h1>Course Re-certification:
                                <asp:Label ID="lblCourse" runat="server"></asp:Label>
                            </h1>
                            <h2>
                                <asp:Label ID="lblDeadline" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
                            </h2>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" href="#collapse1">Instructions</a>
                                    </h4>
                                </div>
                                <div id="collapse1" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row" style="text-align: center">
                                            <div class="col-xs-8 col-xs-offset-2 col-lg-4 col-lg-offset-4">
                                                <label class="control-label">Select A Portfolio To View</label>
                                                <asp:DropDownList ID="ddlPortfolios" CssClass="form-control" Width="100%" runat="server" OnSelectedIndexChanged="ddlPortfolios_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
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
                                                    Please convert all files to <b>.pdf</b> before submission. When you are ready to upload a file simply select the type (Narrative, Syllabus, Prompt, or Example of Work) then select the 
                            file you want to upload. Click the blue <b>"Upload"</b> button to submit the file, or the orange <b>"Cancel"</b> button to cancel.
                            There is no minimum or maximum amount of files needed, as long as there is enough information present to accurately convey the current status of the course. Once you are satisfied
                             that all necessary files are present please proceed by clicking the <b>Final Review</b> button located at the bottom of the page. On the subsequent page you will be asked for basic
                             information about the course and files uploaded for it. 
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Button CssClass="btn btn-success" runat="server" ID="btnSwitchType" Text="Switch To Reviewer" Visible="false" OnClick="btnSwitchType_Click" />
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
                            <h2>Upload</h2>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="form-horizontal">
                            <div class="col-xs-12 col-md-5">
                                <h4 class="page-heading">Select File</h4>
                                <asp:FileUpload CssClass="form-control" ID="uploadMaterials" runat="server" />
                                <asp:Label ID="lblDisplay" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="col-xs-12 col-md-5">
                                <h4 class="page-heading">Item Type</h4>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlChooseItem">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-12 col-md-2" style="padding-top: 40px;">
                                <asp:LinkButton ID="btnUpload" Text="Upload" Enabled="true" CssClass="btn btn-primary" runat="server" Width="100px" OnClick="btnUpload_Click"></asp:LinkButton>
                            </div>
                            <%--<div class="col-xs-12 col-md-2">  
                                <asp:LinkButton ID="btnCancel" Text="Cancel" CssClass="btn btn-warning" runat="server" Width="100px" OnClick="btnCancel_Click"></asp:LinkButton>
                            </div>--%>
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
                            <h2>Files</h2>
                            <br />
                            <asp:Label ID="lblFiles" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="False" GridLines="None" AllowSorting="true" OnSorting="gvFiles_Sorting" AllowPaging="true" PageSize="10"
                            OnPageIndexChanging="gvFiles_PageIndexChanging" CssClass="table table-responsive table-hover" BackColor="White" OnRowCommand="gvFiles_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="FileId" Visible="false" />
                                <asp:BoundField DataField="FileNm" HeaderText="File Name" SortExpression="FileNm" HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#e6e6e6" ItemStyle-Width="30%"></asp:BoundField>
                                <asp:BoundField DataField="ItemType" HeaderText="Item Type" SortExpression="ItemType" HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#e6e6e6" ItemStyle-Width="35%"></asp:BoundField>
                                <asp:BoundField DataField="CreateDt" HeaderText="Submitted" SortExpression="CreateDt" HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#e6e6e6" ItemStyle-Wrap="true" ItemStyle-Width="15%"></asp:BoundField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" HeaderStyle-ForeColor="Black" HeaderText="Delete" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-CssClass="text-center" ControlStyle-ForeColor="White" Text="Delete" CommandName="RemoveFile" ItemStyle-HorizontalAlign="Center">
                                    <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>
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
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div class="pull-right">
                            <asp:Button CssClass="btn btn-success" runat="server" ID="btnFinalReview" Text="Final Review" OnClick="btnFinalReview_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for add -->
    <div class="modal fade" id="Deadline" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #a41e35; color: white;">
                    <button type="button" class="close" style="color: white; opacity: 1;" data-dismiss="modal">&times;</button>
                    <br />
                    <h2 class="modal-title" style="color: red">Submission Deadline Has Passed.</h2>
                    <br />
                    <h4>Contact GenEd Department for additional help.</h4>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

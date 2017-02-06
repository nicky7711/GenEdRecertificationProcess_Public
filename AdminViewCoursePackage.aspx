<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminViewCoursePackage.aspx.cs" Inherits="CIS4396Solution.AdminViewCoursePackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function openCommentModal() {
            $('#commentModal').modal('show');
        }
    </script>
    <script>
        function openEditModal() {
            $('#editModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div class="card">
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2 text-center">
                        <div class="page-header">
                            <h1>Submitted Course Portfolios</h1>
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
                            This page shows all of the Portfolios which exist for a specific Course Package. Click the "Comments" button to show the responses by the Coordinator who was responsible for the Portfolio.
                            Select "ViewPortfolio" in order to show the files contained within the Portfolio. These will appear in a table below the current Portfolios. In order to fill out the Review for for this 
                            Portfolio please select "Review". If you need to edit a Portfolio simply click the "Edit" button.
                        </p>
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
                            <h2>Course Re-certification for
                                <asp:Label ID="lblCourse" runat="server"></asp:Label>
                            </h2>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <asp:GridView ID="gvPortfolios" CssClass="table table-hover table-responsive" AllowSorting="true" OnSorting="gvPortfolios_Sorting" runat="server"
                            OnRowCommand="gvPortfolios_RowCommand" AutoGenerateColumns="False" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="PortfolioId" Visible="false" />
                                <asp:BoundField DataField="AreaCd" HeaderText="Area" SortExpression="AreaCd" HeaderStyle-CssClass="text-center" ItemStyle-Wrap="true" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField DataField="CourseStatus" HeaderText="Status" SortExpression="CourseStatus" HeaderStyle-CssClass="text-center" ItemStyle-Wrap="true" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField DataField="dFullNm" HeaderText="Contact" SortExpression="dFullNm" HeaderStyle-CssClass="text-center" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField DataField="DeptNm" HeaderText="Department" SortExpression="DeptNm" HeaderStyle-CssClass="text-center" ItemStyle-Wrap="true" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField DataField="SubmitDt" HeaderText="Submitted" SortExpression="SubmitDt" ItemStyle-Wrap="true" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-info" HeaderText="Comments" HeaderStyle-CssClass="text-center"
                                    Text="Comments" CommandName="Comments" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" HeaderText="View Files" HeaderStyle-CssClass="text-center"
                                    Text="View" CommandName="ViewPortfolio" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success" HeaderText="Review" HeaderStyle-CssClass="text-center"
                                    Text="Review" CommandName="ReviewPortfolio" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" HeaderText="Questionnaire" HeaderStyle-CssClass="text-center"
                                    Text="Questionnaire" CommandName="ViewQuestionnaire" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" HeaderText="Edit" HeaderStyle-CssClass="text-center"
                                    Text="Edit" CommandName="EditPackage" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="#e6e6e6" ForeColor="Black" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
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
    <!-- Portfolio Contents -->
    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1" id="divFile1" runat="server" visible="false">
            <div class="card">
                <div style="text-align: center">
                    <div class="row">
                        <div class="col-xs-8 col-xs-offset-2 text-center">
                            <div class="page-heading">
                                <h2>Portfolio Files</h2>
                                <br />
                                <asp:Label ID="lblFiles" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-10 col-xs-offset-1">
                            <asp:GridView ID="gvFiles" runat="server" CssClass="table table-hover table-responsive" AllowSorting="true" OnSorting="gvFiles_Sorting" AllowPaging="true"
                                OnPageIndexChanging="gvFiles_PageIndexChanging" PageSize="10" AutoGenerateColumns="False" OnRowCommand="gvFiles_RowCommand" Visible="False" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="FileId" Visible="false" />
                                    <asp:BoundField DataField="FileNm" HeaderText="File Name" SortExpression="FileNm" HeaderStyle-CssClass="text-center" ItemStyle-Width="20%"></asp:BoundField>
                                    <asp:BoundField DataField="ItemType" HeaderText="Item Type" SortExpression="ItemType" HeaderStyle-CssClass="text-center" ItemStyle-Width="20%"></asp:BoundField>
                                    <asp:BoundField DataField="CreateDt" HeaderText="Submitted" SortExpression="CreateDt" HeaderStyle-CssClass="text-center" ItemStyle-Wrap="true" ItemStyle-Width="30%"></asp:BoundField>
                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" HeaderText="View File" HeaderStyle-CssClass="text-center"
                                        Text="View" CommandName="ViewFile" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                </Columns>
                                <PagerStyle VerticalAlign="Bottom" CssClass="GridPager" HorizontalAlign="Center" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="#e6e6e6" ForeColor="Black" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
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
    </div>
    <!-- Modal -->
    <div class="modal fade" id="commentModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #a41e35; color: white;">
                    <button type="button" class="close" style="color: white; opacity: 1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Comments</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblComments1" CssClass="control-label" Text="Area Code" runat="server"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblComments2" CssClass="control-label" Text="Area Code" runat="server"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblComments3" CssClass="control-label" Text="Area Code" runat="server"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblComments4" CssClass="control-label" Text="Area Code" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for edit -->
    <div class="modal fade" id="editModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #a41e35; color: white;">
                    <button type="button" class="close" style="color: white; opacity: 1;" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Edit existing user</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Label ID="lblCourseCoordinator" CssClass="control-label" Text="Course Coordinator" runat="server"></asp:Label>
                                <asp:DropDownList ID="ddlCoordinator" CssClass="form-control input-lg" required="true" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSave" UseSubmitBehavior="false" CssClass="btn btn-lg btn-success" Text="Save" runat="server" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

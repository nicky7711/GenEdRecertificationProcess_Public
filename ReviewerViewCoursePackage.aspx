<%@ Page Title="" Language="C#" MasterPageFile="~/Reviewer.Master" AutoEventWireup="true" CodeBehind="ReviewerViewCoursePackage.aspx.cs" Inherits="CIS4396Solution.ReviewerViewCoursePackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function openCommentModal() {
            $('#commentModal').modal('show');
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
                            Portfolio please select "Review".
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
                                <asp:BoundField DataField="DeptContactId" HeaderText="Contact" SortExpression="DeptContactId" HeaderStyle-CssClass="text-center" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField DataField="DeptNm" HeaderText="Department" SortExpression="DeptNm" HeaderStyle-CssClass="text-center" ItemStyle-Wrap="true" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField DataField="SubmitDt" HeaderText="Submitted" SortExpression="SubmitDt" ItemStyle-Wrap="true" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-info" HeaderText="Comments" HeaderStyle-CssClass="text-center"
                                    Text="Comments" CommandName="Comments" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" HeaderText="View Files" HeaderStyle-CssClass="text-center"
                                    Text="View" CommandName="ViewPortfolio" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success" HeaderText="Review" HeaderStyle-CssClass="text-center"
                                    Text="Review" CommandName="ReviewPortfolio" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
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
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div id="divFile1" runat="server" visible="false" style="text-align: center">
                <div class="card">
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
                    <%--<div class="row">
                        <div class="col-md-10 col-md-offset-1">
                            <br />
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h2 class="panel-title">
                                        <a data-toggle="collapse" href="#panelFiles">Filter Files</a>
                                    </h2>
                                </div>
                                <div id="panelFiles" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="panel-group">
                                            <div class="col-md-4">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <h2 class="panel-title">File Name
                                                        </h2>
                                                    </div>
                                                    <div class="panel-body">
                                                        <asp:TextBox CssClass="form-control" ID="txtFileName" runat="server" placeholder="Item Name" Width="100%"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <h2 class="panel-title">File Type
                                                        </h2>
                                                    </div>
                                                    <div class="panel-body">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlItemType" runat="server" Width="100%">
                                                            <asp:ListItem Value="">Select One</asp:ListItem>
                                                            <asp:ListItem Value="Syllabi">Syllabi</asp:ListItem>
                                                            <asp:ListItem Value="Narrative">Narrative</asp:ListItem>
                                                            <asp:ListItem Value="Assignment Prompt">Assignment Prompt</asp:ListItem>
                                                            <asp:ListItem Value="Example of Student Work">Example of Student Work</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <h2 class="panel-title">Submit Date
                                                        </h2>
                                                    </div>
                                                    <div class="panel-body">
                                                        <asp:TextBox CssClass="form-control" ID="txtSubmitDate" runat="server" placeholder="Contributor" Width="100%"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Button CssClass="btn btn-danger" runat="server" ID="Button1" Text="Clear" OnClick="btnClear_Click" />
                                    <asp:Button CssClass="btn btn-primary" runat="server" ID="Button2" Text="Filter" OnClick="btnFilter_Click" />
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>--%>
                </div>
        </div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="commentModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" style="text-align: left;">Comments</h4>
                </div>
                <div class="modal-body">
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12" style="text-align: left;">
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
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Reviewer.Master" AutoEventWireup="true" CodeBehind="ReviewerHome.aspx.cs" Inherits="CIS4396Solution.ReviewerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-xs-12 col-md-10 col-md-offset-1">
            <div class="card">
                <div class="row">
                    <div class="col-xs-8 col-xs-offset-2 text-center">
                        <div class="page-header">
                            <h1>Reviewer Dashboard</h1>
                            <asp:Button CssClass="btn btn-success" runat="server" ID="btnSwitchType" Text="Switch To Coordinator" OnClick="btnSwitchType_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1 text-center">
                        <div class="page-heading">
                            <h2>Filter</h2>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <div class="form-horizontal">
                            <div class="col-md-3">
                                <asp:Label ID="lblAcademicYear" Text="Academic Year" runat="server"></asp:Label>
                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlAcademicYear">
                                    <asp:ListItem Value="2015-2016">2016-2017</asp:ListItem>
                                    <asp:ListItem Value="2015-2016">2015-2016</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblCourseTitle" CssClass="page-heading" Text="Course Title" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtTitleSearch" runat="server" placeholder="Course Title"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblCourseNumberTitle" Text="Course Number" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtNumberSearch" runat="server" placeholder="Course Number"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblCourseArea" Text="Course Area" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtCourseArea" runat="server" placeholder="Course Area"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-md-2" style="padding-top:20px;">
                                <asp:Button CssClass="btn btn-primary" runat="server" ID="btnFilter" Text="Filter" Width="100%" OnClick="btnFilter_Click" />
                            </div>
                            <%--<div class="col-xs-12 col-md-2">
                                <asp:Button CssClass="btn btn-danger" runat="server" ID="btnClear" Text="Clear" Width="100%" OnClick="btnClear_Click" />
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
                            <h2>Packages</h2>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-10 col-xs-offset-1">
                        <asp:GridView ID="gvPackages" CssClass="table table-responsive table-hover" AllowSorting="true" OnSorting="gvPackages_Sorting" GridLines="None" BackColor="White"
                            AllowPaging="true" PageSize="10" runat="server" AutoGenerateColumns="False" DataKeyNames="PackageId,CourseId" OnRowCommand="gvPackages_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="PackageId" Visible="false" />
                                <asp:BoundField DataField="CourseId" Visible="false" />
                                <asp:BoundField DataField="CourseTitle" HeaderStyle-BackColor="#e6e6e6" SortExpression="CourseTitle" HeaderStyle-ForeColor="Black" HeaderText="Course Name" ItemStyle-Wrap="true" ItemStyle-Width="30%"></asp:BoundField>
                                <asp:BoundField DataField="CourseNum" HeaderStyle-BackColor="#e6e6e6" SortExpression="CourseNum" HeaderStyle-ForeColor="Black" HeaderText="Course Number" ItemStyle-Wrap="true" ItemStyle-Width="20%"></asp:BoundField>
                                <asp:BoundField DataField="AreaCd" HeaderStyle-BackColor="#e6e6e6" SortExpression="AreaCd" HeaderStyle-ForeColor="Black" HeaderText="Course Area" ItemStyle-Wrap="true" ItemStyle-Width="20%"></asp:BoundField>
                                <asp:BoundField DataField="Deadline" HeaderStyle-BackColor="#e6e6e6" SortExpression="Deadline" HeaderStyle-ForeColor="Black" HeaderText="Due Date" ItemStyle-Width="30%"></asp:BoundField>
                                <asp:ButtonField ButtonType="Link" HeaderStyle-BackColor="#e6e6e6" HeaderStyle-ForeColor="Black" ControlStyle-CssClass="btn btn-info" HeaderText="View" HeaderStyle-CssClass="text-center"
                                    Text="View" CommandName="ViewPackage" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle VerticalAlign="Bottom" CssClass="GridPager" HorizontalAlign="Center" />
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
</asp:Content>

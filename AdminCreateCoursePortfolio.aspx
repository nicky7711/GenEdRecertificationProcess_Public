<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCreateCoursePackage.aspx.cs" Inherits="GenEdRecertification_v2._0.AdminCreateCoursePackage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-8 col-xs-offset-2">
                <div class="page-header">
                    <h1>Create a Course Portfolio</h1>
                </div>
                <div id="msgSubmit" class="h3 text-center hidden"></div>
                <div class="clearfix"></div>
                <asp:GridView ID="gvCoursePortfolios" CssClass="form-control table-responsive" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="PackageId" Visible="false" />
                        <asp:BoundField DataField="CourseId" Visible="false" />
                        <asp:BoundField DataField="CourseTitle" HeaderText="Course Name" ItemStyle-Wrap="true" ItemStyle-Width="25%" />
                        <asp:BoundField DataField="CourseNum" HeaderText="Course Number" ItemStyle-Wrap="true" ItemStyle-Width="15%" />
                        <asp:BoundField DataField="AreaCd" HeaderText="Course Area" ItemStyle-Wrap="true" ItemStyle-Width="15%" />
                        <asp:BoundField DataField="SubjectCd" HeaderText="Subject Code" ItemStyle-Wrap="true" ItemStyle-Width="15%" />
                        <asp:BoundField DataField="DueDt" HeaderText="Due Date" ItemStyle-Width="30%" />
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-warning" HeaderText="" Text="Edit" CommandName="ViewReviews" ItemStyle-HorizontalAlign="Center"/>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderText="" Text="Delete" CommandName="EditPackage" ItemStyle-HorizontalAlign="Center"/>
                    </Columns>
                </asp:GridView>
                <!--
                <div class="form-group">
                    <asp:Label ID="lblAcademicYear" CssClass="control-label" Text="Academic Year" runat="server"></asp:Label>
                    <asp:DropDownList ID="ddlAcademicYear" CssClass="form-control input-lg" autofocus="true" required="true" runat="server">
                        <asp:ListItem Value="">Select the current academic year</asp:ListItem>
                    </asp:DropDownList>
                    <div class="help-block with-errors"></div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCourse" CssClass="control-label" Text="Course" runat="server"></asp:Label>
                    <asp:DropDownList ID="ddlCourses" CssClass="form-control input-lg" required="true" runat="server">
                        <asp:ListItem Value="">Select a course</asp:ListItem>
                    </asp:DropDownList>
                    <div class="help-block with-errors"></div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblSubmissionDeadline" CssClass="control-label" Text="Submission Deadline" runat="server"></asp:Label>
                    <asp:TextBox ID="txtSubmissionDeadline" CssClass="form-control input-lg" TextMode="Date" Placeholder="Select a submission deadline date" required="true" runat="server"></asp:TextBox>
                    <div class="help-block with-errors"></div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-6">
                            <asp:Label ID="lblCourseCoordinator" CssClass="control-label" Text="Course Coordinator" runat="server"></asp:Label>
                            <asp:TextBox ID="txtCourseCoordinator" CssClass="form-control input-lg" Placeholder="Course Coordinator" required="true" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:Label ID="lblCoordinatorEmail" CssClass="control-label" Text="Coordinator Email" runat="server"></asp:Label>
                            <asp:TextBox ID="txtCoordinatorEmaik" CssClass="form-control input-lg" Placeholder="Coordinator Email" required="true" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div> -->
                <asp:Button ID="btnCreateCoursePackage" Text="Create" CssClass="btn btn-success btn-lg" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

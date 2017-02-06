<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminEditPackage.aspx.cs" Inherits="CIS4396Solution.AdminEditPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid">
            <div class="row">
            <div class="jumbotron" id="theJumbotron" style="height: 33%;">
                <h2>Edit Package</h2>
            </div>
                </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-5">
                    <fieldset>
                        <legend>Current Academic Year</legend>
                    <h4>2015-2016</h4>
                    <br />
                    <asp:Label ID="lblSelectCourse" Text="Select a Course*" runat="server"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="form-control" Width="33%" runat="server" ID="DropDownList1">
                        <asp:ListItem>Sacred Space</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblDeadline" Text="Deadline for Submission*" runat="server"></asp:Label>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    <br />
                    <h5>Please select the appropriate Department(s) that will be included in this Package, and enter Contact Information for each.</h5>
                    <h5>Select Submit when complete to start the recertifcation process.</h5>
                    <asp:Button CssClass="btn btn-primary" Width="10%" runat="server" ID="Button4" Text="Submit"/>
                        </fieldset>
                </div>
                <div class="col-md-5">
                    <fieldset id="field1" runat="server" visible="true">
                        <legend>Contact Information</legend>
                        <div>
                            <label>College</label>
                            <label style="margin-left:18%">Department</label>
                        </div>
                        <div>
                                <asp:DropDownList CssClass="form-control txtInline" ID="ddlColleges" runat="server" Width="49%">
                                    <asp:ListItem>Tyler School of Art</asp:ListItem>
                                    <asp:ListItem>Fox School of Business and Management</asp:ListItem>
                                    <asp:ListItem>College of Education</asp:ListItem>
                                    <asp:ListItem>College of Engineering</asp:ListItem>
                                    <asp:ListItem>College of Liberal Arts</asp:ListItem>
                                    <asp:ListItem>School of Media and Communication</asp:ListItem>
                                    <asp:ListItem>College of Public Health</asp:ListItem>
                                    <asp:ListItem>College of Science and Technology</asp:ListItem>
                                    <asp:ListItem>School of Tourism and Hospitality Management</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList CssClass="form-control txtInline" ID="ddlDept" runat="server" Width="49%">
                                    <asp:ListItem Value="">Select Department</asp:ListItem>
                                    <asp:ListItem Value="Art History">Art History</asp:ListItem>
                                    <asp:ListItem Value="Greek and Roman Classics">Greek and Roman Classics</asp:ListItem>
                                    <asp:ListItem Value="Religion">Religion</asp:ListItem>
                                </asp:DropDownList>
                            <br />
                            <br />
                             <asp:Button CssClass="btn btn-primary" Width="15%" runat="server" ID="btnAddContact" Text="Edit Contact" OnClick="btnAddContact_Click" />
                            </div>
                        <br />
                        <br />
                        <fieldset id="fieldContact1" runat="server" visible="false">
                            <legend></legend>
                        <h4>Department: Art History</h4>
                    <div>
                        <label style="margin-left:0%">First Name*</label>
                        <label style="margin-left:5.5%">Last Name*</label>
                        <label style="margin-left:6%">Email*</label>
                        </div>
                        <div>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox4" Width="32%" placeholder="Dana">Dakota</asp:TextBox>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox5" Width="32%" placeholder="Dawson">Lantrip</asp:TextBox>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox6" Width="32%" placeholder="dd@temple.edu">tud12952@temple.edu</asp:TextBox>
                        </div>
                        </fieldset>
                        <br />
                        <br />
                    <fieldset id="fieldContact2" runat="server" visible="false">
                        <legend>Department: Greek and Roman Classics</legend>
                    <div>
                        <label style="margin-left:0%">First Name*</label>
                        <label style="margin-left:5.5%">Last Name*</label>
                        <label style="margin-left:6%">Email*</label>
                        </div>
                        <div>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox1" Width="32%" placeholder="Dana">Kevin</asp:TextBox>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox2" Width="32%" placeholder="Dawson">Mullen</asp:TextBox>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox3" Width="32%" placeholder="dd@temple.edu">kmullen@temple.edu</asp:TextBox>
                        </div>
                        </fieldset>
                        <br />
                        <br />
                    <fieldset id="fieldContact3" runat="server" visible="false">
                        <legend>Department: Religion</legend>
                        <div>
                        <label style="margin-left:0%">First Name*</label>
                        <label style="margin-left:5.5%">Last Name*</label>
                        <label style="margin-left:6%">Email*</label>
                        </div>
                        <div>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox8" Width="32%" placeholder="Dana">Mary</asp:TextBox>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox9" Width="32%" placeholder="Dawson">Patrick</asp:TextBox>
                            <asp:TextBox CssClass="form-control txtInline" runat="server" ID="TextBox10" Width="32%" placeholder="dd@temple.edu">mpatrick@temple.edu</asp:TextBox>
                        </div>
                        </fieldset>
                    </fieldset>
                </div>
                <div class="col-md-1"></div>
            </div>
        </div>
    </asp:Content>
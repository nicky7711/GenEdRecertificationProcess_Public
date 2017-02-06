<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCreateSubject.aspx.cs" Inherits="CIS4396.AdminCreateSubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
           <div class="col-xs-12 col-md-8 col-md-offset-2">
                <div class="page-header">
                    <h1>Create a new Subject</h1>
                </div>
                <div id="msgSubmit" class="h3 text-center hidden"></div>
                <div class="clearfix"></div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Label ID="lblSubjectCode" CssClass="control-label" Text="Subject Code*" runat="server"></asp:Label>
                            <asp:TextBox ID="txtGenEdAreaTitle" CssClass="form-control input-lg" Placeholder="e.g. CHEM" autofocus="true" required="true" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Label ID="lblSubjectName" CssClass="control-label" Text="Subject Name*" runat="server"></asp:Label>
                            <asp:TextBox ID="txtSubjectName" CssClass="form-control input-lg" Placeholder="e.g. Chemistry" required="true" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:Button ID="btnCreateSubject" CssClass="btn btn-lg btn-success" Text="Create" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

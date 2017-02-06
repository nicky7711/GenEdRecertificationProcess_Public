<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CIS4396Solution.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>

    <!-- Favicon -->
    <link rel="icon" href="https://www.temple.edu/sites/all/themes/edu/favicon.ico" />

    <!--Bootstrap Core CSS-->
    <link href="packages/bootstrap.3.3.6/content/Content/bootstrap.min.css" rel="stylesheet" />

    <!--Custom CSS-->
    <link href="packages/bootstrap.3.3.6/content/Content/style.css" rel="stylesheet" />

    <!--Font Awesome-->
    <link href="packages/bootstrap.3.3.6/content/Content/font-awesome.min.css" rel="stylesheet" />

    <!--Scripts-->
    <script src="packages/bootstrap.3.3.6/content/Scripts/jquery-1.9.1.min.js"></script>
    <script src="packages/bootstrap.3.3.6/content/Scripts/bootstrap.js"></script>
</head>
<body class="login">
    <!--Navigation Menu-->
    <nav class="navbar navbar-inverse navbar-fixed-top" id="theNavMenu">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" id="theNavbarBrand" href="#">GenEd Recertification</a>
            </div>
        </div>
    </nav>
    <!--Login Form-->
    <div class="container" style="padding-top: 120px;">
        <div class="row">
            <div class="col-xs-12 col-md-6 col-md-offset-3 centered">
                <div class="card">
                    <form id="Form1" class="form-signin" runat="server">
                        <div class="wrapper">
                            <!-- Temple University Primary Logo -->
                            <div class="primary-logo">
                                <img src="./images/temple_university_logo.jpg" class="img-responsive" />
                            </div>
                            <br />
                            <div class="alert alert-danger fade in" id="loginError" runat="server">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                Invalid username or password, please try again.
                            </div>
                            <div class="alert alert-danger fade in" id="invalidUser" runat="server">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                Inactive user, please contact your system administrator.
                            </div>
                            <br />
                            <div class="login-form">
                                <asp:TextBox ID="txtAccessNetUsername" CssClass="form-control input-text" placeholder="AccessNet Username" require="required" autofocus="autofocus" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtPassword" CssClass="form-control input-password" autocomplete="off" placeholder="Password" required="required" runat="server" TextMode="Password"></asp:TextBox>
                                <a href="https://accounts.temple.edu/selfcare/identification.jsp">Forgot Password?</a>
                            </div>
                            <br />
                            <div class="login-button">
                                <asp:Button ID="btnLogin" CssClass="btn btn-lg btn-success" Text="Login" runat="server" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

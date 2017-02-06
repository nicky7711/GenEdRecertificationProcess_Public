<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="CIS4396Solution.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Error Page</title>

    <!-- Favicon -->
    <link rel="icon" href="https://www.temple.edu/sites/all/themes/edu/favicon.ico" />

    <!--Bootstrap Core CSS-->
    <link href="packages/bootstrap.3.3.6/content/Content/bootstrap.min.css" rel="stylesheet" />

    <!--Font Awesome-->
    <link href="packages/bootstrap.3.3.6/content/Content/font-awesome.min.css" rel="stylesheet" />

    <!--Custom CSS-->
    <link href="packages/bootstrap.3.3.6/content/Content/style.css" rel="stylesheet" />

    <!--Scripts-->
    <script src="packages/bootstrap.3.3.6/content/Scripts/jquery-1.9.1.min.js"></script>
    <script src="packages/bootstrap.3.3.6/content/Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                <h2>An Unexpected Error Occurred</h2>
                <a href="Login.aspx">Please login again to continue</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

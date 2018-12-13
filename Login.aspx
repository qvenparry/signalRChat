<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SignalRChat.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Чат</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
    <link href="Content/font-awesome.css" rel="stylesheet" />
    <link href="Content/icheck-bootstrap.css" rel="stylesheet" />
   <!-- <script src="Scripts/util.js"></script> -->
</head>
<body class="hold-transition login-page">
-
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="login-logo">
                <a href="Login.aspx"><b>Добро пожаловать!</b></a>
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Для входа в чат укажите ваш никнейм</p>
                <div class="form-group has-feedback">
                    <input  maxlength="20" type="text" id="txtUserName" class="form-control" placeholder="Ваше имя" required="required" runat="server" />
                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                </div>
                <div class="row">
                  
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <asp:Button ID="btnSignIn" OnClick="btnSignIn_Click" runat="server" Text="Войти" CssClass="btn btn-success btn-block btn-flat" /><br />

                    </div>

                    <!-- /.col -->
                </div>
           
               
            </div>
            <!-- /.login-box-body -->
        </div>
    </form>
    <script src="plugins/jquery-1.9.1.min"></script>
    <script src="plugins/bootstrap.min.js"></script>
    
</body>
</html>

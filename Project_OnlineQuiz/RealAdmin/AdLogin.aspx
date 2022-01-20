﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdLogin.aspx.cs" Inherits="Project_OnlineQuiz.RealAdmin.AdLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="refresh" content="60">
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Login - Online Quiz</title>
    <!-- Bootstrap core CSS-->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Custom fonts for login-->
    <link href="assets/css/custom.css" rel="stylesheet"/>
</head>

<body class="bg-dark">
    <script >

    </script>
    <div class="container">
        <div class="card card-login mx-auto mt-5">
            <div class="card-header">Login</div>
            <div class="card-body">
                <form runat="server" id="formlogin">
                    <asp:Panel ID="pnl_warning" runat="server" Visible="false">
                    <div class="form-group card-header text-center">
                        <div class="alert-danger">
                        <asp:Label ID="lbl_warning" runat="server" Text="Label" CssClass="col-form-label text-center"></asp:Label>
                        </div>
                    </div>
                    </asp:Panel>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Username</label>
                        <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Enter email" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_emil" runat="server" ErrorMessage="Enter email" ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        
                    </div>
                    <div class="form-group">
                        <div>
                            <div>
                                <label for="exampleInputPassword1">Password</label>
                                <asp:TextBox ID="txt_pass" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                
                            </div>
                            </div>
                    </div>
                   
                     <asp:Button ID="btn_login" runat="server" Text="Log In" CssClass="btn btn-primary btn-block" OnClick="btn_login_Click" />
                    
                    <div class="text-center">
                        <a class="d-block small mt-3" href="forgot.aspx">Forgot Password?</a>
                        
                    </div>
                </form>


            </div>
        </div>
    </div>
</body>

</html>

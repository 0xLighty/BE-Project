<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="Project_OnlineQuiz.forgotPassword" %>


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
        <br /><br />
         <div class="text-center"> 
         <a class="btn btn-lg btn-success" href="/OnlineQuiz/Home.aspx" >
                     <i class="fa fa-home" aria-hidden="true"></i>Home</a>
                <!--<button id="singlebutton" name="singlebutton" class="btn btn-primary">Next Step!</button>-->
            </div>
        <div class="card card-login mx-auto mt-5">
           
            <div class="card-header">Forgot Password</div>
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
                        <label for="exampleInputEmail1">Enrollment Number:</label>
                        <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Enter Enrollment" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_emil" runat="server" ErrorMessage="Enter Enrollment" ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Rd2" runat="server" ErrorMessage="Enter valid enrollment: Must be 12 digits" ValidationExpression="^[0-9]{12}$"  ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                        <!--<asp:RegularExpressionValidator ID="rqrexpre_email" runat="server" ErrorMessage="Enter validate email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>-->
                    </div>
                     <asp:Button ID="btn_forgot" runat="server" Text="Send" CssClass="btn btn-primary btn-block" OnClick="btn_send_Click" />

                </form>
                

            </div>
        </div>
    </div>
</body>

</html>


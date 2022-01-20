<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="Project_OnlineQuiz.RealAdmin.temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <meta charset="utf-8"/>
    <meta http-equiv="refresh" content="60">
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content="VatsJayViks"/>
    <title>Welcome to the VGEC Online Exam System</title>
    
    <link href="assets/css/bootstrap.min.css" rel="stylesheet"/>
    
    <link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    
    <link href="assets/css/custom.css" rel="stylesheet"/>
    
</head><body class="fixed-nav sticky-footer bg-dark" id="page-top">
    <form  runat="server" id="adminsmaster">
    
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" id="mainNav">
        <a class="navbar-brand" style="cursor: text ;color:white" onclick="javascript: window.location = '../Home.aspx';" >Online Quiz</a>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive1">
            <ul class="navbar-nav navbar-sidenav" id="exampleAccordion">
                <li class="nav-item">                    <img src="assets/image/vgec.png" alt="Logo Here" class="img-fluid rounded mx-auto d-block" width="100px" />
                </li>
                </ul>
                </div>
        <div class="collapse navbar-collapse" id="navbarResponsive">

            
            <ul class="navbar-nav ml-auto">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                        <i class="fa fa-user-circle-o" aria-hidden="true"></i>
                        
                        Log-In     
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                    
                    </div>
                </li>
                
                
            </ul>
        </div>
    </nav>

        
         
    <div class="content-wrapper">
        
            <div class="container">
                <!-- Icon Cards-->
                <div class="row">
                   
                    <!-- main content goes here -->
                    <h1 left: 0;
                        line-height: 200px;
                        margin-top: -100px;
                        position: absolute;
                        text-align: center;
                        top: 50%;
                        width: 100%;>
                        <center>
                            Something Went Wrong...!!
                            <a href="../Home.aspx">
                            <i  aria-hidden="true"></i>
                            Click Me
                            </a>
                        </center>
                        
                    </h1>
                    

                </div>
            </div>
        
        <!-- /.container-fluid-->
        <!-- /.content-wrapper-->
        <footer class="sticky-footer">
            <div class="container">
                <div class="text-center">
                    <small><a style="cursor: text ; color:black " onclick="javascript: window.location = 'AdLogin.aspx';"> Copyright @ OnlineQuiz-VGEC 2019</a></small>
                </div>
            </div>
        </footer>
        <!-- Scroll to Top Button-->
        <a class="scroll-to-top rounded" href="#page-top">
            <i class="fa fa-angle-up"></i>
        </a>
        <!-- Bootstrap core JavaScript-->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.bundle.min.js"></script>
        <script src="assets/js/custom.js"></script>
    </div>
       </form>

</body>


</html>

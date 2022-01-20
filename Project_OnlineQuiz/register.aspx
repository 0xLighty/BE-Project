<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Project_OnlineQuiz.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Register - Online exam sytem</title>
    <!-- Bootstrap core CSS-->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Custom styles for this register-->
    <link href="assets/css/custom.css" rel="stylesheet"/>
</head>

<body class="bg-dark">
    <div class="container">
        <div class="card card-register mx-auto mt-5">
            <div class="card-header">Register an Account</div>
            <div class="card-body">
                <form runat="server" id="formregister">
                    <asp:Panel ID="pnl_warning" runat="server" Visible="false">
                    <div class="form-group card-header text-center">
                        <div class="alert-danger">
                        <asp:Label ID="lbl_warning" runat="server" Text="Label" CssClass="col-form-label text-center"></asp:Label>
                        </div>
                    </div>
                    </asp:Panel>
                    
                    <div class="form-group">
                        <div class="form-group">
                            <div class="col-md-6">
                                <label for="exampleInputLastName">Enrollment</label>
                                <asp:TextBox ID="txt_enroll" runat="server" CssClass="form-control" placeholder="Enrollment" BackColor="Silver" ReadOnly="True" ></asp:TextBox>
                       
                                
                      
                            </div>
                        </div>
                        <div class="col-md-6">
                                <label for="exampleInputSemester">Pass Out Year</label>
                                
                                    <asp:DropDownList ID="drp_year" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must select a Year" ControlToValidate="drp_year" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>

                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputName">First name</label>
                                <asp:TextBox ID="txt_fname" runat="server" CssClass="form-control" placeholder="Enter first name" BackColor="Silver" ReadOnly="True"></asp:TextBox>
                               


                                
                            </div>
                            <div class="col-md-6">
                                <label for="exampleInputLastName">Last name</label>
                                <asp:TextBox ID="txt_lname" runat="server" CssClass="form-control" placeholder="Enter last name" BackColor="Silver" ReadOnly="True"></asp:TextBox>
                                
                            </div>
                        </div>
                    </div>

                     <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputSemester">Semester</label>
                                
                                    <asp:DropDownList ID="drp_sem" runat="server" CssClass="form-control" DataTextField="category_name" DataValueField="category_id">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must select a semester" ControlToValidate="drp_sem" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                            <div class="col-md-6">
                                <label for="exampleConfirmPassword">Branch</label>
                               
                                    <asp:DropDownList ID="drp_branch" runat="server" CssClass="form-control" DataTextField="branch" DataValueField="branch">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must select a branch" ControlToValidate="drp_branch" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                       
                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="exampleInputMobile1">Mobile No.</label>
                        <asp:TextBox ID="txt_mobile" runat="server" CssClass="form-control" placeholder="Enter mobile no." ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter mobile number" ControlToValidate="txt_mobile" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid mobile number" ValidationExpression="[0-9]{10}"  ControlToValidate="txt_mobile" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                          </div>

                    <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Enter email" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_emil" runat="server" ErrorMessage="Enter email" ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rqrexpre_email" runat="server" ErrorMessage="Enter validate email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                          </div>
                     
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputPassword1">Password</label>
                                <asp:TextBox ID="txt_pass" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqr_pass" runat="server" ErrorMessage="Enter Password" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ControlToValidate="txt_pass" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"  ControlToValidate="txt_pass" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-6">
                                <label for="exampleConfirmPassword">Confirm password</label>
                                <asp:TextBox ID="txt_repass" runat="server" CssClass="form-control" placeholder="Re-type password" TextMode="Password"></asp:TextBox>
                                <asp:CompareValidator ID="rqrcopm_pass" runat="server" ErrorMessage="Password do not match" ControlToValidate="txt_repass" Display="Dynamic" ForeColor="Red" ControlToCompare="txt_pass" ></asp:CompareValidator>
                                 </div>
                        </div>
                    </div>
                    <asp:Button ID="btn_register" runat="server" Text="Register" CssClass="btn btn-primary btn-block" OnClick="btn_register_Click" />
                    <div class="text-center">
                        
                </form>

            </div>
        </div>
    </div>

</body>

</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/usermaster.Master" AutoEventWireup="true" CodeBehind="SEditPro.aspx.cs" Inherits="Project_OnlineQuiz.SEditPro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="server">
    <div class="col-md-12">
        <div class="card">
            <%--Button For select panel--%>
            <div class="btn-group bg-danger">
                <asp:Button ID="btn_panelProfile" runat="server" Text="Change Profile" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_panelProfile_Click" />
                <asp:Button ID="btn_panelPassword" runat="server" Text="Change Password" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_panelPassword_Click" />
                
            </div>

            <%--profile panel--%>
            <asp:Panel ID="panel_profile" runat="server" ScrollBars="Auto">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive" style="overflow:hidden">
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Pass-out Year</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drp_year" runat="server" CssClass="form-control" DataTextField="passOutYear" DataValueField="passOutYear">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="You must select a year" ControlToValidate="drp_year" ForeColor="red" ></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Enrollment</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_facId" runat="server" CssClass="form-control" BackColor="Silver" ReadOnly="True"></asp:TextBox>
                                </div>
                                
                            </div>
                            </br>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">First Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_fName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid first name" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_fName" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter first name" ControlToValidate="txt_fName" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Last Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_lName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter last name" ControlToValidate="txt_lName" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid last name" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_lName" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Branch</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drp_branch" runat="server" CssClass="form-control" DataTextField="branch" DataValueField="branch">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="You must select a Branch" ControlToValidate="drp_branch" ForeColor="red" ></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Semester</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drp_sem" runat="server" CssClass="form-control" DataTextField="category_name" DataValueField="category_name">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must select a Semester" ControlToValidate="drp_sem" ForeColor="red" ></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Email</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_email" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter email" ControlToValidate="txt_email" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rqrexpre_email" runat="server" ErrorMessage="Enter valid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Mobile</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_mobile" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter mobile number" ControlToValidate="txt_mobile" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter valid mobile number" ValidationExpression="[0-9]{10}"  ControlToValidate="txt_mobile" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="offset-2">
                                <asp:Button ID="btn_edit" runat="server" Text="Update" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_edit_Click" />
                            </div>
                        </div>
                        <asp:Panel ID="panel2" runat="server" Visible="false">
                            
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label2" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>

        <%--password panel--%>
            <asp:Panel ID="panel_password" runat="server" ScrollBars="Auto">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive" style="overflow:hidden">
                            

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">New Password</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_NewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"  ControlToValidate="txt_NewPassword" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter New password" ControlToValidate="txt_NewPassword" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Retype New Password</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_RePassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"  ControlToValidate="txt_RePassword" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Re-Enter New password" ControlToValidate="txt_RePassword" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="offset-2">
                                <asp:Button ID="btn_passEdit" runat="server" Text="Update" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_passEdit_Click" />
                            </div>

                        </div>
                        <asp:Panel ID="panel3" runat="server" Visible="false">
                            
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label1" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>

            
          
        </div>
    </div>
</asp:Content>

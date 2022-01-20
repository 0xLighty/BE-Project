<%@ Page Title="" Language="C#" MasterPageFile="~/RealAdmin/RAdmin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="RIndex.aspx.cs" Inherits="Project_OnlineQuiz.RealAdmin.RIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="col-12">
    <h1>Dashboard</h1>
    <hr />



    </div>
    
    <div class="col-md-12">
        <div class="card">
                <div class="btn-group bg-danger">
                <asp:Button ID="btn_panelfaclist" runat="server" Text="Add Faculty" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_panelFaclist_Click" />
                <asp:Button ID="btn_paneladdsub" runat="server" Text="Add Subject" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_paneladdSubject_Click" />
                <asp:Button ID="btn_paneladdemail" runat="server" Text="Recovery Email" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_paneladdEmail_Click" />
                <asp:Button ID="btn_panelflush" runat="server" Text="New term started?" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_panelflush_Click" />
                <asp:Button ID="btn_panelPassword" runat="server" Text="Change Password" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_panelPassword_Click" />
                <asp:Button ID="btn_addStudents" runat="server" Text="Add Students" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_panelAddStudents_Click" />
                <asp:Button ID="btn_examreport" runat="server" Text="Exam Report" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" OnClick="btn_panelExamReport_Click" />
            </div>
            
            <link rel="stylesheet" href="Scripts/jquery-ui.css">


  

            
              
            
            <%--Exam Report panel--%>
            <asp:Panel ID="panel_examReport" runat="server">
                <div class="card text-center mb-3">
                    <div class="card-body">

                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Select Branch</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="drp_brancha" runat="server"   CssClass="form-control" DataTextField="Branch" DataValueField="Branch" >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="You must select a semester" ControlToValidate="drp_brancha" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Select Semester</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="drp_categoryexam" runat="server" CssClass="form-control" DataTextField="category_name"  DataValueField="category_id" >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="require_drpcategory" runat="server" ErrorMessage="You must select a semester" ControlToValidate="drp_categoryexam" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    


                    <form id="form2">
                      
                        <label class="col-md-2 col-form-label ">Start Date</label>
                     <asp:TextBox ID="T1" runat="server" CssClass="myCal" />
                        <img src="calender.png" />
                    </br><label class="col-md-2 col-form-label ">End Date</label>
                        <asp:TextBox ID="T2" runat="server" CssClass="myCal" />
                        <img src="calender.png" />
                   
                    </br>
                    <asp:Button ID="Button6" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" runat="server" onclick="Button21_Click" Text="Take Report" />
                    <asp:GridView ID="GridView2" runat="server" >
                       
                    </asp:GridView>
                        <asp:GridView ID="GridView3" runat="server" >
                      
                    </asp:GridView>
                    </form>
                        <script type="text/javascript">
                            $(".myCal").datepicker({ dateFormat: 'yy-mm-dd' });
                     </script>
                    

                    <asp:Panel ID="panel11" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="Label8" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
                        </div>
                    </div>
                </asp:Panel>

            <%--Students add panel--%>
            <asp:Panel ID="panel_addStudents" runat="server">
                <div class="card text-center mb-3">
                    <div class="card-body">
                    <form id="form1">
    
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="Button5" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" runat="server" onclick="Button1_Click" Text="Upload" />
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    </form>
                    <a href="/OnlineQuiz/Admin/Handler2.ashx?v=myexcel.xlsx"  target=""_blank"">Sample Download</a>

                    <asp:Panel ID="panel9" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="Label7" runat="server" />
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
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"  ControlToValidate="txt_NewPassword" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter New password" ControlToValidate="txt_NewPassword" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Retype New Password</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_RePassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"  ControlToValidate="txt_RePassword" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Re-Enter New password" ControlToValidate="txt_RePassword" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="offset-2">
                                <asp:Button ID="btn_passEdit" runat="server" Text="Update" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_passEdit_Click" />
                            </div>

                        </div>
                        <asp:Panel ID="panel8" runat="server" Visible="false">
                            
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label6" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>

            <%--Assign Panel --%>
            <asp:Panel ID="panel_Faculty" runat="server" ScrollBars="Auto">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive" style="overflow:hidden">

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">First Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_fName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid first name" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_fName" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter first name" ControlToValidate="txt_fName" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Last Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_lName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter last name" ControlToValidate="txt_lName" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter valid last name" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_lName" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
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
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter valid mobile number" ValidationExpression="[0-9]{10}"  ControlToValidate="txt_mobile" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                </div>
                            </div>
                   <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Password</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_Pass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"  ControlToValidate="txt_Pass" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter New password" ControlToValidate="txt_Pass" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Retype Password</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_RePass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_Pass" ControlToValidate="txt_RePass" ErrorMessage="not match</br>" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"  ControlToValidate="txt_RePass" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Re-Enter New password" ControlToValidate="txt_RePass" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>



                        </div>
                    </div>
                            </div>
                            
                            <br />
                            
                            <br />
                            <div class="offset-2">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" Text="Add" OnClick="Save" />
                            </div>
                        <asp:Panel ID="panel1" runat="server">
                            <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label1" runat="server" />
                                </div>
                            
                            </asp:Panel>
                           <br />
                        
                        </div>
                    </div>
                </div>
            </asp:Panel>


    <%--Email Panel --%>
            <asp:Panel ID="panel4" runat="server" ScrollBars="Auto">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive" style="overflow:hidden">

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Email</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_emailrec" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter email" validationgroup ="recmail" ControlToValidate="txt_emailrec" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Enter valid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ControlToValidate="txt_emailrec" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            
                   <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Password</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_passrec" runat="server"  TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter New password" validationgroup ="recmail" ControlToValidate="txt_passrec" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Retype Password</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_RePassrec" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txt_passrec" ControlToValidate="txt_RePassrec" ErrorMessage="not match</br>" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" validationgroup ="recmail" ErrorMessage="Re-Enter New password" ControlToValidate="txt_RePassrec" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>



                        </div>
                    </div>
                            </div>
                            
                            <br />
                            
                            <br />
                            <div class="offset-2">
                                <asp:Button ID="Button3" runat="server" CssClass="btn" BackColor="#4169E1" validationgroup ="recmail" BorderStyle="None" ForeColor="White" Text="Update" OnClick="Update" />
                            </div>
                        <asp:Panel ID="panel5" runat="server">
                            <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label3" runat="server" />
                                </div>
                            
                            </asp:Panel>
                           <br />
                        
                        </div>
                    </div>
                </div>
            </asp:Panel>

     <%--New Term Panel --%>
            <asp:Panel ID="panel6" runat="server" ScrollBars="Auto">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive" style="overflow:hidden">

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Select Branch</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" DataTextField="branch" DataValueField="branch">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="You must select a subject" ControlToValidate="DropDownList3" ForeColor="red"  InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-md-2 col-form-label ">Select Semester</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drp_sem" runat="server" CssClass="form-control" DataTextField="category_name" DataValueField="category_id">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="You must select a semester" ControlToValidate="drp_sem" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-md-2 col-form-label ">Pass Out Year</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" DataTextField="passOutYear" DataValueField="passOutYear">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="You must select a year" ControlToValidate="DropDownList4" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                             
                    
                                
                            </div>


                            <div class="offset-2">
                                <asp:Button ID="Button7" runat="server" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" Text="Load" OnClick="LoadMe" />
                            </div>

                             <br />
                            <asp:GridView ID="GridView_StudentsList" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="false" AllowPaging="false"  >
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                          <asp:CheckBox ID="checkAll" runat="server"  OnCheckedChanged="checkAll" AutoPostBack="True"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" Checked=false />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="enroll" HeaderText="Enrollment Number" />
                                </Columns>
                            </asp:GridView>
                            <br />

                          
                    

                            <br />
                            <div class="offset-2">
                                <asp:Button ID="Button8" runat="server" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" Text="Promote" OnClick="Savee" />
                                <asp:Button ID="Button9" runat="server" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" Text="Demote" OnClick="Saveed" />
                                
                            </div>

                        </div>
                    </div>
                            </div>
                            
                            <br />
                            
                            <br /><div class="card text-center mb-3">
                    <div class="card-body">
                            <div class="offset-2">
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label5" runat="server" Text ="Click this only when 8th semester's term has been completed and new term has been started!!"/>
                                </div>

                                <asp:Button ID="Button4" runat="server" CssClass="btn" BackColor="#4169E1" validationgroup ="pop" BorderStyle="None" ForeColor="White" Text="Flush 8th sem" OnClick="flush8th" />
                            </div>
                        </div>
                                </div></br>
                        <asp:Panel ID="panel7" runat="server">
                            <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label4" runat="server" />
                                </div>
                            
                            </asp:Panel>
                           <br />
                        
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <asp:Panel ID="panel_subject" runat="server" ScrollBars="Auto">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive" style="overflow:hidden">

                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Select Branch</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-control" DataTextField="branch" DataValueField="branch" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must select a subject" ControlToValidate="DropDownList1" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-md-2 col-form-label ">Select Semester</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" DataTextField="category_name" DataValueField="category_id" AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must select a semester" ControlToValidate="DropDownList2" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            
                            <br />
                            <asp:GridView ID="GridView_SubjectssList" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="false" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="subject_name" HeaderText="Subjects" />       
                                   <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked=false />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Panel ID="panel3" runat="server">
                            <div class="offset-2">
                                <asp:Button ID="Button2" runat="server" CssClass="btn" BackColor="#4169E1" ValidationGroup ="tt" BorderStyle="None" ForeColor="White" Text="Delete" OnClick="Del1" />
                            </div>
                            <div class="row form-group">
                                <label class="col-md-2 col-form-label ">Enter Subject</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^[a-zA-Z\s]+$"  ControlToValidate="TextBox1" Display="Dynamic" ForeColor="Red" ></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter New Subject" ControlToValidate="TextBox1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            
                            <br />
                            <div class="offset-2">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" BackColor="#4169E1" BorderStyle="None" ForeColor="White" Text="Add Subject" OnClick="Save12" />
                            </div>
                            </asp:Panel>
                            <asp:Panel ID="panel2" runat="server">
                            <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label2" runat="server" />
                                </div>
                               </asp:Panel>
                            
                            
                           <br />
                        
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <div class="card-header">
                <asp:Panel ID="panel_index_warning" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_indexwarning" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

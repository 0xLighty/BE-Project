<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="addquestion.aspx.cs" Inherits="Project_OnlineQuiz.Admin.addquestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">

    <script type = "text/javascript" Language="javascript">
        function questionImage_Click() {
            var fUp = document.getElementById("<%=FileUpload1.ClientID %>");
            var myVal1 = document.getElementById("<%=RegularExpressionValidator1.ClientID%>");
            var myVal2 = document.getElementById("<%=RequiredFieldValidator1.ClientID%>");
                document.getElementById('<%=Button12.ClientID%>').value = "Yes";
                fUp.disabled = true;
                ValidatorEnable(myVal1, false);
                ValidatorEnable(myVal2, false);
        }
        function questionImagee_Click() {
            var fUp = document.getElementById("<%=FileUpload1.ClientID %>");
            var myVal1 = document.getElementById("<%=RegularExpressionValidator1.ClientID%>");
            var myVal2 = document.getElementById("<%=RequiredFieldValidator1.ClientID%>");
            document.getElementById('<%=Button12.ClientID%>').value = "No";
            fUp.disabled = false;
            ValidatorEnable(myVal1, true);
            ValidatorEnable(myVal2, true);
        }
        function LinkButtonn1_Click(cl) {
            var fUp, tBox, myVal, myVal1, myVal2;
            if (cl == 1) {
                fUp = document.getElementById("<%=FileUpload2.ClientID %>");
                tBox = document.getElementById("<%=txt_optionone.ClientID%>");
                myVal = document.getElementById("<%=require_op1.ClientID%>"); 
                myVal1 = document.getElementById("<%=RegularExpressionValidator2.ClientID%>");
                myVal2 = document.getElementById("<%=RequiredFieldValidator2.ClientID%>");
            } else if (cl == 2) {
                fUp = document.getElementById("<%=FileUpload3.ClientID %>");
                tBox = document.getElementById("<%=txt_optiontwo.ClientID%>");
                myVal = document.getElementById("<%=require_op2.ClientID%>");
                myVal1 = document.getElementById("<%=RegularExpressionValidator3.ClientID%>");
                myVal2 = document.getElementById("<%=RequiredFieldValidator3.ClientID%>");
            } else if (cl == 3) {
                fUp = document.getElementById("<%=FileUpload4.ClientID %>");
                tBox = document.getElementById("<%=txt_optionthree.ClientID%>");
                myVal = document.getElementById("<%=require_op3.ClientID%>");
                myVal1 = document.getElementById("<%=RegularExpressionValidator4.ClientID%>");
                myVal2 = document.getElementById("<%=RequiredFieldValidator4.ClientID%>");
            } else if (cl == 4) {
                fUp = document.getElementById("<%=FileUpload5.ClientID %>");
                tBox = document.getElementById("<%=txt_optionfour.ClientID%>");
                myVal = document.getElementById("<%=require_op4.ClientID%>");
                myVal1 = document.getElementById("<%=RegularExpressionValidator5.ClientID%>");
                myVal2 = document.getElementById("<%=RequiredFieldValidator5.ClientID%>");
            } else { }
            if (fUp.disabled == true) {
                fUp.disabled = false;
                tBox.disabled = true;
                tBox.value = null;
                ValidatorEnable(myVal, false);
                ValidatorEnable(myVal1, true);
                ValidatorEnable(myVal2, true); 
            }
            else if (fUp.disabled == false) {
                fUp.disabled = true;
                tBox.disabled = false;
                fUp.value = "";

                var who2 = fUp.cloneNode(false);
                who2.onchange = fUp.onchange;
                fUp.parentNode.replaceChild(who2, fUp);
                
                ValidatorEnable(myVal, true);
                ValidatorEnable(myVal1, false);
                ValidatorEnable(myVal2, false);
            }
            else { }
        }
        
    </script>

    <link href="../assets/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="../assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Custom styles for this template-->
    <link href="../assets/css/custom.css" rel="stylesheet">
    <div class="col-md-12">
        <div class="card">
            <%--Button For select add question for exam--%>
            <div class="btn-group bg-danger">
                <asp:Button ID="btn_panelquestion" runat="server" Text="Add Question" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#343A40" />
            </div>
            <div class="card-body">
                <div class="row form-group">
                    <label class="col-md-2 col-form-label ">Question Id</label>
                    <div class="col-md-9">
                        <asp:TextBox ID="txt_questionId" runat="server" CssClass="form-control" BackColor="Silver" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <label class="col-md-2 col-form-label ">Qusetion Name</label>
                    <div class="col-md-9">
                        <asp:TextBox ID="txt_questionname" runat="server" TextMode="MultiLine" CssClass="form-control" Height="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="require_questionname" runat="server" ErrorMessage="Enter exam name" ControlToValidate="txt_questionname" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                
                <div class="row form-group">
                    <label class="col-md-2 col-form-label ">Option A</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txt_optionone" runat="server" CssClass="form-control"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="require_op1" runat="server"  ErrorMessage="Enter option one" ControlToValidate="txt_optionone" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:LinkButton runat="server" ID="LinkButton1" Text='<i class="fa fa-refresh"></i>'  OnClientClick="javascript:LinkButtonn1_Click(1);" />
                    <div class="col-md-2">
                    <asp:FileUpload ID="FileUpload2" runat="server"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ErrorMessage="Please select a valid image file" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$" ControlToValidate="FileUpload2" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="Please upload image" ControlToValidate="FileUpload2" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                    
                </div>
                <div class="row form-group">
                    <label class="col-md-2 col-form-label ">Option B</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txt_optiontwo" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="require_op2" runat="server"  ErrorMessage="Enter option two" ControlToValidate="txt_optiontwo" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:LinkButton runat="server" ID="LinkButton2" Text='<i class="fa fa-refresh"></i>'  OnClientClick="javascript:LinkButtonn1_Click(2);" />
                    <div class="col-md-2">
                    <asp:FileUpload ID="FileUpload3" runat="server"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  ErrorMessage="Please select a valid image file" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$" ControlToValidate="FileUpload3" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="Please upload image" ControlToValidate="FileUpload3" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="row form-group">
                    <label class="col-md-2 col-form-label ">Option C</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txt_optionthree" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="require_op3" runat="server" ErrorMessage="Enter option three" ControlToValidate="txt_optionthree" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:LinkButton runat="server" ID="LinkButton3" Text='<i class="fa fa-refresh"></i>' OnClientClick="javascript:LinkButtonn1_Click(3);" />
                    <div class="col-md-2">
                    <asp:FileUpload ID="FileUpload4" runat="server"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"  ErrorMessage="Please select a valid image file" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$" ControlToValidate="FileUpload4" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ErrorMessage="Please upload image" ControlToValidate="FileUpload4" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                    
                </div>
                <div class="row form-group">
                    <label class="col-md-2 col-form-label ">Option D</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txt_optionfour" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="require_op4" runat="server"  ErrorMessage="Enter option four" ControlToValidate="txt_optionfour" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:LinkButton runat="server" ID="LinkButton4" Text='<i class="fa fa-refresh"></i>'  OnClientClick="javascript:LinkButtonn1_Click(4);" />
                    <div class="col-md-2">
                    <asp:FileUpload ID="FileUpload5" runat="server"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Please select a valid image file" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$" ControlToValidate="FileUpload5" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please upload image" ControlToValidate="FileUpload5" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row form-group">
                <label class="col-md-2 col-form-label text-center">Correct Answer</label>
                    <div class="col-md-4">
                        <asp:RadioButtonList ID="rdo_correctanswer" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CellPadding="10">
                            <asp:ListItem Text="A" Value=1></asp:ListItem>
                            <asp:ListItem Text="B" Value=2></asp:ListItem>
                            <asp:ListItem Text="C" Value=3></asp:ListItem>
                            <asp:ListItem Text="D" Value=4></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="req_rdo_correctanswer" runat="server" ErrorMessage="Select a correct answer" ControlToValidate="rdo_correctanswer" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
            </div>
                <div class="row form-group">
                    <label class="col-md-2 col-form-label ">Image for Question</label>
                    <div class="col-md-9">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"/>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please select a valid image file" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$" ControlToValidate="FileUpload1" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please upload image" ControlToValidate="FileUpload1" ForeColor="red"></asp:RequiredFieldValidator>
                        
                    </div>

                    <div class="row form-group">
                    <label class="col-md-2 col-form-label ">Mark(s)</label>
                        <div class="col-md-5">
                             <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text="1" ></asp:TextBox>
                        
                         </div>
                    </div>

                

                    <div>
                    <asp:Button ID="Button12" runat="server" ValidationGroup="vatsal" Text="No" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_qImg_Click"  />
                        
                        </div>
                </div>
                <div class="card-footer">
                        <div class="offset-2">
                            <asp:Button ID="btn_addquestion" runat="server" Text="Add Question" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_addquestion_Click"  />
                        </div>
                        <asp:Panel ID="panel_addquestion_warning" runat="server" Visible="false">
                            <br />
                            <div class="alert alert-danger text-center">
                                <asp:Label ID="lbl_addquestionwarning" runat="server" />
                            </div>
                        </asp:Panel>
                    </div>
            </div>          
            
        </div>
    </div>

</asp:Content>

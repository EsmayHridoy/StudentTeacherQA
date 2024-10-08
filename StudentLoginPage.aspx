<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentLoginPage.aspx.cs" Inherits="StudentTeacherQA.UserLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/studentUser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Student login</h3>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    </hr>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Student ID</label>
                                <div class="form-group">
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Enter Your Student ID">
                                    </asp:TextBox>
                                </div>
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Enter Your Password"
                                        TextMode="Password">
                                    </asp:TextBox>
                                </div>
                 
                                <div class="form-group">
                                    <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Login" />
                                </div>
                                <div class="form-group">
                                    <a href="SignUp.aspx">
                                        <input id="Button2" class="btn btn-info btn-block btn-lg" type="button" value="Sign Up" />
                                    </a>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< Back Home</a>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentSignUp.aspx.cs" Inherits="StudentTeacherQA.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/studentUser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Student Registration</h4>
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


                        <%-- Full name & Date of birth --%>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Enter Your Full Name">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Enter Your Date of Birth"
                                        TextMode="Date">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>



                        <%-- Contact Number & Email --%>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Enter Your Contact Number">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email Id</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="name@example.com"
                                        TextMode="Email">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <%-- Department & Batch --%>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Department</label>
                                <div class="form-group">
                                    <asp:DropDownList Class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Department of Civil Engineering" Value="CE" />
                                        <asp:ListItem Text="Department of Urban and Regional Planning" Value="URP" />
                                        <asp:ListItem Text="Department of Architecture" Value="Arch" />
                                        <asp:ListItem Text="Department of Building Engineering and Construction Management" Value="BECM" />
                                        <asp:ListItem Text="Department of Industrial and Production Engineering" Value="IPE" />
                                        <asp:ListItem Text="Department of Mechanical Engineering" Value="ME" />
                                        <asp:ListItem Text="Department of Glass and Ceramic Engineering" Value="GCE" />
                                        <asp:ListItem Text="Department of Mechatronics" Value="MechTro" />
                                        <asp:ListItem Text="Department of Materials Science and Engineering" Value="MSE" />
                                        <asp:ListItem Text="Department of Chemical Engineering" Value="CE" />
                                        <asp:ListItem Text="Department of Electrical and Electronic Engineeringt" Value="EEE" />
                                        <asp:ListItem Text="Department of Computer Science and Engineering" Value="CSE" />
                                        <asp:ListItem Text="Department of Electronic and Telecommunication Engineering" Value="ETE" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Batch</label>
                                <div class="form-group">
                                    <asp:DropDownList Class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Number=2011 Value=2011 />
                                        <asp:ListItem Number=2012 Value=2012 />
                                        <asp:ListItem Number=2013 Value=2013 />
                                        <asp:ListItem Number=2014 Value=2014 />
                                        <asp:ListItem Number=2015 Value=2015 />
                                        <asp:ListItem Number=2016 Value=2016 />
                                        <asp:ListItem Number=2017 Value=2017 />
                                        <asp:ListItem Number=2018 Value=2018 />
                                        <asp:ListItem Number=2019 Value=2019 />
                                        <asp:ListItem Number=2020 Value=2020 />
                                        <asp:ListItem Number=2021 Value=2021 />
                                        <asp:ListItem Number=2022 Value=2022 />
                                        <asp:ListItem Number=2023 Value=2023 />
                                        <asp:ListItem Number=2024 Value=2024 />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        <%-- Credintials --%>
                        <center>
                            <span class="badge badge-pill badge-primary">Enter Your Credintial Carefully</span>
                        </center>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Stuent Id</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Enter Your Student ID"
                                        TextMode="Number">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" 
                                        placeholder="Enter Your Password" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- Sign Up Button --%>
                        <div class="form-group">
                            <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Sign Up" />
                        </div>
                        

                    </div>
                </div>
                <a href="homepage.aspx"><< Back Home</a>
            </div>
        </div>
    </div>
</asp:Content>

using System;
using System.Web.UI;

namespace StudentTeacherQA
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                LinkButton1.Visible = true; // Student Login
                LinkButton2.Visible = true; // Student Sign Up
                LinkButton3.Visible = false; // Logout
                LinkButton4.Visible = false; // View QA
                LinkButton5.Visible = true; // Teacher Login
                LinkButton6.Visible = true; // Teacher Sign Up
                LinkButton7.Visible = false; // Your Profile
            }
            else if (Session["role"].Equals("Student"))
            {
                LinkButton1.Visible = false; // Student Login
                LinkButton2.Visible = false; // Student Sign Up
                LinkButton3.Visible = true; // Logout
                LinkButton4.Visible = true; // View QA
                LinkButton5.Visible = false; // Teacher Login
                LinkButton6.Visible = false; // Teacher Sign Up
                LinkButton7.Visible = true; // Your Profile
                LinkButton7.Text = Session["fullname"].ToString();
            }
            else if (Session["role"].Equals("Teacher"))
            {
                LinkButton1.Visible = false; // Student Login
                LinkButton2.Visible = false; // Student Sign Up
                LinkButton3.Visible = true; // Logout
                LinkButton4.Visible = true; // View QA
                LinkButton5.Visible = false; // Teacher Login
                LinkButton6.Visible = false; // Teacher Sign Up
                LinkButton7.Visible = true; // Your Profile
                LinkButton7.Text = Session["fullname"].ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLoginPage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSignUp.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherLogin.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherSignUp.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = null ;
            Session["fullname"] = null;
            Session["role"] = null;
            LinkButton1.Visible = true; // Student Login
            LinkButton2.Visible = true; // Student Sign Up
            LinkButton3.Visible = false; // Logout
            LinkButton4.Visible = false; // View QA
            LinkButton5.Visible = true; // Teacher Login
            LinkButton6.Visible = true; // Teacher Sign Up
            LinkButton7.Visible = false; // Your Profile

            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ViewQA.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("Student"))
            {
                Response.Redirect("StudentProfile.aspx");
            }
            else if (Session["role"].Equals("Teacher"))
            {
                Response.Redirect("TeacherProfile.aspx");
            }
        }
    }
}

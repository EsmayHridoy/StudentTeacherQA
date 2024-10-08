using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTeacherQA
{
    public partial class TeacherLogin : System.Web.UI.Page
    {
        String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM teacher_table " +
                    " WHERE edu_mail = @edu_mail AND password = @password",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("@edu_mail", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Response.Write("<script>alert('Login successful');</script>");
                        Session["username"] = reader.GetValue(6).ToString();
                        Session["fullname"] = reader.GetValue(0).ToString();
                        Session["role"] = "Teacher";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Wrong Edu mail or Password');</script>");
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception');</script>");
            }
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTeacherQA
{
    public partial class UserLoginPage : System.Web.UI.Page
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
                    "SELECT * FROM student_table " +
                    " WHERE student_id = @student_id and password = @password",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("@student_id", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Response.Write("<script>alert('Login successful');</script>");
                        Session["username"] = reader.GetValue(6).ToString();
                        Session["fullname"] = reader.GetValue(0).ToString();
                        Session["role"] = "Student";
                    }
                    Response.Redirect("homepage.aspx");
                }
                
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception');</script>");
            }
            
        }

    }
}
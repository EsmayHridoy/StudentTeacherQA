using System;
using System.Configuration;
using System.Data.SqlClient;

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
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }

                    string query = @"
                        SELECT name, edu_mail 
                        FROM teacher_table 
                        WHERE edu_mail = @edu_mail AND password = @password";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@edu_mail", TextBox1.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@password", TextBox2.Text.Trim());

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Assuming name and edu_mail are the correct columns
                                string name = reader["name"].ToString(); // Fetching by column name
                                string eduMail = reader["edu_mail"].ToString(); // Fetching by column name

                                Session["edu_mail"] = eduMail;
                                Session["fullname"] = name;
                                Session["role"] = "Teacher";

                                Response.Write("<script>alert('Login successful');</script>");
                            }

                            Response.Redirect("homepage.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Wrong Edu mail or Password');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exception: {ex.Message}');</script>");
            }
        }
    }
}

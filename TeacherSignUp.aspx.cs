using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTeacherQA
{
    public partial class TeacherSignUp : System.Web.UI.Page
    {
        String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Teacher Sign Up Button Click Event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckIfExist())
            {
                Response.Write("<script>alert('Teacher is already exist');</script>");
            }
            else
            {
                SignUpStudent();
            }
        }


        // this function checks whether the teacher already exists or not
        public bool CheckIfExist()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM teacher_table WHERE edu_mail = @edu_mail OR email = @email;", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@edu_mail", TextBox5.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@email", TextBox2.Text.Trim());

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    }
                }

                // If records are found, return true
                if (dataTable.Rows.Count > 0)
                {
                    return true;
                }

                return false; // No matching record found
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Response.Write("<script>alert('Error occurred while checking for existing teacher: " + ex.Message + "');</script>");
                return false;
            }
        }

        // Sign up function
        public void SignUpStudent()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO teacher_table" +
                    "(name, date_of_birth, contact_number, email, department, designation, edu_mail, password)" +
                    "VALUES " +
                    "(@name, @date_of_birth, @contact_number, @email, @department, @designation, @edu_mail, @password);", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@date_of_birth", TextBox4.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@contact_number", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@department", DropDownList1.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@designation", DropDownList2.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@edu_mail", TextBox5.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", TextBox6.Text.Trim());

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                Response.Write("<script>alert('As a teacher sign up is successful. Go to teacher login page.....');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception is thrown');</script>");

            }
        }
    }
}
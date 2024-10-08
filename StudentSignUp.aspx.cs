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
    public partial class SignUp : System.Web.UI.Page
    {
        String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Student Sign Up Button Click Event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckIfExist())
            {
                Response.Write("<script>alert('Student is already exist');</script>");
            }
            else
            {
                SignUpStudent();
            }
        }


        // this function check whether the student is already exits or not
        public bool CheckIfExist()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM student_table WHERE student_id =" +
                " @student_id OR email = @email;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@student_id", TextBox5.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
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
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO student_table (name, date_of_birth, contact_number, email, department, batch, student_id, password) VALUES (@name, @date_of_birth, @contact_number, @email, @department, @batch, @student_id, @password);",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@date_of_birth", TextBox4.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@contact_number", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@department", DropDownList1.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@batch", DropDownList2.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@student_id", TextBox5.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", TextBox6.Text.Trim());

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                Response.Write("<script>alert('As a student sign up is successful. Go to student login page.....');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception is thrown');</script>");

            }
        }
    }
}
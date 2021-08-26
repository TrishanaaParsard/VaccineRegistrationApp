using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaccineRegistrationApp
{
    public partial class Form1 : Form
    {
        //Create Connection string and connection to SQL
        private static string myConString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        SqlConnection con = new SqlConnection(myConString);
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnRegister_Click(object sender, EventArgs e)
        {
           
            //Open connection to database
            con.Open();

            

            //Add string with SQL query
            string InsertQuery = "Insert Into RegTable Values (@ID, @Surname, @FirstName, @Gender, @Province)";

            SqlCommand sqlCommand = new SqlCommand(InsertQuery, con);
            sqlCommand.Parameters.AddWithValue("@ID", tbxID.Text);
            sqlCommand.Parameters.AddWithValue("@Surname", tbxSurname.Text);
            sqlCommand.Parameters.AddWithValue("@FirstName", tbxFirstName.Text);
            sqlCommand.Parameters.AddWithValue("@Gender", cboGender.Text);
            sqlCommand.Parameters.AddWithValue("@Province", CboProvince.Text);
          
            //Executes SQL query
            sqlCommand.ExecuteNonQuery();
            //Message box, informs that the record is created.
            MessageBox.Show("Successfully created a record!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
            con.Close();
            

        }

        private void clear() {
            tbxFirstName.Clear();
            tbxID.Clear();
            tbxSurname.Clear();
            
        }
    }
}

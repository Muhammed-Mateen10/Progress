using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressFrontend
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Add student after fields
        {
            //Insert into student table
            try
            {
                SqlConnection con = new SqlConnection("Server=tcp:sqlsarwar.database.windows.net,1433;Initial Catalog=ProgressDB;Persist Security Info=False;User ID=rooot;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand("Insert into Student (Id, Name,LoginPassword) Values (" + Int32.Parse(this.textBox1.Text) + ",'"  + this.textBox2.Text  + "','"  + this.textBox3.Text  + "');", con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if(i != 0)
                {
                    MessageBox.Show("Student Added Into Database");
                }
                con.Close();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=tcp:sqlsarwar.database.windows.net,1433;Initial Catalog=ProgressDB;Persist Security Info=False;User ID=rooot;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand("Update CourseStudent set Mid1 = " + Int32.Parse(this.textBox2.Text) +  ",Mid2 = " + Int32.Parse(this.textBox3.Text ) + ",A1 = " + Int32.Parse(this.textBox4.Text) + ",A2 = " + Int32.Parse(this.textBox5.Text) + ",A3 = " + Int32.Parse(this.textBox6.Text) + ",A4 = " + Int32.Parse(this.textBox7.Text) + ",Final = " + Int32.Parse(this.textBox8.Text) + " Where StudentId= " + Int32.Parse(this.textBox1.Text) + " And Code = " +Int32.Parse(this.textBox9.Text) +";" ,con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Student Marks Updated");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}

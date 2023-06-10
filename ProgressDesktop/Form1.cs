using Newtonsoft.Json;
using System.Security.AccessControl;
using System.Text;

namespace ProgressFrontend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("gere");
            Form f4 = new Form4();
            f4.ShowDialog();
        }

        private async void button4_Click(object sender, EventArgs e) 
        {
            var client = new HttpClient();

            HttpResponseMessage response = client.GetAsync("https://progress1.azurewebsites.net/api/GetTeachers").Result;
            
            if (response.IsSuccessStatusCode)
            {
             //   Console.WriteLine("here");

                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<Teacher>>(custome‌​rJsonString);
                foreach(Teacher t in deserialized)
                {
                    MessageBox.Show(t.Name, "Teacher Name");
                }
                
                // Do something with it
            }
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blockchain
{
    public partial class Project_Menu : Form
    {
        Httprequest request = new Httprequest();
        public Project_Menu()
        {
            InitializeComponent();
            dynamic r = request.get(@"" + Program.url + "replace_chain");
            this.CenterToScreen();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Project project = new Project();
            project.project_name = textBox1.Text;
            project.address = textBox2.Text;
           
            string response = request.post(@""+Program.url+"add_project", project);
            dynamic r = request.get(@"" + Program.url + "mine_block");
            r = request.get(@"" + Program.url + "replace_chain");
            MessageBox.Show("Project added");

        }
    }
}

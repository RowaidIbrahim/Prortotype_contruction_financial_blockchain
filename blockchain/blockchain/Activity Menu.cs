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
    public partial class Activity_Menu : Form
    {
        Httprequest request = new Httprequest();
        public Activity_Menu()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic r = request.get(@"" + Program.url + "replace_chain");
            dynamic jsonResponse = request.get(@"" + Program.url + "get_projects");
            foreach (dynamic c in jsonResponse.projects)
            {
                comboBox2.Items.Add(c.project_name);
            }
            jsonResponse = request.get(@""+Program.url+"get_contracts");
            foreach (dynamic c in jsonResponse.contracts)
            {
                comboBox1.Items.Add(c.contract_name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Activity act= new Activity();
            act.activity_name = textBox1.Text;
            act.project = comboBox2.Text;
            act.duration = textBox3.Text;
            act.start_date = dateTimePicker1.Value.ToString() ;
            act.finish_date = dateTimePicker2.Value.ToString();
            act.contract_name = comboBox1.Text;
            act.price = textBox4.Text;
            act.status = textBox5.Text;
            act.approved = textBox6.Text;

            string response = request.post(@"" + Program.url + "add_activity", act);
            dynamic r = request.get(@"" + Program.url + "mine_block");
            r = request.get(@"" + Program.url + "replace_chain");
            MessageBox.Show("Activity added");
        }
    }
}

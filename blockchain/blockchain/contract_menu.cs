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
    public partial class contract_menu : Form
    {
        Httprequest request = new Httprequest();
        public contract_menu()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic jsonResponse = request.get(@"" + Program.url + "get_projects");
            foreach (dynamic c in jsonResponse.projects)
            {
                comboBox1.Items.Add(c.project_name);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contract cont = new Contract();
            cont.contract_name = textBox1.Text;
            cont.project = comboBox1.Text;
            cont.amount = float.Parse(textBox3.Text);
            cont.date = dateTimePicker1.Value.ToString();
            cont.type = textBox4.Text;
            cont.parties = textBox5.Text;

            string response = request.post(@"" + Program.url + "add_contract", cont);
            dynamic r = request.get(@"" + Program.url + "mine_block");
            MessageBox.Show("contract added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

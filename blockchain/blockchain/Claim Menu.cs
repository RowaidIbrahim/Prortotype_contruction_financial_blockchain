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
    public partial class Claim_Menu : Form
    {
        Admin_menu admin_menu = new Admin_menu();
        Httprequest request = new Httprequest();
        public Claim_Menu()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic r = request.get(@"" + Program.url + "replace_chain");
            dynamic jsonResponse = request.get(@"" + Program.url + "get_contracts");
            foreach (dynamic c in jsonResponse.contracts)
            {
                comboBox1.Items.Add(c.contract_name);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Claim claim = new Claim();
            if (textBox1.Text != "")
            {
                claim.claim = textBox1.Text;
                claim.username = ""+Program.user;
                claim.contract_name = comboBox1.Text;
                claim.status = "received";
                claim.timestamp = DateTime.Now;
                dynamic response = request.post(@"" + Program.url + "claim", claim);
                dynamic r = request.get(@"" + Program.url + "mine_block");
                r = request.get(@"" + Program.url + "replace_chain");
                MessageBox.Show("Claim has been sent to admins for review.");
            }
            else
                label2.Text = "Claim Required.";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

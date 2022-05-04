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
    public partial class payment : Form
    {

        Httprequest request = new Httprequest();
        List<Activity> plist= new List<Activity>();
        
        string contract_n;
        int count=0;
        int flagc=0;
        public payment()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic jsonResponse = request.get(@"" + Program.url + "get_projects");
            dynamic r = request.get(@"" + Program.url + "replace_chain");
            foreach (dynamic c in jsonResponse.projects)
            {
                comboBox1.Items.Add(c.project_name);

            }
            jsonResponse = request.get(@"" + Program.url + "get_activities");
            foreach (dynamic c in jsonResponse.activities)
            {
                count++;
                Activity ac = new Activity();
                comboBox2.Items.Add(c.activity_name);
                ac.contract_name=c.contract_name;
                ac.activity_name = c.activity_name;
                ac.status = c.status;
                ac.approved = c.approved;
                plist.Add(ac);
                   
            }
           

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Activity f in plist)
                if (f.activity_name == (comboBox2.SelectedItem).ToString())
                {
                    label3.Text = f.approved;
                    contract_n = f.contract_name;
                }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pay p = new pay();
            p.owner_username=Program.user.username;
            p.retention = float.Parse(textBox1.Text);
            p.activity_name=comboBox2.Text;
            p.contract_name = contract_n;
            p.contractor_username = "contractor";

            foreach (Activity f in plist)
            {
                
                if (f.approved == "approved")
                    flagc++;

            }

           

            string response = request.post(@"" + Program.url + "pay", p);
            dynamic r = request.get(@"" + Program.url + "mine_block");
            r = request.get(@"" + Program.url + "replace_chain");

            if (flagc == count)
            {
                string res = request.post(@"" + Program.url + "paycontract", p);
                dynamic ro = request.get(@"" + Program.url + "mine_block");
                ro = request.get(@"" + Program.url + "replace_chain");
            }

            MessageBox.Show("Payment sent");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

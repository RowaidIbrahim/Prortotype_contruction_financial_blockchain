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
    public partial class approval : Form
    {

        Httprequest request = new Httprequest();
        List<Activity> plist = new List<Activity>();

        public void activity_update()
        {
            comboBox3.Items.Clear();
             dynamic jsonResponse = request.get(@"" + Program.url + "get_activities");
            foreach (dynamic c in jsonResponse.activities)
            {
                Activity act = new Activity();
                comboBox3.Items.Add(c.activity_name);
                act.contract_name = c.contract_name;
                act.activity_name = c.activity_name;
                act.approved = c.approved;

                plist.Add(act);

            }
            label4.Text = "";
        }
        public approval()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic r = request.get(@"" + Program.url + "replace_chain");
            dynamic jsonResponse = request.get(@"" + Program.url + "get_projects");
            
            foreach (dynamic c in jsonResponse.projects)
            {
                comboBox1.Items.Add(c.project_name);

            }
            jsonResponse = request.get(@"" + Program.url + "get_contracts");
            foreach (dynamic c in jsonResponse.contracts)
            {
                comboBox2.Items.Add(c.contract_name);

            }
            activity_update();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            approve_ p = new approve_();
          
            
            p.activity_name = comboBox3.Text;
            p.contract_name = comboBox2.Text;


            if (comboBox4.Text == "Approved")
            {
                p.approved = "approved";
                dynamic response = request.post(@"" + Program.url + "approve", p);
                dynamic r = request.get(@"" + Program.url + "mine_block");
                r = request.get(@"" + Program.url + "replace_chain");
                MessageBox.Show("approved");
            }
            else if (comboBox4.Text == "Not approved")
            {
                p.approved = "not approved";
                dynamic response = request.post(@"" + Program.url + "not_approve", p);
                dynamic r = request.get(@"" + Program.url + "mine_block");
                r = request.get(@"" + Program.url + "replace_chain");
                MessageBox.Show("Not approved");
                
            }

            activity_update();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
           

        }

        private void comboBox3_DisplayMemberChanged(object sender, EventArgs e)
        {
            

        }
        
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Activity f in plist)
                if (f.activity_name == (comboBox3.SelectedItem).ToString())
                {
                    label4.Text = f.approved;
                    
                }

        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}

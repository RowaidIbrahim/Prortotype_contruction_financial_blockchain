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
    public partial class status_update : Form
    {
        Httprequest request = new Httprequest();
        List<Activity> plist = new List<Activity>();
        Activity act = new Activity();
        public status_update()
        {
            InitializeComponent();
            this.CenterToScreen();
            label3.Text = "not done";
            dynamic jsonResponse = request.get(@"" + Program.url + "get_projects");
            dynamic r = request.get(@"" + Program.url + "replace_chain");
            foreach (dynamic c in jsonResponse.projects)
            {
                comboBox1.Items.Add(c.project_name);

            }
            jsonResponse = request.get(@"" + Program.url + "get_contracts");
            foreach (dynamic c in jsonResponse.contracts)
            {
                comboBox2.Items.Add(c.contract_name);

            }
            jsonResponse = request.get(@"" + Program.url + "get_activities");
            foreach (dynamic c in jsonResponse.activities)
            {
                comboBox3.Items.Add(c.activity_name);
                act.contract_name = c.contract_name;
                act.activity_name = c.activity_name;
                plist.Add(act);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status_ s = new status_();
           
            s.status = "done";
            s.activity_name = comboBox3.Text;
            s.contract_name = comboBox2.Text;
            dynamic response = request.post(@"" + Program.url + "status_update", s);
            dynamic r = request.get(@"" + Program.url + "mine_block");
            r = request.get(@"" + Program.url + "replace_chain");
            MessageBox.Show("status update");
            label3.Text = "done";

        }
    }
}

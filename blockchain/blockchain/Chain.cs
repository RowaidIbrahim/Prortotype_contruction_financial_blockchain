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
    public partial class Chain : Form
    {
        Httprequest request = new Httprequest();
        public Chain()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic r = request.get(@"" + Program.url + "replace_chain");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dynamic r = request.get(@"" + Program.url + "replace_chain");
            dynamic jsonResponse = request.get(@""+Program.url+"get_chain");
            textBox1.Text = jsonResponse.chain.ToString();
        }

        private void Chain_Load(object sender, EventArgs e)
        {

        }

    }
}

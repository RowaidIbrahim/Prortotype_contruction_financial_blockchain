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
    public partial class Information_user : Form
    {
        public Information_user()
        {
            InitializeComponent();
            this.CenterToScreen();
            label7.Text = Program.user.username;
            label8.Text = Program.user.identity;
            label9.Text = Program.user.companyName;
            label10.Text = (Program.user.credit).ToString();
            label6.Text = Program.user.email;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

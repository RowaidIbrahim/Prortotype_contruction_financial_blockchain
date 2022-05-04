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
    public partial class information_admin : Form
    {
        Form1 login = new Form1();
        public information_admin()
        {
            InitializeComponent();
            this.CenterToScreen();
            label3.Text = Program.user.username;
            label4.Text = Program.user.identity;
            label6.Text = (Program.user.credit).ToString();
            label8.Text = Program.user.email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class consultant_menu : Form
    {
        public consultant_menu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information_user iu = new Information_user();
            iu.ShowDialog();
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project_Menu pm = new Project_Menu();
            pm.ShowDialog();
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            approval f = new approval();
            f.ShowDialog();
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notification n = new Notification();
            n.ShowDialog();
        }

        private void contractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contract_menu x = new contract_menu();
            x.ShowDialog();
        }
    }
}

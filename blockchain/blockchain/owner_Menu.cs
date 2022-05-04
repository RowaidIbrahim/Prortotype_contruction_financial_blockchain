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
    public partial class owner_Menu : Form
    {
        public owner_Menu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information_user user_info = new Information_user();
            user_info.ShowDialog();
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project_Menu pm = new Project_Menu();
            pm.ShowDialog();
        }

        private void contractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contract_menu cm = new contract_menu();
            cm.ShowDialog();
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notification n = new Notification();
            n.ShowDialog();
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payment p = new payment();
            p.ShowDialog();
        }
    }
}

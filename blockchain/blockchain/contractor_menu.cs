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
    public partial class contractor_menu : Form
    {
        public contractor_menu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information_user iu= new Information_user();
            iu.ShowDialog();
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Claim_Menu cm = new Claim_Menu();
            cm.ShowDialog();
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity_Menu am = new Activity_Menu();
            am.ShowDialog();
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notification n = new Notification();
            n.ShowDialog();
        }

        private void projectStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status_update f = new status_update();
            f.ShowDialog();
        }

        private void contractor_menu_Load(object sender, EventArgs e)
        {

        }
    }
}

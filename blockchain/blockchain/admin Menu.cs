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
    public partial class Admin_menu : Form
    {
        Httprequest request = new Httprequest();
        public Admin_menu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

   

        private void projectsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            projects projects = new projects();
            projects.ShowDialog();
        }

        private void contractsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            contracts contracts = new contracts();
            contracts.ShowDialog();
        }

        private void usersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            users_view uv = new users_view();
            uv.ShowDialog();
        }

        private void activitiesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            activities activities = new activities();
            activities.ShowDialog();
        }

        private void claimsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            claims claims = new claims();
            claims.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_choice uc = new user_choice();
            uc.ShowDialog();
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project_Menu project_menu = new Project_Menu();
            project_menu.ShowDialog();
        }

        private void activityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Activity_Menu activity_menu = new Activity_Menu();
            activity_menu.ShowDialog();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            information_admin info_admin = new information_admin();
            info_admin.ShowDialog();
        }

        private void chainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chain chain = new Chain();
            chain.ShowDialog();
        }

        private void Admin_menu_Load(object sender, EventArgs e)
        {
      
        }

        private void contractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            contract_menu cm = new contract_menu();
            cm.ShowDialog();
        }

        private void notificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notification n = new Notification();
            n.ShowDialog();
        }
    }
}

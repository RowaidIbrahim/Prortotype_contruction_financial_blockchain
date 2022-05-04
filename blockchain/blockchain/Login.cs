using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;

namespace blockchain
{
    
    public partial class Form1 : Form
    {
        Httprequest request = new Httprequest();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            InitializeMyControl();

        }
        public dynamic get_info()
        {
            dynamic jsonResponse = request.get(@""+Program.url+"get_info");
            return jsonResponse;
        }
        private void InitializeMyControl()
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.url = textBox3.Text;
            label3.Text="";
            label4.Text = "";
            dynamic info;
            dynamic r = request.get(@"" + Program.url + "replace_chain");
            Admin_menu a = new Admin_menu();
            owner_Menu o = new owner_Menu();
            contractor_menu c = new contractor_menu();
            consultant_menu cl = new consultant_menu();
            owner_Menu u = new owner_Menu();
            if(textBox1.Text=="")
                label3.Text = "*username required";
            if (textBox2.Text == "")
                label4.Text = "*password required";
            Program.user.username = textBox1.Text;
            Program.user.password = textBox2.Text;
            if (textBox1.Text != "" &&textBox2.Text != "")
            try
            {
                string response = request.post(@""+Program.url+"login", Program.user);

                if (response.Contains("wrong username"))
                    label3.Text = "wrong username";
                if (response.Contains("wrong password"))
                    label4.Text = "wrong password";

                if (response.Contains("admin"))
                {
                    info = get_info();
                    Program.user.identity = info.identity;
                    Program.user.email = info.email;
                    a.ShowDialog();

                }
                else if (response.Contains("owner"))
                {
                    info = get_info();
                    Program.user.identity = "owner";
                    Program.user.companyName = info.companyName;
                    Program.user.credit = info.credit;
                    Program.user.email = info.email;
                    o.ShowDialog();

                }
                else if (response.Contains("consultant"))
                {
                    info = get_info();
                    Program.user.identity = "consultant";
                    Program.user.companyName = info.companyName;
                    Program.user.credit = info.credit;
                    Program.user.email = info.email;
                    cl.ShowDialog();

                }
                else if (response.Contains("contractor"))
                {
                    info = get_info();
                    Program.user.identity = "contractor";
                    Program.user.companyName = info.companyName;
                    Program.user.credit = info.credit;
                    Program.user.email = info.email;
                    c.ShowDialog();

                }

            }catch(Exception exception)
            {
                MessageBox.Show("Connection Error.",
                 "Important Note",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation,
                 MessageBoxDefaultButton.Button1);
            }
            



            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users sign_up = new Users();
            sign_up.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Users u = new Users();
            u.ShowDialog();
        }

    }
}

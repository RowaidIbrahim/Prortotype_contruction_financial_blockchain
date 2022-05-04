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
    public partial class Users : Form
    {
        Httprequest request = new Httprequest();
        public Users()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic r = request.get(@"" + Program.url + "replace_chain");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void clear()
        {
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            User user= new User();
            if (textBox1.Text != "")
                user.username = textBox1.Text;
            else
                label5.Text = "*username required";

            if (textBox2.Text != "")
                user.password = textBox2.Text;
            else
                label6.Text = "*password required";
            if (textBox3.Text != "")
                user.companyName= textBox3.Text;
            else
                label7.Text = "*company required";
            if (comboBox1.Text != "")
                user.identity = comboBox1.Text;
            else
                label8.Text = "*identity required";
            if (textBox4.Text != "")
                user.email = textBox4.Text;
            else
                label9.Text = "*email required";

            if(textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!=""&&comboBox1.Text!=""&&textBox4.Text!="")
            {
                string response = request.post(@""+Program.url+"add_user", user);
                dynamic jsonResponse = request.get(@""+Program.url+"mine_block");
                dynamic r = request.get(@"" + Program.url + "replace_chain");
                textBox5.Text = jsonResponse.ToString();

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

       
    }
}

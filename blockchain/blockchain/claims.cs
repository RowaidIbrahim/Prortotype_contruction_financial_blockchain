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
    public partial class claims : Form
    {
        Httprequest request = new Httprequest();
        public claims()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic r = request.get(@"" + Program.url + "replace_chain");
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
           
        }

        private void claims_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            int n=0;
            dynamic jsonResponse = request.get(@""+Program.url+"get_claims");
            foreach (dynamic c in jsonResponse.claims)
            {
                    dataGridView1.Rows.Add(c.claim, c.status, c.username);
                n++;
            }
            
            dataGridView1.Rows[n].Cells[0].Value = "Total:-";
            dataGridView1.Rows[n].Cells[1].Value = dataGridView1.Rows.Count - 1;
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.Rows[n].DefaultCellStyle.ForeColor = Color.White;
            }
        }

       

        
    }


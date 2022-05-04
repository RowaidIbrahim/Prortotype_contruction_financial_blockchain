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
    public partial class activities : Form
    {
        Httprequest request = new Httprequest();
        DataTable act = new DataTable();
        int n = 0;
        public activities()
        {
            InitializeComponent();
            this.CenterToScreen();
            dynamic r = request.get(@"" + Program.url + "replace_chain");
        }

       


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void activities_Load(object sender, EventArgs e)
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
            dynamic jsonResponse = request.get(@"" + Program.url + "get_activities");
            act.Columns.AddRange(
                new DataColumn[11] { new DataColumn("activity_name", typeof(string)),
                new DataColumn("activity_no", typeof(string)),
                new DataColumn("project", typeof(string)),
                new DataColumn("duration", typeof(string)),
                new DataColumn("price", typeof(string)),
                new DataColumn("start_date", typeof(string)),
                new DataColumn("finish_date", typeof(string)),
                new DataColumn("status", typeof(string)),
                new DataColumn("approved", typeof(string)),
                new DataColumn("delays", typeof(string)),
                new DataColumn("contract_name", typeof(string))
                });
            
            foreach (dynamic c in jsonResponse.activities)
            {
                act.Rows.Add(c.activity_name,c.activity_no, c.project, c.duration, c.price, c.start_date, c.finish_date, c.status, c.approved, c.delays, c.contract_name);
                n++;
            }
            dataGridView1.DataSource = act;
            dataGridView1.Rows[n].Cells[0].Value = "Total:-";
            dataGridView1.Rows[n].Cells[1].Value = dataGridView1.Rows.Count - 1;
            dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.Rows[n].DefaultCellStyle.ForeColor = Color.White;

        }
    }
}

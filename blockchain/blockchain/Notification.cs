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
    public partial class Notification : Form
    {

        Httprequest request = new Httprequest();
        DataTable pro = new DataTable();
        int n = 0;
        public Notification()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Notification_Load(object sender, EventArgs e)
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

            dynamic jsonResponse = request.get(@"" + Program.url + "get_all_notifications");
            pro.Columns.AddRange(new DataColumn[2] { new DataColumn("notification", typeof(string)), new DataColumn("Timestamp", typeof(string)) });
            foreach (dynamic c in jsonResponse.notfications)
            {
                pro.Rows.Add(c.notification, c.timestamp);
                n++;
            }
            dataGridView1.DataSource = pro;
            dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.Rows[n].DefaultCellStyle.ForeColor = Color.White;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;

            //printPreviewDialog1.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printPreviewDialog1.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
        }


        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            pro.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "project", toolStripTextBox1.Text);
            if (toolStripTextBox1.Text == "")
            {
                dataGridView1.Rows[n].Cells[0].Value = "Total:-";
                dataGridView1.Rows[n].Cells[1].Value = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.Rows[n].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

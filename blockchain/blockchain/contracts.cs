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
    public partial class contracts : Form
    {
        Httprequest request = new Httprequest();
        DataTable cont = new DataTable();
        int n = 0;
        public contracts()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
        
        private void contracts_Load(object sender, EventArgs e)
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
            dynamic jsonResponse = request.get(@""+Program.url+"get_contracts");
            cont.Columns.AddRange(
                new DataColumn[9] { new DataColumn("Type", typeof(string)),
                new DataColumn("amount", typeof(string)),
                new DataColumn("contract_name", typeof(string)),
                new DataColumn("contract_no", typeof(string)),
                new DataColumn("date", typeof(string)),
                new DataColumn("parties", typeof(string)),
                new DataColumn("penlty", typeof(string)),
                new DataColumn("project", typeof(string)),
                new DataColumn("status", typeof(string)),
                });

            foreach (dynamic c in jsonResponse.contracts)
            {
                cont.Rows.Add(c.Type, c.amount, c.contract_name, c.contract_no, c.date, c.parties, c.penlty, c.project, c.status);
                n++;
            }
            dataGridView1.DataSource = cont;
            dataGridView1.Rows[n].Cells[0].Value = "Total:-";
            dataGridView1.Rows[n].Cells[1].Value = dataGridView1.Rows.Count - 1;
            dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.Rows[n].DefaultCellStyle.ForeColor = Color.White;
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

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeMos
{
    public partial class MuhasebeIslemleri : Form
    {
        public MuhasebeIslemleri()
        {
            InitializeComponent();
        }

        MOSEntities db = new MOSEntities();
        private Sales s = new Sales();

        void Listele()
        {
            dataGridView1.DataSource = db.Sales.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            //dataGridView1.Columns[12].Visible = false;
        }

        void Hesapla()
        {
            //Gider Hesabı
            var gider = db.Sales.Sum(t => t.PurchasePrice);
            lblGider.Text = gider.ToString();

            //Gelir Hesabı
            var gelir = db.Sales.Sum(i => i.SellPrice);
            lblGelir.Text = gelir.ToString();

            //Net kar Hesabı
            lblNetKar.Text = (gelir - gider).ToString();

        }

        private void MuhasebeIslemleri_Load(object sender, EventArgs e)
        {
            Listele();
            Hesapla();
            ListCategories();
            
        }


        private void btnSatisleriTemizle_Click(object sender, EventArgs e)
        {
            foreach (var item in db.Sales)
            {
                db.Sales.Remove(item);
            }

            db.SaveChanges();
            Listele();
        }

        private void ListByProductID(string key)
        {
            dataGridView1.DataSource = db.Sales.Where(p => p.ProductID.ToString().Contains(key)).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListByProductID(textBox1.Text);
        }

        private void ListByProductName(string key)
        {
            dataGridView1.DataSource = db.Sales.Where(i => i.ProductName.Contains(key)).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ListByProductName(textBox2.Text);
        }

        private void ListCategories()
        {
            cbxCategories.DataSource = db.Category.ToList();
            cbxCategories.DisplayMember = "CategoryName";
            cbxCategories.ValueMember = "CategoryID";
            
        }

       
        private void btnCategorySearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Sales.Where(k => k.CategoryName.Contains(cbxCategories.Text)).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application uygulama = new Microsoft.Office.Interop.Excel.Application();
            uygulama.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook kitap = uygulama.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sayfa = (Microsoft.Office.Interop.Excel.Worksheet) kitap.Sheets[1];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range) sayfa.Cells[1,i+1];
                range.Value2 = dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range) sayfa.Cells[j+2,i+1];
                    range.Value2 = dataGridView1[i,j].Value;
                    sayfa.Columns["J:J"].NumberFormat = "gg.aa.yyyy";
                    //Tarih formatı E:E Excel deki sütunun adı
                    sayfa.Columns["K:K"].NumberFormat = "gg.aa.yyyy ss:dd:nn";//Tarih saat formatı
                    
                }
            }
        }
       
        private void btnIstatistik_Click_1(object sender, EventArgs e)
        {
            Istatistikler f1 = new Istatistikler();
            f1.Show();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            Chart f2 = new Chart();
            f2.Show();
        }
    }
}

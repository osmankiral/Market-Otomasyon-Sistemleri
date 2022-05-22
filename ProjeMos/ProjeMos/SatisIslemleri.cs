using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjeMos
{
    public partial class SatisIslemleri : Form
    {
        public SatisIslemleri()
        {
            InitializeComponent();
        }
        MOSEntities db = new MOSEntities();
        Sepet s = new Sepet();
        ProductList_Result n = new ProductList_Result();
        Products p1 = new Products();
        Sales sales = new Sales();



        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtUrunID.Text = "0";
            txtUrunAdi.Text = "";
            txtKategoriAdi.Text = "";
            txtMiktar.Text = "";
            txtStok.Text = "";
            txtTedarikciAdi.Text = "";
            txtAlisFiyati.Text = "";
            txtSatisFiyati.Text = "";

        }

        private void txtUrunID_TextChanged(object sender, EventArgs e)
        {
            

            int id = Int32.Parse(txtUrunID.Text);
            var sorgu = db.Products.SingleOrDefault(o => o.ProductID == id);
            if (sorgu != null)
            {
                txtUrunAdi.Text = sorgu.ProductName;
                txtKategoriAdi.Text = sorgu.Category.CategoryName;
                txtMiktar.Text = sorgu.ProductQuantity;
                txtStok.Text = sorgu.Stock.ToString();
                txtTedarikciAdi.Text = sorgu.Supplier.SupplierName;
                txtAlisFiyati.Text = sorgu.PurchasePrice.ToString();
                txtSatisFiyati.Text = sorgu.SalePrice.ToString();
            }
           
        }

        void SepetListesi()
        {
            dataGridView1.DataSource = db.Sepet.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;


            decimal tutar = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tutar += Convert.ToDecimal(dataGridView1.Rows[i].Cells["SatisFiyati"].Value.ToString());
            }

            lblToplamTutar.Text = tutar.ToString();
        }



        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            //int id = Int32.Parse(txtUrunID.Text);
            //List<ProductList_Result> products = db.ProductList().Where(o => o.Ürün_ID == id).ToList();
            s.ProductID = Convert.ToInt32(txtUrunID.Text);
            s.UrunAdi = txtUrunAdi.Text;
            s.KategoriAdi = txtKategoriAdi.Text;
            s.Miktar = txtMiktar.Text;
            s.Stok = Convert.ToInt32(txtStok.Text);
            s.TedarikciAdi = txtTedarikciAdi.Text;
            s.SatisFiyati = Convert.ToDecimal(txtSatisFiyati.Text);
            s.AlisFiyati = Convert.ToDecimal(txtAlisFiyati.Text);
            
            //s.StokCikisi = Convert.ToInt32(txtStockOut.Text);
            db.Sepet.Add(s);
            db.SaveChanges();
            dataGridView1.DataSource = db.Sepet.ToList();
            SepetListesi();

        }

        DataTable tablo = new DataTable();

       

        private void SatisIslemleri_Load(object sender, EventArgs e)
        {
            SepetListesi();
           
        }

        private void txtOdenen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal tutar, odenen;
                tutar = Convert.ToDecimal(lblToplamTutar.Text);
                odenen = Convert.ToDecimal(txtOdenen.Text);
                decimal paraustu = odenen - tutar;
                txtParaUstu.Text = paraustu.ToString("C2");
            }
            catch
            {

            }

        }


        private void txtSatisİptal_Click(object sender, EventArgs e)
        {

            foreach (var item in db.Sepet)
            {
                db.Sepet.Remove(item);
            }

            
            db.SaveChanges();
            SepetListesi();
            


        }

        
        private void txtSatisOnay_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                
                sales.ProductID = Convert.ToInt32(dataGridView1.Rows[i].Cells["ProductID"].Value.ToString());
                sales.ProductName = dataGridView1.Rows[i].Cells["UrunAdi"].Value.ToString();
                sales.CategoryName = dataGridView1.Rows[i].Cells["KategoriAdi"].Value.ToString();
                sales.Quantity = dataGridView1.Rows[i].Cells["Miktar"].Value.ToString();
                sales.Stock = Convert.ToInt32(dataGridView1.Rows[i].Cells["Stok"].Value.ToString());
                sales.SupplierName = dataGridView1.Rows[i].Cells["TedarikciAdi"].Value.ToString();
                sales.SellPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["SatisFiyati"].Value.ToString());
                sales.PurchasePrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["AlisFiyati"].Value.ToString());
                sales.SepetID = Convert.ToInt32(dataGridView1.Rows[i].Cells["UrunID"].Value.ToString()); //URUNID = SEPETID
                sales.Date = DateTime.Parse(DateTime.Now.ToLongDateString());
                sales.Hour = DateTime.Parse(DateTime.Now.ToLongTimeString());
                db.Sales.Add(sales);
                db.SaveChanges();




            }
            
            foreach (var item in db.Sepet)
            {
                db.Sepet.Remove(item);
            }

            db.SaveChanges();
            SepetListesi();

            MessageBox.Show("İşlem Başarılı");
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        int satirsayisi = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Arial", 20);
                SolidBrush firca = new SolidBrush(Color.Black);
                Pen kalem = new Pen(Color.Black);

                e.Graphics.DrawString("Düzenlenme Tarihi: " + DateTime.Now.ToLongDateString() + " " +
                        "" + DateTime.Now.ToLongTimeString(), font, firca, 50, 25);
                e.Graphics.DrawLine(kalem, 50, 65, 770, 65);
                e.Graphics.DrawLine(kalem, 50, 1000, 50, 65);

                e.Graphics.DrawLine(kalem, 50, 1000, 770, 1000);
                e.Graphics.DrawLine(kalem, 770, 1000, 770, 65);
                ////////////////////////////////////////////////////
                font = new Font("Arial", 20, FontStyle.Bold);
                e.Graphics.DrawString("Ürün Listesi", font, firca, 350, 75);
                e.Graphics.DrawLine(kalem, 50, 110, 770, 110);

                font = new Font("Arial", 15, FontStyle.Bold);
                e.Graphics.DrawString("Sıra", font, firca, 60, 118);
                e.Graphics.DrawString("Ürün Adı", font, firca, 150, 118);
                e.Graphics.DrawString("Miktar", font, firca, 450,118);
                e.Graphics.DrawString("Fiyat", font, firca, 650, 118);
                
                e.Graphics.DrawLine(kalem, 50, 150, 770, 150);
                ////////////////////////////////////////////////////////
                e.Graphics.DrawString("Ödenen=" + txtOdenen.Text + "  TL", font, firca, 60, 1025);
                e.Graphics.DrawString("Paraüstü=" + txtParaUstu.Text + "  TL", font, firca, 60, 1065);
                e.Graphics.DrawString("Genel Toplam=" + lblToplamTutar.Text + "  TL", font, firca, 480, 1065);
                /////////////////////////////////////////////////////////
                int y = 160;

                font = new Font("Arial", 15);
                int i = 0;
                while (i <= dataGridView1.Rows.Count-1)
                {
                    e.Graphics.DrawString((i + 1) + ".", font, firca, 60, y);
                    e.Graphics.DrawString(dataGridView1[1, i].Value.ToString(), font, firca, 150, y);
                    e.Graphics.DrawString(dataGridView1[4, i].Value.ToString(), font, firca, 450, y);
                    e.Graphics.DrawString(dataGridView1[7, i].Value.ToString(), font, firca, 650, y);
                    
                    y = y + 25;
                    i = i + 1;

                    if (y > 1000)
                    {
                        e.Graphics.DrawString("Devamı Diğer Sayfada---->", font, firca, 700, y + 50);
                        y = 50;
                        break;

                    }
                }
                if (i < satirsayisi)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                    i = 0;
                }


                StringFormat strformat = new StringFormat();
                strformat.Alignment = StringAlignment.Far;
                return;

            }
            catch
            {
                ;

            }
        }
    }
}

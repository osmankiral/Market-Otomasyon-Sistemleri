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
    public partial class UrunIslemleri : Form
    {
        public UrunIslemleri()
        {
            InitializeComponent();
        }

        MOSEntities db = new MOSEntities();
        Category c = new Category();
        Products p = new Products();
        Supplier s = new Supplier();

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxCategoryFill();
            cbxSupplierFill();
        }


        //Ürünleri Listeleme
        private void btnProductList_Click(object sender, EventArgs e)
        {
            //Products tablosu ve Category tablosundaki sütunların birleşimi için SQL sorgusu  ile oluşturduğumuz ProductList tablosundaki verileri listeleme 
            dataGridView1.DataSource = db.ProductList();
            
        }


        //Kategorileri Listeleme
        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Category.ToList();
            dataGridView1.Columns[2].Visible = false;
        }


        //Tedarikçileri Listeleme
        private void btnSupplierList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Supplier.ToList();
            dataGridView1.Columns[3].Visible = false;
        }


        //Ürün Ekleme
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            p.ProductName = tbxProductName.Text;
            p.CategoryID = Convert.ToInt32(cbxCategory.SelectedValue);
            p.ProductQuantity = tbxQuantity.Text;
            p.Stock = Convert.ToInt32(tbxStock.Text);
            p.PurchasePrice = Convert.ToDecimal(tbxPurchase.Text);
            p.SalePrice = Convert.ToDecimal(tbxSale.Text);
            db.Products.Add(p);
            db.SaveChanges();
            dataGridView1.DataSource = db.ProductList();
            MessageBox.Show("Ürün Eklenmiştir.");
        }


        //Ürün Silme
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxProductID.Text);
            var x = db.Products.Find(id);
            db.Products.Remove(x);
            db.SaveChanges();
            dataGridView1.DataSource = db.ProductList();
            MessageBox.Show("Ürün Silindi.");
        }


        //Ürün Güncelleme
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxProductID.Text);
            var x = db.Products.Find(id);
            x.ProductName = tbxProductName.Text;
            x.CategoryID = Convert.ToInt32(cbxCategory.SelectedValue);
            x.ProductQuantity = tbxQuantity.Text;
            x.Stock = Convert.ToInt32(tbxStock.Text);
            x.PurchasePrice = Convert.ToDecimal(tbxPurchase.Text);
            x.SalePrice = Convert.ToDecimal(tbxSale.Text);
            x.SupplierID = Convert.ToInt32(cbxSupplierName.SelectedValue);
            db.SaveChanges();
            dataGridView1.DataSource = db.ProductList();
            MessageBox.Show("Ürün Bilgileri Güncellendi.");

        }

        //Kategori için oluşturduğumuz comboboxa, veri tabanından verileri iletme
        void cbxCategoryFill()
        {
            cbxCategory.DataSource = db.Category.ToList();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryID";
        }

        void cbxSupplierFill()
        {
            cbxSupplierName.DataSource = db.Supplier.ToList();
            cbxSupplierName.DisplayMember = "SupplierName";
            cbxSupplierName.ValueMember = "SupplierID";
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            c.CategoryName = tbxCategoryName.Text;
            db.Category.Add(c);
            db.SaveChanges();
            dataGridView1.DataSource = db.Category.ToList();
            MessageBox.Show("Kategori Eklenmiştir.");
        }

        private void btnCategoryUpdate_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(tbxCategoryID.Text);
            var x = db.Category.Find(id);
            x.CategoryName = tbxCategoryName.Text;
            
            db.SaveChanges();
            dataGridView1.DataSource = db.Category.ToList();
            MessageBox.Show("Kategori Bilgileri Güncellendi.");
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxCategoryID.Text);
            var x = db.Category.Find(id);
            db.Category.Remove(x);
            db.SaveChanges();
            dataGridView1.DataSource = db.Category.ToList();
            MessageBox.Show("Kategori Silindi.");
        }

        
        private void btnSupplierAdd_Click_1(object sender, EventArgs e)
        {
            s.SupplierName = tbxSupplierName.Text;
            s.SupplierPhone = tbxSupplierPhone.Text;
            db.Supplier.Add(s);
            db.SaveChanges();
            dataGridView1.DataSource = db.Supplier.ToList();
            MessageBox.Show("Tedarikçi Eklendi.");
        }

        private void btnSupplierUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxSupplierID.Text);
            var x = db.Supplier.Find(id);
            x.SupplierName = tbxSupplierName.Text;
            x.SupplierPhone = tbxSupplierPhone.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.Supplier.ToList();
            MessageBox.Show("Tedarikçi Bilgileri Güncellendi.");
        }

        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxSupplierID.Text);
            var x = db.Supplier.Find(id);
            db.Supplier.Remove(x);
            db.SaveChanges();
            dataGridView1.DataSource = db.Supplier.ToList();
            MessageBox.Show("Tedarikçi Silindi.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxProductID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxProductName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxCategoryName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxQuantity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxStock.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxPurchase.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxSale.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}

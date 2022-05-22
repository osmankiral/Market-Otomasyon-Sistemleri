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
    public partial class Istatistikler : Form
    {
        public Istatistikler()
        {
            InitializeComponent();
        }

        MuhasebeIslemleri m = new MuhasebeIslemleri();
        MOSEntities db = new MOSEntities();

        private void Istatistik_Load(object sender, EventArgs e)
        {
            lblToplamUrun.Text = db.Products.Count().ToString();
            lblToplamKategori.Text = db.Category.Count().ToString();
            lblToplamTedarik.Text = db.Supplier.Count().ToString();
            lblToplamSatilanUrun.Text = db.Sales.Count().ToString();
            lblSonSatilanUrun.Text =
                db.Sales.OrderByDescending(x => x.SalesID).Select(x => x.ProductName).FirstOrDefault();
            DateTime bugun = DateTime.Today;
            lblBugunSatilanUrunSayisi.Text = db.Sales.Count(x => x.Date == bugun).ToString();
            lblCokSatilanUrun.Text = db.Sales.GroupBy(x => x.ProductName).OrderByDescending(z => z.Count())
                .Select(y => y.Key).FirstOrDefault().ToString();
            lblCokSatilanKategori.Text = db.Sales.GroupBy(x => x.CategoryName).OrderByDescending(z => z.Count())
                .Select(y => y.Key).FirstOrDefault().ToString();
            var gider = db.Sales.Sum(t => t.PurchasePrice);
            var gelir = db.Sales.Sum(i => i.SellPrice);
            lblCiro.Text = (gelir - gider).ToString();

        }
    }
}

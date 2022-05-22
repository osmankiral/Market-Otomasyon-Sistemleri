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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        MOSEntities db = new MOSEntities();
        private Sales s = new Sales();

        private void Chart_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Sales
                select new
                {
                    x.CategoryName
                }).ToList();
            chart1.Series["Series1"].Points.AddXY("Atıştırmalık", db.Sales.Where(x=>x.CategoryName == "Atıştırmalık").Count().ToString());
            chart1.Series["Series1"].Points.AddXY("İçecek", db.Sales.Where(x => x.CategoryName == "İçecek").Count().ToString());
            chart1.Series["Series1"].Points.AddXY("Meyve", db.Sales.Where(x => x.CategoryName == "Meyve").Count().ToString());
            chart1.Series["Series1"].Points.AddXY("Sebze", db.Sales.Where(x => x.CategoryName == "Sebze").Count().ToString());
            chart1.Series["Series1"].Points.AddXY("Fırın", db.Sales.Where(x => x.CategoryName == "Fırın").Count().ToString());
            chart1.Series["Series1"].Points.AddXY("Süt Ürünleri", db.Sales.Where(x => x.CategoryName == "Süt Ürünleri").Count().ToString());
            chart1.Series["Series1"].Points.AddXY("Kişisel Bakım", db.Sales.Where(x => x.CategoryName == "Kişisel Bakım").Count().ToString());
            chart1.Series["Series1"].Points.AddXY("Ev Bakım", db.Sales.Where(x => x.CategoryName == "Ev Bakım").Count().ToString());
            chart1.Series["Series1"].Points.AddXY("Teknoloji", db.Sales.Where(x => x.CategoryName == "Teknoloji").Count().ToString());

        }
    }
}

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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        /*private void pictureBox2_Click(object sender, EventArgs e)
        {
            UrunIslemleri f2 = new UrunIslemleri();
            f2.Show();
        } */
        private Member m = new Member();

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            
            this.Hide();
            f1.Show();

            
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            UrunIslemleri f2 = new UrunIslemleri();
            f2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SatisIslemleri f3 = new SatisIslemleri();
            f3.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MuhasebeIslemleri f4 = new MuhasebeIslemleri();
            f4.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

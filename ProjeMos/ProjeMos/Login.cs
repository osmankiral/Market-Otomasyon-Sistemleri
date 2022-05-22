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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;
            var errorMessage = "";
            var isError = false;

            if (string.IsNullOrEmpty(username))
            {
                errorMessage += "Kullanıcı adını boş geçemezsiniz!\r\n";
                isError = true;
            }
            if (string.IsNullOrEmpty(password))
            {
                errorMessage += "Şifreyi boş geçemezsiniz!\r\n";
                isError = true;
            }

            if (isError == true)
            {
                MessageBox.Show(errorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var memberLoginState = MemberLogin(username, password);

            
            if (memberLoginState == true)
            {
                Menu f1 = new Menu();
                f1.Show();
                this.Hide();
            }
            else
            {
                 MessageBox.Show("Başarısız");
            }
        }

        public bool MemberLogin(string username, string password)
        {
            MOSEntities context = new MOSEntities();

            var user = (from p in context.Member
                        where p.MemberUserName == username && p.MemberPassword == password select p).FirstOrDefault();
            if (user != null)
            {
                return true;
            }


            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

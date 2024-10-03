using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Boutique_Hotel_1._0
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txthotel.Text = txthotel.Text.Substring(1) + txthotel.Text.Substring(0, 1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="Admin" && txtPassword.Text=="344")
            {
                RegistrationForm rf = new RegistrationForm();
                rf.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Incorrect login");
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
    }
}

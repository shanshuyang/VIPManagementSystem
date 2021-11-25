using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LingYi_Photography
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            int panelX = (Size.Width - panel1.Width) / 2;
            int panelY = (Size.Height - panel1.Height) / 2;
            panel1.Location = new Point(panelX, panelY);
            Txt_username.Text = "用户名";
            Txt_password.Text = "密码";
        }
        
        private void Btn_login_Click(object sender, EventArgs e)
        {
            //登录代码，等待txt账户文件完成后更改此部分代码
            if (Txt_username.Text == "admin" && Txt_password.Text == "admin")
            {
                Hide();
                Txt_username.Text = "用户名";
                Txt_password.Text = "密码";
                VIPManagement vIPManagement = new VIPManagement(this);
                vIPManagement.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_password.Text = "";
                Txt_username.Focus();
            }
        }

        private void Btn_quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否关闭系统？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Txt_username_Enter(object sender, EventArgs e)
        {
            if (Txt_username.Text == "用户名")
            {
                Txt_username.Text = "";
            }
        }
        private void Txt_username_Leave(object sender, EventArgs e)
        {
            if (Txt_username.Text == "")
            {
                Txt_username.Text = "用户名";
            }
        }
        private void Txt_password_Enter(object sender, EventArgs e)
        {
            if (Txt_password.Text == "密码")
            {
                Txt_password.Text = "";
                Txt_password.UseSystemPasswordChar = true;
            }
        }
        private void Txt_password_Leave(object sender, EventArgs e)
        {
            if (Txt_password.Text == "")
            {
                Txt_password.Text = "密码";
                Txt_password.UseSystemPasswordChar = false;
            }
        }
    }
}

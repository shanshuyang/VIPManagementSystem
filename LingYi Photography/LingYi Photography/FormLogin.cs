using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer.Login;
using Model.Admin;

namespace LingYi_Photography
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //窗体Load事件
        private void Login_Load(object sender, EventArgs e)
        {
            int panelX = (Size.Width - panel1.Width) / 2;
            int panelY = (Size.Height - panel1.Height) / 2;
            panel1.Location = new Point(panelX, panelY);
            Txt_username.Text = "用户名";
            Txt_password.Text = "密码";
        }
        
        //登录按钮Click事件
        private void Btn_login_Click(object sender, EventArgs e)
        {
            //用户名和密码都不为空
            if (Txt_username.Text != "" && Txt_username.Text != "用户名" && Txt_password.Text != "" && Txt_password.Text != "密码")
            {
                Administrator administrator;
                VerifiedLoginBLL verifiedLoginBLL = new VerifiedLoginBLL();
                string username = Txt_username.Text;
                string password = Txt_password.Text;
                string path = Application.StartupPath + @"\Data\AdministratorInfo.txt";
                administrator = verifiedLoginBLL.GetAdministrator(username, password, path);
                if (administrator != null)
                {
                    Hide();
                    Txt_username.Text = "用户名";
                    Txt_password.Text = "密码";
                    Txt_password.UseSystemPasswordChar = false;
                    FormVIPManagement formVIPManagement= new FormVIPManagement(this, administrator);
                    formVIPManagement.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_password.Text = "";
                    Txt_username.Focus();
                }
            }
            //用户名为空
            else if ((Txt_username.Text == "" || Txt_username.Text == "用户名") && (Txt_password.Text != "" && Txt_password.Text != "密码"))
            {
                MessageBox.Show("用户名不能为空，请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_username.Focus();
            }
            //密码为空
            else if ((Txt_username.Text != "" && Txt_username.Text != "用户名") && (Txt_password.Text == "" || Txt_password.Text == "密码"))
            {
                MessageBox.Show("密码不能为空，请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_password.Focus();
            }
            //用户名和密码都为空
            else
            {
                MessageBox.Show("用户名和密码不能为空，请输入用户名和密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_username.Focus();
            }
        }

        //退出按钮Click事件。
        private void Btn_quit_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        //Login窗体FormingClosing事件。
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
        
        //用户名文本框，焦点Enter事件。
        private void Txt_username_Enter(object sender, EventArgs e)
        {
            if (Txt_username.Text == "用户名")
            {
                Txt_username.Text = "";
            }
        }

        //用户名文本框，焦点Leave事件。
        private void Txt_username_Leave(object sender, EventArgs e)
        {
            if (Txt_username.Text == "")
            {
                Txt_username.Text = "用户名";
            }
        }

        //密码文本框，焦点Enter事件。
        private void Txt_password_Enter(object sender, EventArgs e)
        {
            if (Txt_password.Text == "密码")
            {
                Txt_password.Text = "";
                Txt_password.UseSystemPasswordChar = true;
            }
        }

        //密码文本框，焦点Leave事件。
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

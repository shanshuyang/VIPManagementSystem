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

namespace LingYi_Photography
{
    public partial class Login : Form
    {
        StreamReader sr;
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
        
        /// <summary>
        /// 说明：登录按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_login_Click(object sender, EventArgs e)
        {
            //用户名和密码都不为空
            if (Txt_username.Text != "" && Txt_username.Text != "用户名" && Txt_password.Text != "" && Txt_password.Text != "密码")
            {
                string username = Txt_username.Text;
                string password = Txt_password.Text;
                string adminData;
                string[] adminSubData = new string[3];
                bool result = false;
                sr = new StreamReader(Application.StartupPath + @"\Data\AdministratorInfo.txt");
                adminData = sr.ReadLine();
                while (adminData != null)
                {
                    adminSubData = adminData.Split('|');
                    if (username == adminSubData[0] && password == adminSubData[1])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        adminData = sr.ReadLine();
                    }
                }
                sr.Close();
                if (result)
                {
                    Administrator administrator;
                    switch (Convert.ToInt32(adminSubData[2]))
                    {
                        case 0:
                        case 1: 
                            administrator = new CommonAdmin();
                            break;
                        case 2:
                            administrator = new RootAdmin();
                            break;
                        default:
                            administrator = new CommonAdmin();
                            break;
                    }
                    administrator.Name = adminSubData[0];
                    Hide();
                    Txt_username.Text = "用户名";
                    Txt_password.Text = "密码";
                    Txt_password.UseSystemPasswordChar = false;
                    VIPManagement vIPManagement = new VIPManagement(this, administrator);
                    vIPManagement.Show();
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

        /// <summary>
        /// 说明：退出按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_quit_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        /// <summary>
        /// 说明：Login窗体FormingClosing事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// 说明：用户名文本框，焦点Enter事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_username_Enter(object sender, EventArgs e)
        {
            if (Txt_username.Text == "用户名")
            {
                Txt_username.Text = "";
            }
        }

        /// <summary>
        /// 说明：用户名文本框，焦点Leave事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_username_Leave(object sender, EventArgs e)
        {
            if (Txt_username.Text == "")
            {
                Txt_username.Text = "用户名";
            }
        }

        /// <summary>
        /// 说明：密码文本框，焦点Enter事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_password_Enter(object sender, EventArgs e)
        {
            if (Txt_password.Text == "密码")
            {
                Txt_password.Text = "";
                Txt_password.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// 说明：密码文本框，焦点Leave事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

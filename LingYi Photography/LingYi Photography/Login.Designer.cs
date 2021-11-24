
namespace LingYi_Photography
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_login = new System.Windows.Forms.Button();
            this.Btn_quit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Txt_password = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Txt_username = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_login
            // 
            this.Btn_login.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_login.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.Btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_login.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.Btn_login.ForeColor = System.Drawing.Color.White;
            this.Btn_login.Location = new System.Drawing.Point(100, 300);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(150, 50);
            this.Btn_login.TabIndex = 0;
            this.Btn_login.Text = "登录";
            this.Btn_login.UseVisualStyleBackColor = false;
            this.Btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // Btn_quit
            // 
            this.Btn_quit.BackColor = System.Drawing.Color.Red;
            this.Btn_quit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Btn_quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_quit.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.Btn_quit.ForeColor = System.Drawing.Color.White;
            this.Btn_quit.Location = new System.Drawing.Point(350, 300);
            this.Btn_quit.Name = "Btn_quit";
            this.Btn_quit.Size = new System.Drawing.Size(150, 50);
            this.Btn_quit.TabIndex = 1;
            this.Btn_quit.Text = "退出";
            this.Btn_quit.UseVisualStyleBackColor = false;
            this.Btn_quit.Click += new System.EventHandler(this.Btn_quit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Txt_password);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Txt_username);
            this.panel1.Controls.Add(this.Btn_quit);
            this.panel1.Controls.Add(this.Btn_login);
            this.panel1.Location = new System.Drawing.Point(216, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 400);
            this.panel1.TabIndex = 2;
            // 
            // Txt_password
            // 
            this.Txt_password.Font = new System.Drawing.Font("宋体", 14F);
            this.Txt_password.Location = new System.Drawing.Point(134, 210);
            this.Txt_password.Name = "Txt_password";
            this.Txt_password.Size = new System.Drawing.Size(366, 34);
            this.Txt_password.TabIndex = 6;
            this.Txt_password.Text = "密码";
            this.Txt_password.Enter += new System.EventHandler(this.Txt_password_Enter);
            this.Txt_password.Leave += new System.EventHandler(this.Txt_password_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::LingYi_Photography.Properties.Resources.密码图片;
            this.pictureBox2.Location = new System.Drawing.Point(100, 210);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(135, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "灵逸摄影管理员系统";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::LingYi_Photography.Properties.Resources.用户名图片;
            this.pictureBox1.Location = new System.Drawing.Point(100, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Txt_username
            // 
            this.Txt_username.Font = new System.Drawing.Font("宋体", 14F);
            this.Txt_username.Location = new System.Drawing.Point(134, 140);
            this.Txt_username.Name = "Txt_username";
            this.Txt_username.Size = new System.Drawing.Size(366, 34);
            this.Txt_username.TabIndex = 2;
            this.Txt_username.Text = "用户名";
            this.Txt_username.Enter += new System.EventHandler(this.Txt_username_Enter);
            this.Txt_username.Leave += new System.EventHandler(this.Txt_username_Leave);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LingYi_Photography.Properties.Resources.登录界面背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1033, 529);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "登录账户";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_login;
        private System.Windows.Forms.Button Btn_quit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Txt_username;
        private System.Windows.Forms.TextBox Txt_password;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Admin;
using Model.VIP;
using BusinessLogicLayer.ManageVIP;

namespace LingYi_Photography
{
    enum VIPData
    {
        Phone = 0,
        Name = 1,
        Sex = 2,
        Banlance = 3,
        Total = 4,
        Draw = 5,
    }    
    
    public partial class FormVIPManagement : Form
    {
        private readonly string path = Application.StartupPath + @"\Data\VIPInfo.txt";
        private readonly FormLogin login;
        private readonly Administrator administrator;

        /// <summary>
        /// 说明：VIPManagement类的构造函数。
        /// </summary>
        /// <param name="loginForm">Login窗体的对象，用于保存Login窗体的界面</param>
        /// <param name="administrator">Administrator类型对象，用于保存登录系统的管理员信息</param>
        public FormVIPManagement(FormLogin loginForm, Administrator administrator)
        {
            login = loginForm;
            this.administrator = administrator;
            InitializeComponent();
        }
        
        //Load事件
        private void VIPManagement_Load(object sender, EventArgs e)
        {
            //重新定义部分组件的大小、位置、显示
            //设置头部框及其组件
            Pl_header.Width = Width;
            label2.Location = new Point((Pl_header.Width - label2.Width) / 2, (Pl_header.Height - label2.Height) / 2);
            Btn_logout.Location = new Point(Width - Btn_logout.Width - 30, 5);
            Btn_setting.Location = new Point(Btn_logout.Location.X - Btn_setting.Width - 15, 5);
            Btn_administrator.Location = new Point(Btn_setting.Location.X - Btn_administrator.Width - 15, 5);
            //设置导航栏
            Pl_navigation.Height = Height - Pl_header.Height;
            //设置添加会员界面
            Pl_addVIP.Visible = false;
            Pl_addVIP.Width = Width - Pl_navigation.Width;
            Pl_addVIP.Height = Height - Pl_header.Height;
            Pl_addVIP.Location = new Point(Pl_navigation.Width, Pl_header.Height);
            Pl_addVIP.Parent = this;
            //设置查询会员界面
            Pl_queryVIP.Visible = false;
            Pl_queryVIP.Width = Width - Pl_navigation.Width;
            Pl_queryVIP.Height = Height - Pl_header.Height;
            Pl_queryVIP.Location = new Point(Pl_navigation.Width, Pl_header.Height);
            Pl_queryVIP.Parent = this;
            //设置会员充值界面
            Pl_rechargeMoney.Visible = false;
            Pl_rechargeMoney.Width = Width - Pl_navigation.Width;
            Pl_rechargeMoney.Height = Height - Pl_header.Height;
            Pl_rechargeMoney.Location = new Point(Pl_navigation.Width, Pl_header.Height);
            Pl_rechargeMoney.Parent = this;
            //设置会员消费界面
            Pl_spendMoney.Visible = false;
            Pl_spendMoney.Width= Width - Pl_navigation.Width;
            Pl_spendMoney.Height = Height - Pl_header.Height;
            Pl_spendMoney.Location = new Point(Pl_navigation.Width, Pl_header.Height);
            Pl_spendMoney.Parent = this;
        }
        
        //FormClosing事件
        private void VIPManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否注销并返回登录界面？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                login.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 说明：头部框界面中，管理员信息按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_administrator_Click(object sender, EventArgs e)
        {
            FormAdministratorInformation administratorInformation = new FormAdministratorInformation(administrator);
            administratorInformation.Show();
        }

        /// <summary>
        /// 说明：头部框界面中，系统设置按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_setting_Click(object sender, EventArgs e)
        {
            //do something
        }

        //头部框界面中，登出账户按钮Click事件。
        private void Btn_logout_Click(object sender, EventArgs e)
        {
            Close();
        }

        //导航栏界面中，添加会员按钮Click事件。
        private void Btn_addVIP_Click(object sender, EventArgs e)
        {
            Btn_Click_Change(Btn_addVIP, Pl_addVIP);
        }

        //导航栏界面中，查询会员按钮Click事件。
        private void Btn_queryVIP_Click(object sender, EventArgs e)
        {
            Btn_Click_Change(Btn_queryVIP, Pl_queryVIP);
        }

        //导航栏界面中，会员充值按钮Click事件。
        private void Btn_addMoney_Click(object sender, EventArgs e)
        {
            Btn_Click_Change(Btn_rechargeMoney, Pl_rechargeMoney);
        }
        
        //导航栏界面中，会员消费按钮Click事件。
        private void Btn_spendMoney_Click(object sender, EventArgs e)
        {
            Btn_Click_Change(Btn_spendMoney, Pl_spendMoney);
        }

        //重置导航栏内所有按钮的样式并隐藏其对应的界面，之后为点击的按钮设置新的样式并显示其对应的界面。
        private void Btn_Click_Change(Button button, Panel panel)
        {
            //初始化所有按钮的背景色和边框色
            Btn_addVIP.BackColor = Color.Navy;
            Btn_addVIP.FlatAppearance.BorderColor = Color.Navy;
            Btn_queryVIP.BackColor = Color.Navy;
            Btn_queryVIP.FlatAppearance.BorderColor = Color.Navy;
            Btn_rechargeMoney.BackColor = Color.Navy;
            Btn_rechargeMoney.FlatAppearance.BorderColor = Color.Navy;
            Btn_spendMoney.BackColor = Color.Navy;
            Btn_spendMoney.FlatAppearance.BorderColor = Color.Navy;
            //为选择的按钮设置背景色和边框色
            button.BackColor = Color.Blue;
            button.FlatAppearance.BorderColor = Color.Blue;
            //隐藏所有的panel界面
            Pl_addVIP.Visible = false;
            Pl_queryVIP.Visible = false;
            Pl_rechargeMoney.Visible = false;
            Pl_spendMoney.Visible = false;
            //显示选择的panel界面
            panel.Visible = true;
            //初始化所有界面的子组件
            InitializeAddVIPPanelComponents();
            InitializeQueryVIPPanelComponents();
            InitializeRechargeMoneyPanelComponents();
            InitializeSpendMoneyPanelComponents();
        }

        //添加会员界面中，清空按钮Click事件。
        private void Btn_addVIPClear_Click(object sender, EventArgs e)
        {
            InitializeAddVIPPanelComponents();
        }

        //添加会员界面中，提交按钮Click事件。
        private void Btn_addVIPSubmit_Click(object sender, EventArgs e)
        {
            //注册VIP的基本数据
            string name = Txt_addName.Text;
            string phone = Txt_addPhone.Text;
            string sex = Rbtn_male.Checked ? "男" : "女";
            decimal balance = Nudown_addMoney.Value;
            decimal total = balance;
            bool dataResult = false;
            bool DBResult = false;
            bool FResult;
            InsertVIPBLL insertVIPBLL = new InsertVIPBLL();
            if (name != "" && phone != "")
            {
                int checkNameAndPhoneResult = insertVIPBLL.VerifiedNewVIPData(name, phone);
                if (checkNameAndPhoneResult == 1)
                {
                    MessageBox.Show("请输入正确的姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addName.Focus();
                }
                else if (checkNameAndPhoneResult == 2)
                {
                    MessageBox.Show("请输入正确的手机号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addPhone.Focus();
                }
                else if (checkNameAndPhoneResult == 3)
                {
                    MessageBox.Show("请输入正确的姓名和手机号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addName.Focus();
                }
                else
                {
                    dataResult = true;
                }
            }
            else
            {
                if (phone != "")
                {
                    MessageBox.Show("姓名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addName.Focus();
                }
                else if (name != "")
                {
                    MessageBox.Show("手机号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addPhone.Focus();
                }
                else
                {
                    MessageBox.Show("姓名和手机号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addName.Focus();
                }
            }
            //数据文本中的数据格式为：手机号|姓名|性别|余额|充入总金额|剩余抽奖次数
            //将预存数据与数据文本进行对比检验
            if (dataResult == true)
            {
                DBResult = !(insertVIPBLL.IsNewVIPExist(phone, path));
            }
            //此处将数据录入数据文本
            if (DBResult)
            {
                FResult = insertVIPBLL.InsertNewVIP(name, phone, sex, balance, total, path);
                //注册成功后的后续操作
                if (FResult)
                {
                    InitializeAddVIPPanelComponents();
                    MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("注册失败！原因未知，请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("注册失败！该用户已经是会员了。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //查询会员界面中，查询按钮Click事件。
        private void Btn_querySubmit_Click(object sender, EventArgs e)
        {
            string name = Txt_queryName.Text;
            string phone = Txt_queryPhone.Text;
            QueryVIPBLL queryVIPBLL = new QueryVIPBLL();
            DataTable VIPDataTable;
            if (name == "" && phone == "")
            {
                VIPDataTable = queryVIPBLL.ShowAllVIPs(path);
            }
            else if (phone != "")
            {
                if (queryVIPBLL.VerifiedQueryPhone(phone))
                {
                    VIPDataTable = queryVIPBLL.ShowVIPWithPhone(phone, path);
                }
                else
                {
                    MessageBox.Show("手机号位数错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    VIPDataTable = queryVIPBLL.ShowAllVIPs(path);
                    Txt_queryPhone.Focus();
                }
            }
            else
            {
                if (queryVIPBLL.VerifiedQueryName(name))
                {
                    VIPDataTable = queryVIPBLL.ShowVIPWithName(name, path);
                }
                else
                {
                    MessageBox.Show("姓名错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    VIPDataTable = queryVIPBLL.ShowAllVIPs(path);
                    Txt_queryName.Focus();
                }
            }
            Dgv_VIPInfo.DataSource = VIPDataTable;
        }

        //会员充值界面中，手机号文本框TextChanged事件。
        private void Txt_rechargeMoneyQueryPhone_TextChanged(object sender, EventArgs e)
        {
            InitializeRechargeMoneyDeatilsPanelComponents();
        }
        
        //会员充值界面中，查询按钮Click事件。
        private void Btn_rechargeMoneyQuerySubmit_Click(object sender, EventArgs e)
        {
            string phone = Txt_rechargeMoneyQueryPhone.Text;
            UpdateMoneyBLL updateMoneyBLL = new UpdateMoneyBLL();
            VIPInfo originVIP;            
            if (phone != "")
            {
                if (updateMoneyBLL.VerifiedQueryPhone(phone))
                {
                    originVIP = updateMoneyBLL.QueryVIPByPhone(phone, path);
                    if (originVIP != null)
                    {
                        Lab_chargeMoneyName.Text = originVIP.Name;
                        Lab_chargeMoneySex.Text = originVIP.Sex;
                        Lab_chargeMoneyBalance.Text = originVIP.Balance.ToString();
                        Lab_chargeMoneyTotal.Text = originVIP.Total.ToString();
                        Lab_chargeMoneyDraw.Text = originVIP.Draw.ToString();
                        Pl_rechargeMoneyDetails.Visible = true;
                    }
                    else
                    {
                        InitializeRechargeMoneyDeatilsPanelComponents();
                        MessageBox.Show("没有查到该用户，请检查手机号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Txt_rechargeMoneyQueryPhone.Focus();
                    }
                }
                else
                {
                    InitializeRechargeMoneyDeatilsPanelComponents();
                    MessageBox.Show("手机号位数错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_rechargeMoneyQueryPhone.Focus();
                }
            }
            else
            {
                InitializeRechargeMoneyDeatilsPanelComponents();
                MessageBox.Show("手机号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_rechargeMoneyQueryPhone.Focus();
            }
        }
        
        //会员充值界面中，充值按钮Click事件。
        private void Btn_rechargeMoneyRecharge_Click(object sender, EventArgs e)
        {
            UpdateMoneyBLL updateMoneyBLL = new UpdateMoneyBLL();
            VIPInfo originVIP;
            string phone = Txt_rechargeMoneyQueryPhone.Text;
            string name = Lab_chargeMoneyName.Text;
            decimal rechargeMoney = Nudown_rechargeMoneyNumber.Value;
            originVIP = updateMoneyBLL.QueryVIPByPhone(phone, path);
            if (rechargeMoney != 0.0M)
            {               
                DialogResult dr = MessageBox.Show("是否要为用户：" + name + "，手机号：" + phone + "，充入金额：" + rechargeMoney + "元？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (updateMoneyBLL.UpdateVIPBalance(originVIP, rechargeMoney, path))
                    {
                        Lab_chargeMoneyBalance.Text = originVIP.Balance.ToString();
                        Lab_chargeMoneyTotal.Text = originVIP.Total.ToString();
                        MessageBox.Show("充值成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("充值失败，原因未知，请联系开发人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Nudown_rechargeMoneyNumber.Focus();
                }
            }
            else
            {
                MessageBox.Show("请输入要充入的金额！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Nudown_rechargeMoneyNumber.Focus();
            }
        }

        // 会员消费界面中，手机号文本框TextChanged事件。
        private void Txt_spendMoneyQueryPhone_TextChanged(object sender, EventArgs e)
        {
            InitializeSpendMoneyDeatilsPanelComponents();
        }

        //会员消费界面中，查询按钮Click事件。
        private void Btn_spendMoneyQuerySubmit_Click(object sender, EventArgs e)
        {
            string phone = Txt_spendMoneyQueryPhone.Text;
            UpdateMoneyBLL updateMoneyBLL = new UpdateMoneyBLL();
            VIPInfo originVIP;
            if (phone != "")
            {
                if (phone.Length == 11)
                {
                    if (updateMoneyBLL.VerifiedQueryPhone(phone))
                    {
                        originVIP = updateMoneyBLL.QueryVIPByPhone(phone, path);
                        if (originVIP != null)
                        {
                            Lab_spendMoneyName.Text = originVIP.Name;
                            Lab_spendMoneySex.Text = originVIP.Sex;
                            Lab_spendMoneyBalance.Text = originVIP.Balance.ToString();
                            Lab_spendMoneyTotal.Text = originVIP.Total.ToString();
                            Lab_spendMoneyDraw.Text = originVIP.Draw.ToString();
                            Pl_spendMoneyDetails.Visible = true;
                        }
                    }
                    else
                    {
                        InitializeSpendMoneyDeatilsPanelComponents();
                        MessageBox.Show("没有查到该用户，请检查手机号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Txt_spendMoneyQueryPhone.Focus();
                    }
                }
                else
                {
                    InitializeSpendMoneyDeatilsPanelComponents();
                    MessageBox.Show("手机号位数错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_spendMoneyQueryPhone.Focus();
                }
            }
            else
            {
                InitializeSpendMoneyDeatilsPanelComponents();
                MessageBox.Show("手机号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_spendMoneyQueryPhone.Focus();
            }
        }

        //会员消费界面中，消费按钮Click事件。
        private void Btn_spendMoneySpend_Click(object sender, EventArgs e)
        {
            UpdateMoneyBLL updateMoneyBLL = new UpdateMoneyBLL();
            VIPInfo originVIP;
            string phone = Txt_spendMoneyQueryPhone.Text;
            string name = Lab_spendMoneyName.Text;
            decimal spendMoney = Nudown_spendMoneyNumber.Value;
            originVIP = updateMoneyBLL.QueryVIPByPhone(phone, path);
            if (spendMoney != 0.0M)
            {
                DialogResult dr = MessageBox.Show("是否要为用户：" + name + "，手机号：" + phone + "，消费金额：" + spendMoney + "元？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (updateMoneyBLL.UpdateVIPBalance(originVIP, -spendMoney, path))
                    {
                        Lab_spendMoneyBalance.Text = originVIP.Balance.ToString();
                        MessageBox.Show("消费成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("充值失败，原因未知，请联系开发人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                   
                }
                else
                {
                    Nudown_spendMoneyNumber.Focus();
                }
            }
            else
            {
                MessageBox.Show("请输入要消费的金额！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Nudown_spendMoneyNumber.Focus();
            }
        }

        /// <summary>
        /// 说明：初始化添加会员界面的所有组件，包括初始化姓名和手机号的文本框为空文本、性别单选框默认为男、充入金额为0。
        /// </summary>
        private void InitializeAddVIPPanelComponents()
        {
            Txt_addName.Text = "";
            Txt_addPhone.Text = "";
            Rbtn_male.Checked = true;
            Nudown_addMoney.Value = 0;
        }

        /// <summary>
        /// 说明：初始化查询会员界面的所有组件，包括姓名和手机号的文本框为空文本、VIP数据表格显示所有VIP、调整表格的默认样式。
        /// </summary>
        private void InitializeQueryVIPPanelComponents()
        {
            DataTable VIPDataTable;
            QueryVIPBLL queryVIPBLL = new QueryVIPBLL();
            //初始化控件
            Txt_queryName.Text = "";
            Txt_queryPhone.Text = "";
            //查询所有VIP用户
            VIPDataTable = queryVIPBLL.ShowAllVIPs(path);
            //将表格绑定在DataGridView控件上
            Dgv_VIPInfo.DataSource = VIPDataTable;
            //修改表格样式           
            for (int i = 0; i < Dgv_VIPInfo.Columns.Count; i++)
            {
                Dgv_VIPInfo.Columns[i].Width = 200;
                Dgv_VIPInfo.Columns[i].ReadOnly = true;
                Dgv_VIPInfo.Columns[i].Resizable = DataGridViewTriState.False;
                Dgv_VIPInfo.Columns[i].DefaultCellStyle.Font = new Font("宋体", 14, FontStyle.Regular);
                Dgv_VIPInfo.Columns[i].DefaultCellStyle.BackColor = Color.Lime;
            }
        }

        /// <summary>
        /// 说明：初始化会员充值界面的所有组件，包括手机号文本框为空文本，信息标签为空文本，充入金额为0。
        /// </summary>
        private void InitializeRechargeMoneyPanelComponents()
        {
            Pl_rechargeMoneyDetails.Visible = false;
            Txt_rechargeMoneyQueryPhone.Text = "";
            Lab_chargeMoneyName.Text = "";
            Lab_chargeMoneySex.Text = "";
            Lab_chargeMoneyBalance.Text = "";
            Lab_chargeMoneyTotal.Text = "";
            Lab_chargeMoneyDraw.Text = "";
            Nudown_rechargeMoneyNumber.Value = 0.0M;
        }

        /// <summary>
        /// 说明：初始化会员充值界面中的显示会员细节界面，将全部数据清空并将界面隐藏。
        /// </summary>
        private void InitializeRechargeMoneyDeatilsPanelComponents()
        {
            Pl_rechargeMoneyDetails.Visible = false;
            Lab_chargeMoneyName.Text = "";
            Lab_chargeMoneySex.Text = "";
            Lab_chargeMoneyBalance.Text = "";
            Lab_chargeMoneyTotal.Text = "";
            Lab_chargeMoneyDraw.Text = "";
            Nudown_rechargeMoneyNumber.Value = 0.0M;
        }

        /// <summary>
        /// 说明：初始化会员消费界面中的所有组件，包括手机号文本框为空文本，信息标签为空文本，消费金额为0。
        /// </summary>
        private void InitializeSpendMoneyPanelComponents()
        {
            Pl_spendMoneyDetails.Visible = false;
            Txt_spendMoneyQueryPhone.Text = "";
            Lab_spendMoneyName.Text = "";
            Lab_spendMoneySex.Text = "";
            Lab_spendMoneyBalance.Text = "";
            Lab_spendMoneyTotal.Text = "";
            Lab_spendMoneyDraw.Text = "";
            Nudown_spendMoneyNumber.Value = 0.0M;
        }

        /// <summary>
        /// 说明：初始化会员充值界面中的显示会员细节界面，将全部数据清空并将界面隐藏。
        /// </summary>
        private void InitializeSpendMoneyDeatilsPanelComponents()
        {
            Pl_spendMoneyDetails.Visible = false;
            Lab_spendMoneyName.Text = "";
            Lab_spendMoneySex.Text = "";
            Lab_spendMoneyBalance.Text = "";
            Lab_spendMoneyTotal.Text = "";
            Lab_spendMoneyDraw.Text = "";
            Nudown_spendMoneyNumber.Value = 0.0M;
        }

    }
}

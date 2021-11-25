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

namespace LingYi_Photography
{
    /// <summary>
    /// 说明：枚举类型变量VIPData，包含手机号、姓名、性别、余额、累积充值和剩余抽奖次数。
    /// </summary>
    enum VIPData
    {
        Phone = 0,
        Name = 1,
        Sex = 2,
        Banlance = 3,
        Total = 4,
        Draw = 5,
    }    
    /// <summary>
    /// 说明：VIPMangement类。
    /// </summary>
    public partial class VIPManagement : Form
    {
        /// <summary>
        /// 说明：Login对象，用于在该窗体激活时根据构造函数保存Login窗体。
        /// </summary>
        private Login login;
        /// <summary>
        /// 说明：StreamWriter对象，用于VIPMangement窗体中数据的写入。
        /// </summary>
        private StreamWriter sw;
        /// <summary>
        /// 说明：StreamReader对象，用于VIPMangement窗体中数据的读取。
        /// </summary>
        private StreamReader sr;
        
        /// <summary>
        /// 说明：VIPManagement类的构造函数。
        /// </summary>
        /// <param name="loginForm">Login窗体的对象，用于保存Login窗体的界面。</param>
        public VIPManagement(Login loginForm)
        {
            login = loginForm;
            InitializeComponent();
        }
        
        /// <summary>
        /// 说明：Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// 说明：FormClosing事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //do something
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

        /// <summary>
        /// 说明：头部框界面中，登出账户按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_logout_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 说明：导航栏界面中，添加会员按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_addVIP_Click(object sender, EventArgs e)
        {
            Btn_Click_Change(Btn_addVIP, Pl_addVIP);
        }

        /// <summary>
        /// 说明：导航栏界面中，查询会员按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_queryVIP_Click(object sender, EventArgs e)
        {
            Btn_Click_Change(Btn_queryVIP, Pl_queryVIP);
        }

        /// <summary>
        /// 说明：导航栏界面中，会员充值按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_addMoney_Click(object sender, EventArgs e)
        {
            Btn_Click_Change(Btn_rechargeMoney, Pl_rechargeMoney);
        }
        
        /// <summary>
        /// 说明：导航栏界面中，会员消费按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_spendMoney_Click(object sender, EventArgs e)
        {
            Btn_Click_Change(Btn_spendMoney, Pl_spendMoney);
        }

        /// <summary>
        /// 说明：重置导航栏内所有按钮的样式并隐藏其对应的界面，之后为点击的按钮设置新的样式并显示其对应的界面。
        /// </summary>
        /// <param name="button">点击的按钮对象</param>
        /// <param name="panel">需要显示的界面</param>
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

        /// <summary>
        /// 说明：添加会员界面中，清空按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_addVIPClear_Click(object sender, EventArgs e)
        {
            InitializeAddVIPPanelComponents();
        }

        /// <summary>
        /// 说明：添加会员界面中，提交按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_addVIPSubmit_Click(object sender, EventArgs e)
        {
            //注册VIP的基本数据
            string name = Txt_addName.Text;
            string phone = Txt_addPhone.Text;
            string sex = Rbtn_male.Checked ? "男" : "女";
            decimal money = Nudown_addMoney.Value;
            int draw;
            //各级别检验结果
            bool dataNameResult = false;
            bool dataPhoneResult = false;
            bool dataResult = false;
            bool dataDBResult = false;          

            //检验会员姓名和手机号
            if (name != "" && phone != "")
            {
                //检验姓名
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] > 127)
                    {
                        dataNameResult = true;
                    }
                    else
                    {
                        dataNameResult = false;
                        break;
                    }
                }
                //检验手机号
                if (phone.Length == 11)
                {
                    for (int i = 0; i < phone.Length; i++)
                    {
                        if (phone[i] >= 48 && phone[i] <= 57)
                        {
                            dataPhoneResult = true;
                        }
                        else
                        {
                            dataPhoneResult = false;
                            break;
                        }
                    }
                }
                //设置最终检验结果
                if (dataNameResult == true && dataPhoneResult == true)
                {
                    dataResult = true;
                }
                else if (dataNameResult == false && dataPhoneResult == true)
                {
                    MessageBox.Show("请输入正确的姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addName.Focus();
                }
                else if (dataNameResult == true && dataPhoneResult == false)
                {
                    MessageBox.Show("请输入正确的手机号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addPhone.Focus();
                }
                else
                {
                    MessageBox.Show("请输入正确的姓名和手机号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_addName.Focus();
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
                string dataCheck;
                string dataCheckPhone;
                sr = new StreamReader(Application.StartupPath + @"\VIPData\VIPInfo.txt");
                dataCheck = sr.ReadLine();
                while (dataCheck != null)
                {
                    dataCheckPhone = dataCheck.Substring(0, 11);
                    if (phone == dataCheckPhone)
                    {
                        MessageBox.Show("该手机号已经被注册！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataDBResult = false;
                        Txt_addPhone.Focus();
                        break;
                    }
                    else
                    {
                        dataCheck = sr.ReadLine();
                        if (dataCheck == null)
                        {
                            dataDBResult = true;
                        }
                    }
                }
                sr.Close();
            }
            //此处将数据录入数据文本
            if (dataDBResult == true)
            {
                string VIPData;
                draw = (int)money / 200 + 1;
                if (draw > 6)
                {
                    draw = 6;
                }
                sw = new StreamWriter(Application.StartupPath + @"\VIPData\VIPInfo.txt", true);
                VIPData = phone + "|" + name + "|" + sex + "|" + money + "|" + money + "|" + draw;
                sw.WriteLine(VIPData);
                sw.Close();
                //注册成功后的后续操作
                InitializeAddVIPPanelComponents();
                MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// 说明：查询会员界面中，查询按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_querySubmit_Click(object sender, EventArgs e)
        {
            string name = Txt_queryName.Text;
            string phone = Txt_queryPhone.Text;
            DataTable VIPDataTable;
            if (name == "" && phone == "")
            { 
                VIPDataTable = QueryAllVIP();
            }
            else if (name != "" && phone == "")
            {
                VIPDataTable = QueryFromData(name, VIPData.Name);
            }
            else if (name == "" && phone != "")
            {
                VIPDataTable = QueryFromData(phone, VIPData.Phone);
            }
            else
            {
                VIPDataTable = QueryFromData(name, VIPData.Name, phone, VIPData.Phone);
            }
            Dgv_VIPInfo.DataSource = VIPDataTable;
        }

        /// <summary>
        /// 说明：会员充值界面中，手机号文本框TextChanged事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_rechargeMoneyQueryPhone_TextChanged(object sender, EventArgs e)
        {
            InitializeRechargeMoneyDeatilsPanelComponents();
        }
        /// <summary>
        /// 说明：会员充值界面中，查询按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_rechargeMoneyQuerySubmit_Click(object sender, EventArgs e)
        {
            string phone = Txt_rechargeMoneyQueryPhone.Text;
            DataTable dataTable;
            if (phone != "")
            {
                if (phone.Length == 11)
                {
                    dataTable = QueryFromData(phone, VIPData.Phone);
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow dataRow = dataTable.Rows[0];
                        Lab_chargeMoneyName.Text = dataRow["姓名"].ToString();
                        Lab_chargeMoneySex.Text = dataRow["性别"].ToString();
                        Lab_chargeMoneyBalance.Text = Convert.ToDecimal(dataRow["余额"]).ToString();
                        Lab_chargeMoneyTotal.Text = Convert.ToDecimal(dataRow["累积充值"]).ToString();
                        Lab_chargeMoneyDraw.Text = Convert.ToInt32(dataRow["剩余抽奖次数"]).ToString();
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
        
        /// <summary>
        /// 说明：会员充值界面中，充值按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_rechargeMoneyRecharge_Click(object sender, EventArgs e)
        {
            string phone = Txt_rechargeMoneyQueryPhone.Text;
            string name = Lab_chargeMoneyName.Text;
            decimal rechargeMoney = Nudown_rechargeMoneyNumber.Value;
            if (rechargeMoney != 0.0M)
            {               
                DialogResult dr = MessageBox.Show("是否要为用户：" + name + "，手机号：" + phone + "，充入金额：" + rechargeMoney + "元？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string dataContent;//用于读取每一行数据，寻找目标数据
                    string[] dataSubContent;//用存储被分隔后的目标数据
                    string changeData = "";
                    string newData = "";
                    decimal newBalance;//新的余额
                    decimal newTotal;//新的累积充值
                    int index = 0;
                    ArrayList dataList = new ArrayList();
                    newBalance = rechargeMoney + Convert.ToDecimal(Lab_chargeMoneyBalance.Text);
                    newTotal = rechargeMoney + Convert.ToDecimal(Lab_chargeMoneyTotal.Text);
                    sr = new StreamReader(Application.StartupPath + @"\VIPData\VIPInfo.txt");
                    dataContent = sr.ReadLine();
                    for (int i = 0; dataContent != null; i++)
                    {
                        string dataPhone = dataContent.Substring(0, 11);
                        dataList.Add(dataContent);
                        if (phone == dataPhone)
                        {
                            index = i;
                            changeData = dataContent;
                        }
                        dataContent = sr.ReadLine();
                    }
                    sr.Close();
                    dataSubContent = changeData.Split('|');
                    dataSubContent[3] = newBalance.ToString();
                    dataSubContent[4] = newTotal.ToString();
                    for (int i = 0; i < dataSubContent.Length; i++)
                    {
                        if (i != dataSubContent.Length - 1)
                        {
                            newData += dataSubContent[i] + "|";
                        }
                        else
                        {
                            newData += dataSubContent[i];
                        }
                    }
                    dataList[index] = newData;
                    sw = new StreamWriter(Application.StartupPath + @"\VIPData\VIPInfo.txt", false);
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        sw.WriteLine(dataList[i]);
                    }
                    sw.Close();
                    Lab_chargeMoneyBalance.Text = newBalance.ToString();
                    Lab_chargeMoneyTotal.Text = newTotal.ToString();
                    MessageBox.Show("充值成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// 说明：会员消费界面中，手机号文本框TextChanged事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_spendMoneyQueryPhone_TextChanged(object sender, EventArgs e)
        {
            InitializeSpendMoneyDeatilsPanelComponents();
        }

        /// <summary>
        /// 说明：会员消费界面中，查询按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_spendMoneyQuerySubmit_Click(object sender, EventArgs e)
        {
            string phone = Txt_spendMoneyQueryPhone.Text;
            DataTable dataTable;
            if (phone != "")
            {
                if (phone.Length == 11)
                {
                    dataTable = QueryFromData(phone, VIPData.Phone);
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow dataRow = dataTable.Rows[0];
                        Lab_spendMoneyName.Text = dataRow["姓名"].ToString();
                        Lab_spendMoneySex.Text = dataRow["性别"].ToString();
                        Lab_spendMoneyBalance.Text = Convert.ToDecimal(dataRow["余额"]).ToString();
                        Lab_spendMoneyTotal.Text = Convert.ToDecimal(dataRow["累积充值"]).ToString();
                        Lab_spendMoneyDraw.Text = Convert.ToInt32(dataRow["剩余抽奖次数"]).ToString();
                        Nudown_spendMoneyNumber.Maximum = Convert.ToDecimal(dataRow["余额"]);
                        Pl_spendMoneyDetails.Visible = true;
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

        /// <summary>
        /// 说明：会员消费界面中，消费按钮Click事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_spendMoneySpend_Click(object sender, EventArgs e)
        {
            string phone = Txt_spendMoneyQueryPhone.Text;
            string name = Lab_spendMoneyName.Text;
            decimal spendMoney = Nudown_spendMoneyNumber.Value;
            if (spendMoney != 0.0M)
            {
                DialogResult dr = MessageBox.Show("是否要为用户：" + name + "，手机号：" + phone + "，消费金额：" + spendMoney + "元？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string dataContent;//用于读取每一行数据，寻找目标数据
                    string[] dataSubContent;//用存储被分隔后的目标数据
                    string changeData = "";
                    string newData = "";
                    decimal newBalance;//新的余额
                    int index = 0;
                    ArrayList dataList = new ArrayList();
                    newBalance = Convert.ToDecimal(Lab_spendMoneyBalance.Text) - spendMoney;
                    sr = new StreamReader(Application.StartupPath + @"\VIPData\VIPInfo.txt");
                    dataContent = sr.ReadLine();
                    for (int i = 0; dataContent != null; i++)
                    {
                        string dataPhone = dataContent.Substring(0, 11);
                        dataList.Add(dataContent);
                        if (phone == dataPhone)
                        {
                            index = i;
                            changeData = dataContent;
                        }
                        dataContent = sr.ReadLine();
                    }
                    sr.Close();
                    dataSubContent = changeData.Split('|');
                    dataSubContent[3] = newBalance.ToString();
                    for (int i = 0; i < dataSubContent.Length; i++)
                    {
                        if (i != dataSubContent.Length - 1)
                        {
                            newData += dataSubContent[i] + "|";
                        }
                        else
                        {
                            newData += dataSubContent[i];
                        }
                    }
                    dataList[index] = newData;
                    sw = new StreamWriter(Application.StartupPath + @"\VIPData\VIPInfo.txt", false);
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        sw.WriteLine(dataList[i]);
                    }
                    sw.Close();
                    Lab_spendMoneyBalance.Text = newBalance.ToString();
                    MessageBox.Show("消费成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //初始化控件
            Txt_queryName.Text = "";
            Txt_queryPhone.Text = "";
            //查询所有VIP用户
            VIPDataTable = QueryAllVIP();
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

        /// <summary>
        /// 说明：根据1个数据查询符合条件的一个或多个VIP用户。目前仅支持通过姓名或手机号查询。
        /// </summary>
        /// <param name="data">查询的具体数据。</param>
        /// <param name="vIPData">查询数据的类型，枚举类型VIPData中的一个。</param>
        /// <returns>返回DataTable类型的对象，对象中包含查询的结果。</returns>
        private DataTable QueryFromData(string data, VIPData vIPData) 
        {
            string dataContent;
            string[] dataSubContent;
            DataTable dataTable;
            dataTable = InitializeTable();
            sr = new StreamReader(Application.StartupPath + @"\VIPData\VIPInfo.txt");
            dataContent = sr.ReadLine();
            //如果传入的参数是姓名，结果不唯一
            if (vIPData == VIPData.Name)
            {
                while (dataContent != null)
                {
                    dataSubContent = dataContent.Split('|');
                    if (data == dataSubContent[1])
                    {
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["姓名"] = dataSubContent[1];
                        dataRow["手机号"] = dataSubContent[0];
                        dataRow["性别"] = dataSubContent[2];
                        dataRow["余额"] = Convert.ToDecimal(dataSubContent[3]);
                        dataRow["累积充值"] = Convert.ToDecimal(dataSubContent[4]);
                        dataRow["剩余抽奖次数"] = Convert.ToInt32(dataSubContent[5]);
                        dataTable.Rows.Add(dataRow);
                        dataContent = sr.ReadLine();
                    }
                    else
                    {
                        dataContent = sr.ReadLine();
                    }
                }
            }
            //如果传入的参数是手机号，结果唯一
            else if (vIPData == VIPData.Phone)
            {
                while (dataContent != null)
                {
                    dataSubContent = dataContent.Split('|');
                    if (data == dataSubContent[0])
                    {
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["姓名"] = dataSubContent[1];
                        dataRow["手机号"] = dataSubContent[0];
                        dataRow["性别"] = dataSubContent[2];
                        dataRow["余额"] = Convert.ToDecimal(dataSubContent[3]);
                        dataRow["累积充值"] = Convert.ToDecimal(dataSubContent[4]);
                        dataRow["剩余抽奖次数"] = Convert.ToInt32(dataSubContent[5]);
                        dataTable.Rows.Add(dataRow);
                        break;
                    }
                    else
                    {
                        dataContent = sr.ReadLine();
                    }
                }
            }
            //其余条件的单个数据查询，此处可用于更多单个条件查询的扩展
            else
            {
                dataTable = QueryAllVIP();
            }
            sr.Close();
            return dataTable;
        }

        /// <summary>
        /// 说明：根据2个数据查询符合条件的一个VIP用户。目前仅支持通过姓名和手机号查询。
        /// </summary>
        /// <param name="name">查询的姓名</param>
        /// <param name="vIPData1">上一个参数的查询数据类型，应该为VIPData.Name</param>
        /// <param name="phone">查询的手机号</param>
        /// <param name="vIPData2">上一个参数的查询数据类型，应该为VIPData.Phone</param>
        /// <returns>返回DataTable类型的对象，对象中包含查询的结果。</returns>
        private DataTable QueryFromData(string name, VIPData vIPData1, string phone, VIPData vIPData2)
        {
            string dataContent;
            string[] dataSubContent;
            DataTable dataTable;
            dataTable = InitializeTable();
            sr = new StreamReader(Application.StartupPath + @"\VIPData\VIPInfo.txt");
            dataContent = sr.ReadLine();
            //如果传入第一个参数是姓名，第二个参数是手机号，结果唯一
            if (vIPData1 == VIPData.Name && vIPData2 == VIPData.Phone)
            {
                while (dataContent != null)
                {
                    dataSubContent = dataContent.Split('|');
                    if (name == dataSubContent[1] && phone == dataSubContent[0])
                    {
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["姓名"] = dataSubContent[1];
                        dataRow["手机号"] = dataSubContent[0];
                        dataRow["性别"] = dataSubContent[2];
                        dataRow["余额"] = Convert.ToDecimal(dataSubContent[3]);
                        dataRow["累积充值"] = Convert.ToDecimal(dataSubContent[4]);
                        dataRow["剩余抽奖次数"] = Convert.ToInt32(dataSubContent[5]);
                        dataTable.Rows.Add(dataRow);
                        break;
                    }
                    else
                    {
                        dataContent = sr.ReadLine();
                    }
                }
            }
            //其余条件的单个数据查询，此处可用于更多单个条件查询的扩展
            else
            {
                dataTable = QueryAllVIP();
            }
            sr.Close();
            return dataTable;
        }

        /// <summary>
        /// 说明：查询数据文本中所有的VIP用户
        /// </summary>
        /// <returns>返回DataTable类型的对象，对象中包含查询的结果。</returns>
        private DataTable QueryAllVIP()
        {
            string dataContent;
            string[] dataSubContent;
            DataTable dataTable;
            //根据数据文本初始化表格
            dataTable = InitializeTable();
            //读取数据文本并存入DataTable对象
            sr = new StreamReader(Application.StartupPath + @"\VIPData\VIPInfo.txt");
            dataContent = sr.ReadLine();
            while (dataContent != null)
            {
                DataRow dataRow = dataTable.NewRow();
                dataSubContent = dataContent.Split('|');
                dataRow["姓名"] = dataSubContent[1];
                dataRow["手机号"] = dataSubContent[0];
                dataRow["性别"] = dataSubContent[2];
                dataRow["余额"] = Convert.ToDecimal(dataSubContent[3]);
                dataRow["累积充值"] = Convert.ToDecimal(dataSubContent[4]);
                dataRow["剩余抽奖次数"] = Convert.ToInt32(dataSubContent[5]);
                dataTable.Rows.Add(dataRow);
                dataContent = sr.ReadLine();
            }
            sr.Close();
            return dataTable;
        }

        /// <summary>
        /// 说明：获取一个被固定初始化的DataTable对象，该对象包含六列（姓名，手机号，性别，余额，累积充值，剩余抽奖次数）。
        /// </summary>
        /// <returns>返回DataTable类型的对象，对象的列被初始化，内容为空。</returns>
        private DataTable InitializeTable()
        {
            DataTable dataTable = new DataTable();
            //为表格定义列和数据类型
            dataTable.Columns.Add("姓名", Type.GetType("System.String"));
            dataTable.Columns.Add("手机号", Type.GetType("System.String"));
            dataTable.Columns.Add("性别", Type.GetType("System.String"));
            dataTable.Columns.Add("余额", Type.GetType("System.Decimal"));
            dataTable.Columns.Add("累积充值", Type.GetType("System.Decimal"));
            dataTable.Columns.Add("剩余抽奖次数", Type.GetType("System.Int32"));
            return dataTable;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.VIP
{
    /// <summary>
    /// 说明：VIPInfo类主要用于记录会员的信息。
    /// 会员数据结构为：手机号|姓名|性别|余额|累积充值|剩余抽奖次数。
    /// 手机号、姓名、性别为string数据类型；余额、累积充值为decimal数据类型；剩余抽奖次数为int数据类型。
    /// </summary>
    public class VIPInfo
    {
        private string name;
        private string phone;
        private string sex;
        private decimal balance;
        private decimal total;
        private int draw;

        /// <summary>
        /// 说明：获取或设置会员姓名属性。
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// 说明：获取或设置会员手机号属性。
        /// </summary>
        public string Phone { get => phone; set => phone = value; }

        /// <summary>
        /// 说明：获取或设置会员性别属性。
        /// </summary>
        public string Sex { get => sex; set => sex = value; }

        /// <summary>
        /// 说明：获取或设置会员余额属性。
        /// </summary>
        public decimal Balance { get => balance; set => balance = value; }

        /// /// <summary>
        /// 说明：获取或设置会员累积充值属性。
        /// </summary>
        public decimal Total { get => total; set => total = value; }
        
        /// <summary>
        /// 说明：获取或设置会员剩余抽奖次数属性。
        /// </summary>
        public int Draw { get => draw; set => draw = value; }

        /// <summary>
        /// 说明：VIPInfo类的默认构造函数，所有数据将使用默认值。
        /// </summary>
        public VIPInfo()
        {
            Name = "";
            Phone = "";
            Sex = "";
            Balance = 0.0M;
            Total = 0.0M;
            Draw = 0;
        }

        /// <summary>
        /// 说明：VIPInfo类的完整构造函数，包含所有数据的值。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <param name="phone">会员手机号</param>
        /// <param name="sex">会员性别</param>
        /// <param name="balance">会员余额</param>
        /// <param name="total">会员累积充值</param>
        /// <param name="draw">会员剩余抽奖次数</param>
        public VIPInfo(string name, string phone, string sex, decimal balance, decimal total, int draw)
        {
            Name = name;
            Phone = phone;
            Sex = sex;
            Balance = balance;
            Total = total;
            Draw = draw;
        }
        
    }
}

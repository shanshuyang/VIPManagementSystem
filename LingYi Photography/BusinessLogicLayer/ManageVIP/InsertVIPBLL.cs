using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.VIP;
using DataAccessLayer;

namespace BusinessLogicLayer.ManageVIP
{
    public class InsertVIPBLL
    {
        /// <summary>
        /// 说明：验证新会员的姓名和手机号是否符合标准。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <param name="phone">会员手机号</param>
        /// <returns>如果数据验证成功返回0，姓名验证失败返回1，手机号验证失败返回2，两个都验证失败则返回3。</returns>
        public int VerifiedNewVIPData(string name, string phone)
        {
            bool resultName = VerifiedVIPData.VerifiedVIPName(name);
            bool resultPhone = VerifiedVIPData.VerifiedVIPPhone(phone);
            if (resultName == true && resultPhone == true)
            {
                return 0;
            }
            else if (resultName == false && resultPhone == true)
            {
                return 1;
            }
            else if (resultName == true && resultPhone == false)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        /// <summary>
        /// 说明：根据路径验证数据库中是否存在此会员。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <param name="path">路径</param>
        /// <returns>如果存在返回true，不存在则返回false。</returns>
        public bool IsNewVIPExist(string phone, string path)
        {
            VIPInfo vipInfo = new VIPInfo
            {
                Phone = phone
            };
            bool executeResult = VIPInfoDAL.QueryVIPExist(vipInfo, path);
            return executeResult;
        }

        /// <summary>
        /// 说明：根据路径执行插入新会员。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <param name="phone">会员手机号</param>
        /// <param name="sex">会员性别</param>
        /// <param name="balance">会员余额</param>
        /// <param name="total">会员累积充值</param>
        /// <param name="path">路径</param>
        /// <returns>如果插入成功返回true，否则返回false。</returns>
        public bool InsertNewVIP(string name, string phone, string sex, decimal balance, decimal total, string path)
        {
            bool result;
            int draw = (int)total / 200 + 1;
            if (draw > 6)
            {
                draw = 6;
            }
            VIPInfo vipInfo = new VIPInfo(name, phone, sex, balance, total, draw);
            result = VIPInfoDAL.InsertVIP(vipInfo, path);
            return result;
        }

    }
}

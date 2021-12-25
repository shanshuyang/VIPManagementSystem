using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.VIP;
using DataAccessLayer;

namespace BusinessLogicLayer.ManageVIP
{
    public class UpdateMoneyBLL
    {
        /// <summary>
        /// 说明：根据路径和手机号查询会员。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <param name="path">路径</param>
        /// <returns>如果会员存在返回会员数据，不存在则返回null。</returns>
        public VIPInfo QueryVIPByPhone(string phone, string path)
        {
            VIPInfo vip = VIPInfoDAL.QueryVIPByPhone(phone, path);
            return vip;
        }

        /// <summary>
        /// 说明：根据路径和额外的钱更新会员余额。
        /// </summary>
        /// <param name="vipInfo">VIPInfo类型对象</param>
        /// <param name="extraMoney">额外的前，正数增加，负数减少。</param>
        /// <param name="path">路径</param>
        /// <returns>如果成功返回true，失败则返回false。</returns>
        public bool UpdateVIPBalance(VIPInfo vipInfo, decimal extraMoney, string path)
        {
            if (extraMoney > 0)
            {
                vipInfo.Balance += extraMoney;
                vipInfo.Total += extraMoney;
            }
            else
            {
                vipInfo.Balance += extraMoney;
            }
            return VIPInfoDAL.UpdateVIP(vipInfo, path);
        }
        /// <summary>
        /// 说明：检验手机号是否是11位。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <returns>如果验证通过返回true，验证不通过则返回false。</returns>
        public bool VerifiedQueryPhone(string phone)
        {
            return VerifiedVIPData.VerifiedVIPPhone(phone);
        }
    }
}

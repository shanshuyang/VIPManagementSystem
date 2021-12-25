using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.VIP;
using DataAccessLayer;

namespace BusinessLogicLayer.ManageVIP
{
    public class VerifiedVIPData
    {
        /// <summary>
        /// 说明：验证会员姓名是否是中文名。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <returns>如果验证成功返回true，验证失败则返回false。</returns>
        public static bool VerifiedVIPName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] < 127)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 说明：验证会员手机号是否是11位数字。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <returns>如果验证成功返回true，验证失败则返回false。</returns>
        public static bool VerifiedVIPPhone(string phone)
        {
            if (phone.Length == 11)
            {
                for (int i = 0; i < phone.Length; i++)
                {
                    if (phone[i] < 48 && phone[i] > 57)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtil.VIPHelper;
using Model.VIP;

namespace DataAccessLayer
{ 
    public class VIPInfoDAL
    {
        /// <summary>
        /// 说明：根据路径查询数据库中是否有满足条件的会员。
        /// </summary>
        /// <param name="vipInfo">VIPInfo类型变量，变量的姓名和手机号属性不能同时为空</param>
        /// <param name="path">路径</param>
        /// <returns>如果有相匹配的数据返回true，没有则返回false。</returns>
        public static bool QueryVIPExist(VIPInfo vipInfo, string path) 
        {
            VIPHelper vipHelper = new VIPHelper();
            string phone = vipInfo.Phone;
            string name = vipInfo.Name;
            bool executeResult;
            if (!string.IsNullOrEmpty(vipInfo.Phone))
            {
                executeResult = vipHelper.QueryVIPByPhone(phone, path) != null;
            }
            else if (!string.IsNullOrEmpty(vipInfo.Name))
            {
                executeResult = vipHelper.QueryVIPByName(name, path) != null;
            }
            else
            {
                executeResult = false;
            }
            return executeResult;
        }

        /// <summary>
        /// 说明：根据路径向数据库插入一条数据。
        /// </summary>
        /// <param name="vipInfo">VIPInfo类型变量，变量中记录了需要添加的会员的信息</param>
        /// <param name="path">路径</param>
        /// <returns>如果添加成功返回true，否则返回false。</returns>
        public static bool InsertVIP(VIPInfo vipInfo, string path)
        {
            VIPHelper vipHelper = new VIPHelper();
            string vipData;
            bool executeResult;
            vipData = vipInfo.Phone + "|" + vipInfo.Name + "|" + vipInfo.Sex + "|" + vipInfo.Balance + "|" + vipInfo.Total + "|" + vipInfo.Draw;
            executeResult = vipHelper.InsertVIP(vipData, path);
            return executeResult;
        }

        /// <summary>
        /// 说明：根据路径和手机号查询数据并返回。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <param name="path">路径</param>
        /// <returns>如果数据存在返回VIPInfo对象，如果不存在则返回null。</returns>
        public static VIPInfo QueryVIPByPhone(string phone, string path)
        {
            VIPInfo vipInfo = null;
            VIPHelper vipHelper = new VIPHelper();
            string vipData = vipHelper.QueryVIPByPhone(phone, path);
            if (vipData != null)
            {
                string[] vipDataSubcontent = vipData.Split('|');
                vipInfo = new VIPInfo(vipDataSubcontent[1], vipDataSubcontent[0], vipDataSubcontent[2], Convert.ToDecimal(vipDataSubcontent[3]), Convert.ToDecimal(vipDataSubcontent[4]), Convert.ToInt32(vipDataSubcontent[5]));
            }
            return vipInfo;
        }

        /// <summary>
        /// 说明：根据路径和姓名查询数据并返回。
        /// </summary>
        /// <param name="phone">会员姓名</param>
        /// <param name="path">路径</param>
        /// <returns>如果数据存在返回VIPInfo数组变量，如果不存在则返回null。</returns>
        public static VIPInfo[] QueryVIPWithName(string name, string path)
        {
            VIPInfo[] vipsInfo;
            ArrayList vipList;
            VIPHelper vipHelper = new VIPHelper();
            vipList = vipHelper.QueryVIPByName(name, path);
            vipsInfo = new VIPInfo[vipList.Count];
            if (vipList != null)
            {
                for (int i = 0; i < vipList.Count; i++)
                {
                    string[] vipDataSubcontent = vipList[i].ToString().Split('|');
                    vipsInfo[i] = new VIPInfo(vipDataSubcontent[1], vipDataSubcontent[0], vipDataSubcontent[2], Convert.ToDecimal(vipDataSubcontent[3]), Convert.ToDecimal(vipDataSubcontent[4]), Convert.ToInt32(vipDataSubcontent[5]));
                }
            }
            return vipsInfo;
        }

        /// <summary>
        /// 说明：根据路径查询所有数据并返回。
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>如果数据存在返回VIPInfo数组变量，如果不存在则返回null。</returns>
        public static VIPInfo[] QueryAllVIPs(string path)
        {
            VIPInfo[] vipsInfo;
            ArrayList vipList;
            VIPHelper vipHelper = new VIPHelper();
            vipList = vipHelper.QueryAllVIPs(path);
            vipsInfo = new VIPInfo[vipList.Count];
            if (vipList != null)
            {
                for (int i = 0; i < vipList.Count; i++)
                {
                    string[] vipDataSubcontent = vipList[i].ToString().Split('|');
                    vipsInfo[i] = new VIPInfo(vipDataSubcontent[1], vipDataSubcontent[0], vipDataSubcontent[2], Convert.ToDecimal(vipDataSubcontent[3]), Convert.ToDecimal(vipDataSubcontent[4]), Convert.ToInt32(vipDataSubcontent[5]));

                }
            }
            return vipsInfo;
        }

        /// <summary>
        /// 说明：根据路径和数据更新数据库中相匹配的数据，默认以手机号为匹配方式。
        /// </summary>
        /// <param name="vipInfo"></param>
        /// <param name="path"></param>
        /// <returns>如果更新成功返回true，失败则返回false。</returns>
        public static bool UpdateVIP(VIPInfo vipInfo, string path)
        {
            VIPHelper vipHelper = new VIPHelper();
            string newVIPData = vipInfo.Phone + "|" + vipInfo.Name + "|" + vipInfo.Sex + "|" + vipInfo.Balance + "|" + vipInfo.Total + "|" + vipInfo.Draw;
            return vipHelper.UpdateVIP(newVIPData, path);
        }

    }
}

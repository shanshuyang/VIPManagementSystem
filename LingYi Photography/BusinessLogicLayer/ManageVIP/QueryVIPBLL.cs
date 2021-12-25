using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.VIP;
using BusinessLogicLayer.ManageVIP;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer.ManageVIP
{
    public class QueryVIPBLL
    {
        /// <summary>
        /// 说明：根据路径查询所有会员的数据。
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>返回DataTable类型变量，其中包含所有会员数据。</returns>
        public DataTable ShowAllVIPs(string path)
        {
            VIPInfo[] vips = VIPInfoDAL.QueryAllVIPs(path);
            DataTable dataTable = InitializedVIPTable();
            foreach (VIPInfo vip in vips)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["姓名"] = vip.Name;
                dataRow["手机号"] = vip.Phone;
                dataRow["性别"] = vip.Sex;
                dataRow["余额"] = vip.Balance;
                dataRow["累积充值"] = vip.Total;
                dataRow["剩余抽奖次数"] = vip.Draw;
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;           
        }

        /// <summary>
        /// 说明：根据路径和手机号查询相匹配的会员数据。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <param name="path">路径</param>
        /// <returns>返回DataTable类型变量。</returns>
        public DataTable ShowVIPWithPhone(string phone, string path)
        {
            VIPInfo vipInfo = VIPInfoDAL.QueryVIPByPhone(phone, path);
            DataTable dataTable = InitializedVIPTable();
            if (vipInfo != null)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["姓名"] = vipInfo.Name;
                dataRow["手机号"] = vipInfo.Phone;
                dataRow["性别"] = vipInfo.Sex;
                dataRow["余额"] = vipInfo.Balance;
                dataRow["累积充值"] = vipInfo.Total;
                dataRow["剩余抽奖次数"] = vipInfo.Draw;
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        /// <summary>
        /// 说明：根据路径和姓名查询相匹配的会员数据。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <param name="path">路径</param>
        /// <returns>返回DataTable类型变量。</returns>
        public DataTable ShowVIPWithName(string name, string path)
        {
            VIPInfo[] vips = VIPInfoDAL.QueryVIPWithName(name, path);
            DataTable dataTable = InitializedVIPTable();
            if (vips.Length > 0)
            {
                foreach (VIPInfo vip in vips)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["姓名"] = vip.Name;
                    dataRow["手机号"] = vip.Phone;
                    dataRow["性别"] = vip.Sex;
                    dataRow["余额"] = vip.Balance;
                    dataRow["累积充值"] = vip.Total;
                    dataRow["剩余抽奖次数"] = vip.Draw;
                    dataTable.Rows.Add(dataRow);
                }
            }
            return dataTable;
        }

        /// <summary>
        /// 说明：初始化DataTable类型变量，使其格式符合会员数据。
        /// </summary>
        /// <returns>返回DataTable类型变量。</returns>
        public DataTable InitializedVIPTable()
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

        /// <summary>
        /// 说明：检验手机号是否是11位。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <returns>如果验证通过返回true，验证不通过则返回false。</returns>
        public bool VerifiedQueryPhone(string phone)
        {
            return VerifiedVIPData.VerifiedVIPPhone(phone);
        }

        /// <summary>
        /// 说明：检验姓名是否是中文名。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <returns>如果验证通过返回true，验证不通过则返回false。</returns>
        public bool VerifiedQueryName(string name)
        {
            return VerifiedVIPData.VerifiedVIPName(name);
        }

    }
}

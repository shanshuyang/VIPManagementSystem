using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil.VIPHelper
{
    //protected FileStream fs;
    //protected StreamReader sr;
    //protected StreamWriter sw;
    //protected string dataBaseRow;//存储数据库某行数据
    //protected ArrayList dataBaseAllRows;//存储数据库所有数据
    //protected string[] dataBaseRowSubcontent;//存储数据库某行的子内容
    //protected int index;//记录索引
    //protected string targetData;//存储目标数据
    //protected ArrayList targetAllData;//存储多个目标数据
    //protected string[] targetDataSubcontent;//存储目标数据子内容
    //protected bool executeResult;//记录执行数据库操作的结果
    //VIP数据格式：手机号|姓名|性别|余额|累积充值|剩余抽奖次数
    public class VIPHelper : BaseHelper
    {
        public VIPHelper()
        {
            InitializeHelper();
        }
        /// <summary>
        /// 说明：根据特定Helper类初始化
        /// </summary>
        protected override void InitializeHelper()
        {
            sr = null;
            sw = null;
            dataBaseRow = null;
            dataBaseAllRows = new ArrayList(); ;
            dataBaseRowSubcontent = new string[6];
            index = -1;
            targetData = null;
            targetAllData = new ArrayList();
            targetDataSubcontent = new string[6];
            executeResult = false;
        }
        /// <summary>
        /// 通过手机号查询VIP是否存在。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果存在返回true，否则返回false。</returns>
        public bool QueryVIPExistByPhone(string phone, string path)
        {
            InitializeHelper();
            using (sr = new StreamReader(path))
            {
                while ((dataBaseRow = sr.ReadLine()) != null)
                {
                    dataBaseRowSubcontent = dataBaseRow.Split('|');
                    if (dataBaseRowSubcontent[0].Equals(phone))
                    {
                        sr.Close();
                        executeResult = true;
                        break;
                    }
                }
            }
            return executeResult;
        }
        /// <summary>
        /// 通过姓名查询VIP是否存在。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果存在返回true，否则返回false。</returns>
        public bool QueryVIPExistByName(string name, string path)
        {
            InitializeHelper();
            using (sr = new StreamReader(path))
            {
                while ((dataBaseRow = sr.ReadLine()) != null)
                {
                    dataBaseRowSubcontent = dataBaseRow.Split('|');
                    if (dataBaseRowSubcontent[1].Equals(name))
                    {
                        sr.Close();
                        executeResult = true;
                        break;
                    }
                }
            }
            return executeResult;
        }
        /// <summary>
        /// 通过手机号查询VIP信息。
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果查询到返回会员信息，否则返回null。</returns>
        public string QueryVIPByPhone(string phone, string path)
        {
            InitializeHelper();
            using (sr = new StreamReader(path))
            {
                while ((dataBaseRow = sr.ReadLine()) != null)
                {
                    dataBaseRowSubcontent = dataBaseRow.Split('|');
                    if (dataBaseRowSubcontent[0].Equals(phone))
                    {
                        sr.Close();
                        targetData = dataBaseRow;
                        break;
                    }
                }
            }
            return targetData;
        }
        /// <summary>
        /// 通过姓名查询VIP信息。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果查询到返回会员信息数组列表，否则返回null。</returns>
        public ArrayList QueryVIPByName(string name, string path)
        {
            InitializeHelper();
            using (sr = new StreamReader(path))
            {
                while ((dataBaseRow = sr.ReadLine()) != null)
                {
                    dataBaseRowSubcontent = dataBaseRow.Split('|');
                    if (dataBaseRowSubcontent[1].Equals(name))
                    {
                        targetAllData.Add(dataBaseRow);
                    }
                }
                sr.Close();
            }
            return targetAllData.Count > 0 ? targetAllData : null;
        }
        /// <summary>
        /// 查询所有会员信息。
        /// </summary>
        /// <param name="path">查询路径</param>
        /// <returns>如果查询到返回会员信息数组列表，否则返回null。</returns>
        public ArrayList QueryAllVIPs(string path)
        {
            InitializeHelper();
            using (sr = new StreamReader(path))
            {
                while ((dataBaseRow = sr.ReadLine()) != null)
                {
                    targetAllData.Add(dataBaseRow);
                }
                sr.Close();
            }
            return targetAllData.Count > 0 ? targetAllData : null;
        }
        /// <summary>
        /// 添加一个VIP。
        /// </summary>
        /// <param name="vipInfo">VIP信息</param>
        /// <param name="path">添加路径</param>
        /// <returns>添加成功返回true，否则返回false。</returns>
        public bool InsertVIP(string vipInfo, string path)
        {
            InitializeHelper();
            using (sw = new StreamWriter(path, true))
            {
                try
                {
                    sw.WriteLine(vipInfo);
                    executeResult = true;
                }
                catch
                {
                    executeResult = false;
                }
                finally
                {
                    sw.Close();
                }
            }
            return executeResult;
        }
        /*
        public bool DeleteVIP(string phone, string path)
        {
            InitializeHelper();
        }
        */
        /// <summary>
        /// 更新VIP信息。
        /// </summary>
        /// <param name="vipInfo">待更新的VIP信息</param>
        /// <param name="path">更新路径</param>
        /// <returns>如果更新成功返回true，否则返回false。</returns>
        public bool UpdateVIP(string vipInfo, string path)
        {
            InitializeHelper();
            dataBaseAllRows = QueryAllVIPs(path);
            targetAllData = new ArrayList();//由于调用QueryAllVIPs方法后targetAllData以存储所有数据，所以要重新初始化。
            targetData = vipInfo;
            targetDataSubcontent = targetData.Split('|');
            for (int i = 0; i < dataBaseAllRows.Count; i++)
            {
                dataBaseRow = dataBaseAllRows[i].ToString();
                dataBaseRowSubcontent = dataBaseRow.Split('|');
                if (dataBaseRowSubcontent[0].Equals(targetDataSubcontent[0]))
                {
                    index = i;
                    targetAllData.Add(targetData);
                }
                else
                {
                    targetAllData.Add(dataBaseRow);
                }
            }
            if (index > -1)
            {
                using (sw = new StreamWriter(path, false))
                {
                    try
                    {
                        foreach (string data in targetAllData)
                        {
                            sw.WriteLine(data);
                        }
                        executeResult = true;
                    }
                    catch
                    {
                        executeResult = false;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            return executeResult;   
        }
    }
}

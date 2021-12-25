using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtil;

namespace DBUtil.Administrator
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
    //Administrator数据格式：用户名|密码|权限等级|管理权限|添加会员权限|查询会员权限|会员充值权限|会员消费权限
    public class AdministratorHelper : BaseHelper
    {
        public AdministratorHelper()
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
            dataBaseAllRows = new ArrayList();
            dataBaseRowSubcontent = new string[8];
            index = -1;
            targetData = null;
            targetAllData = new ArrayList();
            targetDataSubcontent = new string[8];
            executeResult = false;
        }
        /// <summary>
        /// 查询管理员是否存在。
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果存在返回true，否则返回false。</returns>
        public bool QueryAdministratorExist(string name, string path)
        {
            InitializeHelper();
            using (sr = new StreamReader(path))
            {
                while ((dataBaseRow = sr.ReadLine()) != null)
                {
                    dataBaseRowSubcontent = dataBaseRow.Split('|');
                    if (dataBaseRowSubcontent[0].Equals(name))
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
        /// 查询并返回管理员的数据。
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果存在返回管理员信息，否则返回null。</returns>
        public string QueryAdministrator(string name, string path)
        {
            InitializeHelper();
            using (sr = new StreamReader(path))
            {
                while ((dataBaseRow = sr.ReadLine()) != null)
                {
                    dataBaseRowSubcontent = dataBaseRow.Split('|');
                    if (dataBaseRowSubcontent[0].Equals(name))
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
        /// 查询并返回所有管理员信息。
        /// </summary>
        /// <param name="path">查询路径</param>
        /// <returns>如果查询成功则返回存有所有管理员信息的数组列表，查询失败则返回null。</returns>
        public ArrayList QueryAllAdministrators(string path)
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
        /*
        public bool InsertAdministrator()
        {            
        }

        public bool DeleteAdministrator()
        { }

        public bool UpdateAdministrator()
        { }

        public bool UpdateManyAdministrators()
        { }
        */
    }
}

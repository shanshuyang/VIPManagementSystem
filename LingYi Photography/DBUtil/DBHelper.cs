
//已不再使用，内容可供参考。
/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBUtil
{
    /// <summary>
    /// 说明：DBHelper类封装了查询数据库的方法。
    /// </summary>
    public class DBHelper
    {
        private StreamReader sr;
        private StreamWriter sw;
        private ArrayList dataContents;//读取所有的数据，数组下每个数据都是数据库中的一条原始数据
        private string dataContent;//读取一行的数据内容
        private string[] dataSubContent;//解析读取一行的数据内容，数组下每个数据都是一行数据中的部分内容
        private int index;//指示特定行数的索引
        private string specifiedContent;//记录特定的数据
        private string[] specifiedSubContent;//解析特定的数据

        /// <summary>
        /// 说明：每次查询前引用以初始化对象
        /// </summary>
        public void Initialized()
        {
            sr = null;
            sw = null;
            dataContents = null;
            dataContent = null;
            dataSubContent = null;
            index = -1;
            specifiedContent = null;
            specifiedSubContent = null;
        }

        /// <summary>
        /// 说明：根据路径查询管理员账户和密码是否匹配。
        /// </summary>
        /// <param name="username">账户</param>
        /// <param name="password">密码</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果匹配返回true，不匹配或者用户名不存在则返回false。</returns>
        public bool QueryAdministrator(string username, string password, string path)
        {
            Initialized();
            sr = new StreamReader(path);
            dataContent = sr.ReadLine();
            for (int i = 0; dataContent != null; i++)
            {
                dataSubContent = dataContent.Split('|');
                if (dataSubContent[0] == username && dataSubContent[1] == password)
                {
                    sr.Close();
                    return true;
                }
                else
                {
                    dataContent = sr.ReadLine();
                }                
            }
            sr.Close();
            return false;
        }

        /// <summary>
        /// 说明：根据路径查找并返回与管理员账户相匹配的管理员信息。
        /// </summary>
        /// <param name="username">账户</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果账户存在则返回一个string类型的数组，其中记录了管理员信息，数据结构为：
        /// 用户名|密码|权限等级|管理权限|添加会员权限|查询会员权限|会员充值权限|会员消费权限
        /// 否则返回一个引用为null的数组</returns>
        public string[] GetAdministrator(string username, string path)
        {
            Initialized();
            sr = new StreamReader(path);
            dataContent = sr.ReadLine();
            for (int i = 0; dataContent != null; i++)
            {
                dataSubContent = dataContent.Split('|');
                if (dataSubContent[0] == username)
                {
                    specifiedContent = dataContent;
                    specifiedSubContent = specifiedContent.Split('|');
                    index = i;
                    break;
                }
                else
                {
                    dataContent = sr.ReadLine();
                }
            }
            sr.Close();
            return specifiedSubContent;//由于初始化，匹配到则返回数组；没有匹配到则返回null。
        }

        /// <summary>
        /// 说明：根据路径和手机号查询会员是否存在。
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns>如果会员存在返回true，如果会员不存在则返回false。</returns>
        public bool QueryVIPWithPhone(string phone, string path)
        {
            Initialized();
            sr = new StreamReader(path);
            dataContent = sr.ReadLine();
            for (int i = 0; dataContent != null; i++)
            {
                dataSubContent = dataContent.Split('|');
                if (phone == dataSubContent[0])
                {
                    sr.Close();
                    return true;
                }
                else
                {
                    dataContent = sr.ReadLine();
                }
            }
            sr.Close();
            return false;
        }

        /// <summary>
        /// 说明：根据路径和姓名查询会员是否存在。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns>如果会员存在返回true，如果会员不存在则返回false。</returns>
        public bool QueryVIPWithName(string name, string path)
        {
            Initialized();
            sr = new StreamReader(path);
            dataContent = sr.ReadLine();
            for (int i = 0; dataContent != null; i++)
            {
                dataSubContent = dataContent.Split('|');
                if (name == dataSubContent[1])
                {
                    sr.Close();
                    return true;
                }
                else
                {
                    dataContent = sr.ReadLine();
                }
            }
            sr.Close();
            return false;
        }
                
        /// <summary>
        /// 说明：根据路径向会员数据库插入一条数据。
        /// </summary>
        /// <param name="data">会员数据</param>
        /// <param name="path">路径</param>
        /// <returns>如果插入成功返回true，如果发生异常则返回false。</returns>
        public bool InsertVIP(string data, string path)
        {
            Initialized();
            try
            {
                sw = new StreamWriter(path, true);
                sw.WriteLine(data);
                sw.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 说明：通过路径和手机号从数据库中获取相匹配的一条会员数据
        /// </summary>
        /// <param name="phone">会员手机号</param>
        /// <param name="path">路径</param>
        /// <returns>返回string类型的数组变量，其中记录了查询到的数据，如果没有相匹配的则返回null。</returns>
        public string[] GetVIPWithPhone(string phone, string path)
        {
            Initialized();
            sr = new StreamReader(path);
            dataContent = sr.ReadLine();
            for (int i = 0; dataContent != null; i++)
            {
                dataSubContent = dataContent.Split('|');
                if (phone == dataSubContent[0])
                {
                    return dataSubContent;
                }
                else
                {
                    dataContent = sr.ReadLine();
                }
            }
            sr.Close();
            return null; 
        }

        /// <summary>
        /// 说明：通过路径和姓名从数据库中获取相匹配的所有会员数据。
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <param name="path">路径</param>
        /// <returns>返回ArrayList类型变量，其中记录了查询到的数据，如果没有匹配到则返回null。</returns>
        public ArrayList GetVIPWithName(string name, string path)
        {
            Initialized();
            ArrayList vipList = new ArrayList();
            sr = new StreamReader(path);
            dataContent = sr.ReadLine();
            for (int i = 0; dataContent != null; i++)
            {
                dataSubContent = dataContent.Split('|');
                if (name == dataSubContent[1])
                {
                    vipList.Add(dataSubContent);
                    dataContent = sr.ReadLine();
                }
                else
                {
                    dataContent = sr.ReadLine();
                }
            }
            sr.Close();
            return vipList;
        }

        /// <summary>
        /// 说明，根据路径返回数据库中的所有数据。
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>返回ArrayList类型变量，其中记录了所有的数据。</returns>
        public ArrayList GetAllVIP(string path)
        {
            Initialized();
            ArrayList vipsList = new ArrayList();
            sr = new StreamReader(path);
            dataContent = sr.ReadLine();
            for (int i = 0; dataContent != null; i++)
            {
                dataSubContent = dataContent.Split('|');
                vipsList.Add(dataSubContent);
                dataContent = sr.ReadLine();
            }
            sr.Close();
            return vipsList;
        }

        /// <summary>
        /// 说明：根据路径更新数据库中手机号匹配的数据。
        /// </summary>
        /// <param name="newData"></param>
        /// <param name="path"></param>
        /// <returns>更新成功返回true，失败则返回false。</returns>
        public bool UpdateVIP(string newData, string path)
        {
            Initialized();
            //存在一个隐患，异步读写可能会导致记录出现错误；修复思路：更改写入方式为先删除原文件再重新创建并写入。
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite,FileShare.ReadWrite);
            string[] newSubData = newData.Split('|');
            sr = new StreamReader(fs);
            dataContents = new ArrayList();
            dataContent = sr.ReadLine();
            for (int i = 0; dataContent != null; i++)
            {
                dataContents.Add(dataContent);
                dataSubContent = dataContent.Split('|');
                if (newSubData[0] == dataSubContent[0])
                {
                    index = i;
                    dataContent = sr.ReadLine();
                }
                else
                {
                    dataContent = sr.ReadLine();
                }
            }
            sr.Close();
            fs.Close();
            if (index != -1)
            {
                dataContents[index] = newData;
                sw = new StreamWriter(path, false);
                foreach (string data in dataContents)
                {
                    sw.WriteLine(data);
                }
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
*/

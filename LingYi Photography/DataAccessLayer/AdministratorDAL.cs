using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Admin;
using DBUtil.Administrator;

namespace DataAccessLayer
{
    public class AdministratorDAL
    {
        /// <summary>
        /// 验证用户名和密码是否匹配。
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="path">查询路径</param>
        /// <returns>如果相同返回数据库中的管理员信息，如果不同或者管理员不存在则返回null。</returns>
        public static Administrator VerifiedAdministrator(string name, string password, string path)
        {
            Administrator dBAdministrator;
            AdministratorHelper administratorHelper = new AdministratorHelper();
            if (administratorHelper.QueryAdministratorExist(name, path))
            {
                string dBData = administratorHelper.QueryAdministrator(name, path);
                if (dBData != null)
                {
                    string[] dBDataSubcontent = dBData.Split('|');
                    if (password == dBDataSubcontent[1])
                    {
                        if ((PermissionLevel)Convert.ToInt32(dBDataSubcontent[2]) == PermissionLevel.Senior)
                        {
                            dBAdministrator = new SeniorAdministrator(dBDataSubcontent[0]);
                            dBAdministrator = PutDataInAdministrator(dBAdministrator, dBDataSubcontent);
                            return dBAdministrator;

                        }
                        else if ((PermissionLevel)Convert.ToInt32(dBDataSubcontent[2]) == PermissionLevel.Intermediate)
                        {
                            dBAdministrator = new IntermediateAdministrator(dBDataSubcontent[0]);
                            dBAdministrator = PutDataInAdministrator(dBAdministrator, dBDataSubcontent);
                            return dBAdministrator;
                        }
                        else
                        {
                            dBAdministrator = new JuniorAdministrator(dBDataSubcontent[0]);
                            dBAdministrator = PutDataInAdministrator(dBAdministrator, dBDataSubcontent);
                            return dBAdministrator;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private static Administrator PutDataInAdministrator(Administrator administrator, string[] data)
        {
            administrator.Password = data[1];
            administrator.Permission = (PermissionLevel)Convert.ToInt32(data[2]);
            administrator.ManageAdministratorPermission = Convert.ToBoolean(data[3]);
            administrator.AddVIPPermission = Convert.ToBoolean(data[4]);
            administrator.QueryVIPPermission = Convert.ToBoolean(data[5]);
            administrator.RechargeMoneyPermission = Convert.ToBoolean(data[6]);
            administrator.SpendMoneyPermission = Convert.ToBoolean(data[7]);
            return administrator;
        }
        

    }
}

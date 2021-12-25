using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Model.Admin;

namespace BusinessLogicLayer.Login
{
    public class VerifiedLoginBLL
    {
        private Administrator administrator;

        /// <summary>
        /// 说明：根据路径获取与管理员账户和密码匹配的数据
        /// </summary>
        /// <param name="username">管理员账户</param>
        /// <param name="password">密码</param>
        /// <param name="path">路径</param>
        /// <returns>如果匹配则返回Administrator对象，如果不匹配则返回null。</returns>
        public Administrator GetAdministrator(string username, string password, string path)
        {
            administrator = AdministratorDAL.VerifiedAdministrator(username, password, path);
            return administrator;
        }


    }
}

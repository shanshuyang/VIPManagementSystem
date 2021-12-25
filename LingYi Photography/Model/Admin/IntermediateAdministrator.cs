using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Admin
{
    /// <summary>
    /// 说明：IntermediateAdministrator类是拥有中等权限的管理员。
    /// </summary>
    public class IntermediateAdministrator : Administrator
    {
        private string adminName;
        private string adminPassword;
        private PermissionLevel permission;
        private bool manageAdministratorPermission;
        private bool addVIPPermission;
        private bool queryVIPPermission;
        private bool rechargeMoneyPermission;
        private bool spendMoneyPermission;

        /// <summary>
        /// 说明：获取或设置管理员的名字属性。
        /// </summary>
        public override string Name
        {
            get
            {
                return adminName;
            }
            set
            {
                adminName = value;
            }
        }

        /// <summary>
        /// 说明：获取或设置管理员的密码属性。
        /// </summary>
        public override string Password
        {
            get
            {
                return adminPassword;
            }
            set
            {
                adminPassword = value;
            }
        }

        /// <summary>
        /// 说明：获取或设置管理员的权限等级属性。
        /// </summary>
        public override PermissionLevel Permission
        {
            get
            {
                return permission;
            }
            set
            {
                permission = value;
            }
        }

        /// <summary>
        /// 获取或设置管理员的管理权限属性。true表示允许修改其他权限，false表示不允许修改其他权限。
        /// </summary>
        public override bool ManageAdministratorPermission
        {
            get
            {
                return manageAdministratorPermission;
            }
            set
            {
                manageAdministratorPermission = value;
            }
        }

        /// <summary>
        /// 说明：获取或设置管理员的添加会员权限属性。true表示允许添加会员，false表示不允许添加会员。
        /// </summary>
        public override bool AddVIPPermission
        {
            get
            {
                return addVIPPermission;
            }
            set
            {
                addVIPPermission = value;
            }
        }

        /// <summary>
        /// 说明：获取或设置管理员的查询会员权限属性。true表示允许查询会员，false表示不允许查询会员。
        /// </summary>
        public override bool QueryVIPPermission
        {
            get
            {
                return queryVIPPermission;
            }
            set
            {
                queryVIPPermission = value;
            }
        }

        /// <summary>
        /// 说明：获取或设置管理员的会员充值权限属性。true表示允许给会员充值，false表示不允许给会员充值。
        /// </summary>
        public override bool RechargeMoneyPermission
        {
            get
            {
                return rechargeMoneyPermission;
            }
            set
            {
                rechargeMoneyPermission = value;
            }
        }

        /// <summary>
        /// 说明：获取或设置管理员的会员消费权限属性。true表示允许给会员消费，false表示不允许给会员消费。
        /// </summary>
        public override bool SpendMoneyPermission
        {
            get
            {
                return spendMoneyPermission;
            }
            set
            {
                spendMoneyPermission = value;
            }
        }

        /// <summary>
        /// 说明：IntermediateAdministrator类的构造函数，权限等级中等，默认拥有除管理权限外的所有权限。
        /// </summary>
        /// <param name="name">管理员的用户名</param>
        public IntermediateAdministrator(string name)
        {
            Name = name;
            Permission = PermissionLevel.Intermediate;
            ManageAdministratorPermission = false;
            AddVIPPermission = true;
            QueryVIPPermission = true;
            RechargeMoneyPermission = true;
            SpendMoneyPermission = true;
        }
    }
}

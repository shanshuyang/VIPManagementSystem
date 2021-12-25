using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Admin
{
    /// <summary>
    /// 说明：用来表示管理员的权限等级，共三个值Junior=0，Intermediate=1，Senior=2。
    /// </summary>
    public enum PermissionLevel
    {
        Junior = 0,
        Intermediate = 1,
        Senior = 2
    }

    /// <summary>
    /// 说明：Administrator类主要用于记录系统管理者的信息和权限。该类是抽象类需要派生其他子类。
    /// 管理员数据结构为：用户名|密码|权限等级|管理权限|添加会员权限|查询会员权限|会员充值权限|会员消费权限。
    /// 用户名、密码为string数据类型；权限等级为PermissionLevel枚举类型；管理权限、添加会员权限、查询会员权限
    /// 、会员充值权限、会员消费权限为bool数据类型。
    /// </summary>
    public abstract class Administrator
    {
        public abstract string Name { get; set; }
        public abstract string Password { get; set; }
        public abstract PermissionLevel Permission { get; set; }
        public abstract bool ManageAdministratorPermission { get; set; }
        public abstract bool AddVIPPermission { get; set; }
        public abstract bool QueryVIPPermission { get; set; }
        public abstract bool RechargeMoneyPermission { get; set; }
        public abstract bool SpendMoneyPermission { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingYi_Photography
{
    public enum PermissionLevel 
    {
        Lowest = 0,
        Normal = 1,
        Highest = 2
    }

    /// <summary>
    /// 说明：Administrator类主要用于记录系统管理者的信息和权限。
    /// </summary>
    public abstract class Administrator
    {
        public abstract string Name { get; set; }
        public abstract PermissionLevel Permission { get;}
        public abstract bool ManageAdministratorPermission { get;}
        public abstract bool AddVIPPermission { get; set; }
        public abstract bool QueryVIPPermission { get; set; }
        public abstract bool RechargeMoneyPermission { get; set; }
        public abstract bool SpendMoneyPermission { get; set; }
    }

    /// <summary>
    /// 说明：rootAdmin类的对象拥有系统的最高权限。
    /// </summary>
    public class RootAdmin : Administrator
    {
        string adminName;
        readonly PermissionLevel permission = PermissionLevel.Highest;
        readonly bool manageAdministratorPermission = true;
        bool addVIPPermission = true;
        bool queryVIPPermission = true;
        bool rechargeMoneyPermission = true;
        bool spendMoneyPermission = true;

        public override string Name
        {
            get { return adminName; }
            set { adminName = value; }
        }
        public override PermissionLevel Permission
        {
            get { return permission; }
        }
        public override bool ManageAdministratorPermission 
        {
            get { return manageAdministratorPermission; } 
        }
        public override bool AddVIPPermission 
        {
            get{ return addVIPPermission; }
            set{ addVIPPermission = value; }
        }
        public override  bool QueryVIPPermission 
        {
            get { return queryVIPPermission; }
            set { queryVIPPermission = value; }
        }
        public override  bool RechargeMoneyPermission 
        {
            get { return rechargeMoneyPermission; }
            set { rechargeMoneyPermission = value; } 
        }
        public override bool SpendMoneyPermission 
        {
            get { return spendMoneyPermission; }
            set { spendMoneyPermission = value; }
        }
    }

    /// <summary>
    /// 说明：commonAdmin类的对象拥有系统的一般权限。
    /// </summary>
    public class CommonAdmin : Administrator
    {
        string adminName;
        readonly PermissionLevel permission = PermissionLevel.Normal;
        readonly bool manageAdministratorPermission = false;
        bool addVIPPermission = true;
        bool queryVIPPermission = true;
        bool rechargeMoneyPermission = true;
        bool spendMoneyPermission = true;

        public override string Name
        {
            get { return adminName; }
            set { adminName = value; }
        }
        public override PermissionLevel Permission
        {
            get { return permission; }
        }
        public override bool ManageAdministratorPermission
        {
            get { return manageAdministratorPermission; }
        }
        public override bool AddVIPPermission
        {
            get { return addVIPPermission; }
            set { addVIPPermission = value; }
        }
        public override bool QueryVIPPermission
        {
            get { return queryVIPPermission; }
            set { queryVIPPermission = value; }
        }
        public override bool RechargeMoneyPermission
        {
            get { return rechargeMoneyPermission; }
            set { rechargeMoneyPermission = value; }
        }
        public override bool SpendMoneyPermission
        {
            get { return spendMoneyPermission; }
            set { spendMoneyPermission = value; }
        }
    }
}

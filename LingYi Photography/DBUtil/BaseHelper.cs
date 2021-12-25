using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    //所有其他Helper类的父类，包含共有的成员和方法。
    public abstract class BaseHelper
    {
        protected StreamReader sr;
        protected StreamWriter sw;
        protected string dataBaseRow;//存储数据库某行数据
        protected ArrayList dataBaseAllRows;//存储数据库所有数据
        protected string[] dataBaseRowSubcontent;//存储数据库某行的子内容
        protected int index;//记录索引
        protected string targetData;//存储目标数据
        protected ArrayList targetAllData;//存储多个目标数据
        protected string[] targetDataSubcontent;//存储目标数据子内容
        protected bool executeResult;//记录执行数据库操作的结果

        protected abstract void InitializeHelper();//初始化Helper
    }
}

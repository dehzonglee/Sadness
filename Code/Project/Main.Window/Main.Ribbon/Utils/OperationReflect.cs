﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Practices.Unity;
using IceElves.Interface;

namespace Main.Ribbon.Utils
{
    /// <summary>
    /// 操作反射方法
    /// </summary>
    public class OperationReflect
    {
        /// <summary>
        /// 运行菜单插件Click事件
        /// </summary>
        /// <param name="strDllPath">Dll路径</param>
        /// <param name="strClassName">全类名</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool RunMenuPluginClick(string strDllPath, string strClassName)
        {
            try
            {
                //反射获得Class Type
                Assembly assembly = Assembly.LoadFrom(strDllPath);
                Type type = assembly.GetType(strClassName);
                if (type != null)
                {
                    var container = new UnityContainer();
                    container.RegisterType<MenuPluginInterface>(new ContainerControlledLifetimeManager());
                    container.RegisterType(typeof(MenuPluginInterface), type);
                    var manager = container.Resolve<MenuPluginInterface>();
                    manager.Click();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
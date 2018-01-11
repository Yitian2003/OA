using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OA.Factory
{
    /// <summary>
    /// create object, refection
    /// </summary>
    public class DALFactory
    {
        private readonly static string DalAssemblyPath = ConfigurationManager.AppSettings["DalAssemblyPath"];
        private readonly static string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        /// <summary>
        /// create instance
        /// </summary>
        /// <returns></returns>
        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDal";

            return ReflectAssembly(fullClassName) as IUserInfoDal;
        }

        /// <summary>
        /// reflection
        /// </summary>
        /// <param name="fullClassName"></param>
        public static object ReflectAssembly(string fullClassName)
        {
            var assembly = Assembly.Load(DalAssemblyPath);
            return assembly.CreateInstance(fullClassName);
        }

        
    }
}

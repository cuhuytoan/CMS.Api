using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.RepositoriesBase
{
    public static class Utils
    {
        public static List<Assembly> ListTypeRepository()
        {
            List<Assembly> lstReturn = new();
            Assembly asm = Assembly.GetExecutingAssembly();
            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == "CMS.Services.Repositories" && type.IsClass)                    
                    lstReturn.Add(Assembly.GetAssembly(type));
            }
            return lstReturn;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCode
{
    internal static class ExtensionMethodForName
    {
        public  static  bool NameCheck(this string name)
        {
            if (!char.IsUpper(name[0]) && name.Length<=4 && name.Contains(" "))
            {
                return false;
            }
            return true;
        }
    }
}

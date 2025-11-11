using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCode
{
    internal static class ExtensionmethodForClassNAme
    {
        public static bool ExtensionMethod(this string name)
        {
            if (name.Length == 5 && char.IsUpper(name[0]) && char.IsUpper(name[1]) &&   char.IsUpper(name[2]) && char.IsDigit(name[3]) && char.IsDigit(name[4])) 
            {
                return true;
            }
            return false;
        }

    }
}

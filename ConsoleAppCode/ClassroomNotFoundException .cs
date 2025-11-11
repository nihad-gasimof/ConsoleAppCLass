using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCode
{
    internal class ClassroomNotFoundException:Exception
    {
        public ClassroomNotFoundException(string message="Sinif tapilmadi") :base(message)
        { }
    }
}

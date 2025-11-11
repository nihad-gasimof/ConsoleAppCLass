using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCode
{
    internal class Student
    {
        public int Id { get; set; }
        private static int Idcounter { get; set; } = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public Student(string name, string surname)
        {
            if (!name.NameCheck())
            {
                Console.WriteLine("Deyer duzgun daxil edilmedi");
                return;
            }
         
            Name = name;
            Surname = surname;
            ++Idcounter ;
            Id=Idcounter ;
        }
    }


}

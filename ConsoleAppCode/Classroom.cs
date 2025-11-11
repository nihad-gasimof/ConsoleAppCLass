using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCode
{
    public enum ClassType
    {
        Backend = 1,
        FrontEnd = 2
    };
    internal class Classroom
    {
        public int Id { get; set; }
        private static int IdCounter { get; set; }=0;
        public string Name { get; set; }

        public List<Student> students = new List<Student>();
        public int StudentLimit;
        public ClassType CType { get; set; }

        public Classroom()
        {
            students = new List<Student>();
        }
        public Classroom(string name, ClassType type)
        {
           
            Name = name;
            CType = type;
            ++IdCounter;
            Id = IdCounter;
        }
        public void GetAll()
        {
            Console.WriteLine("Butun Telebeler");
            if (students.Count == 0)
            {
                Console.WriteLine(" Sinifde telebe yoxdur.");
                return;
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Id:{student.Id},Name:{student.Name},Surname:{student.Surname}");
            }
        }

        public int Limiter()
        {
            if (CType == ClassType.Backend)
            {
                return 20;
            }
            return 15;
        }
        public void AddStudent(Student student)
        {
            if (students.Contains(student))
            {

                Console.WriteLine("Bu sagird artiq var");
            }
            if (students.Count > Limiter())
            {
                Console.WriteLine($" {CType} sinifi ücün limit dolub ({Limiter()})");
                return;

            }
            students.Add(student);
            Console.WriteLine("Sagird yaradildi");
        }
        public Student FindId(int id)
        {
            Student student = students.FirstOrDefault(x => x.Id == id);
            if (student == null) throw new StudentNotFoundException();
            else
            {
                Console.WriteLine("Axtarilan sagir budur");
                return student;
            }
        }
        public void RemoveStudent(int id)
        {

            Student student = students.FirstOrDefault(x => x.Id == id);
            if (student == null) throw new StudentNotFoundException();
            else
            {
                students.Remove(student);
                Console.WriteLine("Sagird silindi");
            }
        }
    }
}

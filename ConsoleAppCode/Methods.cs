using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCode
{
    internal static class Methods
    {

        public static void CreateClassRoom(List<Classroom> classrooms)
        {
            string name;
            while (true)
            {
                Console.WriteLine("Sinifin Adini Daxil Edin (BPA202 tipde olmalidir )");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name) && name.ExtensionMethod()) break;
                Console.WriteLine("Duzgun deyer daxil edin");
            }

            Console.WriteLine("Tip daxil edin 1-Backend,2-FrontEnd");
            ClassType type = (ClassType)Convert.ToInt32(Console.ReadLine());

            Classroom classroom = new(name, type);
            Program.classrooms.Add(classroom);
            Console.WriteLine("Sinif ugurla yaradildi sinifin adi :" + " " + classroom.Name);

        }
        public static void CreateStudent(List<Classroom> classrooms)
        {
        restart:
            if (Program.classrooms.Count <= 0)
            {
                Console.WriteLine("Evvelce sinif yaradin");
                return;
            }
            Console.WriteLine("Sagirdin Adini daxil edin");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Gozlenilmez xeta");
                goto restart;
            }
            Console.WriteLine("Sagirdin soyadini daxil edin");
            string surname = Console.ReadLine();
            if (string.IsNullOrEmpty(surname))
            {
                Console.WriteLine("Gozlenilmez xeta");
                goto restart;
            }
            Student student = new(name, surname);
            Console.WriteLine("Hansi sinife daxil etmek isteyirsiz?");
            Console.WriteLine("movcud sinifler");
            foreach (Classroom s in Program.classrooms)
            {
                Console.WriteLine($"Id:{s.Id}Name:{s.Name}");
            }
            Console.WriteLine("Id ni daxil edin");
            int selectedid = Convert.ToInt32(Console.ReadLine());
            Classroom selectedclass = Program.classrooms.Find(x => x.Id == selectedid);
            if (selectedclass == null)
                throw new ClassroomNotFoundException(" Bele sinif tapılmadı!");
            selectedclass.AddStudent(student);
        }
        public static void ShowAllStudents(List<Classroom> classrooms)
        {
            if (Program.classrooms.Count == 0)
            {
                Console.WriteLine(" Sinif yoxdur.");
                return;
            }

            foreach (var c in Program.classrooms)
                c.GetAll();
        }
        public static void ShowClassroomStudents(List<Classroom> classrooms)
        {

            Console.Write("Sinif ID sini daxil edin ");
            foreach (Classroom s in Program.classrooms)
            {
                Console.WriteLine($"Id:{s.Id}Name:{s.Name}");
            }
            int id = int.Parse(Console.ReadLine());

            var classroom = Program.classrooms.Find(c => c.Id == id);
            if (classroom == null)
                throw new ClassroomNotFoundException("Sinif tapılmadı!");

            classroom.GetAll();
        }
        public static void DeleteStudent(List<Classroom> classrooms)
        {
            Console.WriteLine("Silmek istediyiniz telebenin  sinfinin id sini daxil edin");
            foreach (Classroom s in Program.classrooms)
            {
                Console.WriteLine($"Id:{s.Id}Name:{s.Name}");
            }
            int id = int.Parse(Console.ReadLine());
            var classroom = Program.classrooms.Find(c => c.Id == id);
            if (classroom == null)
                throw new ClassroomNotFoundException("Sinif tapılmadı!");
            classroom.GetAll();
            Console.WriteLine("Silmek istediyiniz telebenin   id sini daxil edin");
            int studentid = int.Parse(Console.ReadLine());
            classroom.RemoveStudent(studentid);


        }

    }
}

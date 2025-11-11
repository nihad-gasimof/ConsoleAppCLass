using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleAppCode
{

    internal class Program
    {
        public static List<Classroom> classrooms = new();
        static string path = "json1.json";

        static void Main(string[] args)
        {
           
            if (File.Exists(path))
            {
                string jsonfromfile = File.ReadAllText(path);
                classrooms = JsonConvert.DeserializeObject<List<Classroom>>(jsonfromfile) ?? new List<Classroom>();
            }
            static void SaveToFile()
            {
                string jsontofile = JsonConvert.SerializeObject(classrooms, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(jsontofile);
                }
            }

            while (true)
            {
                try
                {
                restart:
                    Console.WriteLine("Esas Menyu");
                    Console.WriteLine("1.Sinif Yarat");
                    Console.WriteLine("2.Sagird Yarat");
                    Console.WriteLine("3.Butun Telebeleri Ekrana cixart");
                    Console.WriteLine("4.Secilmis Sinifdeki Telebeleri Ekrana cixart");
                    Console.WriteLine("5.Telebe sil");
                    Console.WriteLine("0.Cixis");

                    string choise = Console.ReadLine();
                    Console.WriteLine();
                    switch (choise)
                    {
                        case "1": Methods.CreateClassRoom(classrooms);
                            SaveToFile();
                                break;
                        case "2": Methods.CreateStudent(classrooms);
                            SaveToFile();
                            break;
                        case "3": Methods.ShowAllStudents(classrooms); break;
                        case "4": Methods.ShowClassroomStudents(classrooms); break;
                        case "5": Methods.DeleteStudent(classrooms);
                            SaveToFile();
                            break;
                        case "0":
                            Console.WriteLine("proqramdan cixirsiz");
                            return;
                    }
                    Console.WriteLine("\nDavam etmek ucun Enter");
                    Console.ReadLine();
                    Console.Clear();
                }

                catch (StudentNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (ClassroomNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }



    }
}

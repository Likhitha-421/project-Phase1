using System;
using System.Collections.Generic;
using System.IO;

namespace project_Phase1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream (@"D:\Likhitha\Teacher projectfile.txt",FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string content = sr.ReadToEnd();
                string[] lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                List<Teacher> listTeachers = new List<Teacher>();
                foreach (string line in lines)
                {
                    string[] col = line.Split(',');
                    Teacher teacher = new Teacher();
                    teacher.Id = col[0];
                    teacher.FirstName = col[1];
                    teacher.LastName = col[2];
                    teacher.CClass = col[3];
                    teacher.Section = col[4];
                    listTeachers.Add(teacher);
                }
                Console.WriteLine(content);
            }
            Console.WriteLine("1.create\n2.update\n3.delete\n4.search\n5.display");

            static void update()
            {
                List<Teacher> listTeachers = getTeachers();

                string id;
                Console.WriteLine("Enter the id you want to update:");
                id = Console.ReadLine();
                foreach (Teacher t in listTeachers)
                {
                    if (t.Id == id)
                    {
                        Console.WriteLine("Enter First Name:");
                        string firstname = Console.ReadLine();
                        Console.WriteLine("Enter Last Name:");
                        string lastname = Console.ReadLine();
                        Console.WriteLine("Enter Class:");
                        string cclass = Console.ReadLine();
                        Console.WriteLine("Enter Section:");
                        string section = Console.ReadLine();
                        t.FirstName = firstname; t.LastName = lastname; t.CClass = cclass; t.Section = section;
                        Console.WriteLine("updated line is:");
                        Console.WriteLine($"{ t.Id},{ t.FirstName},{ t.LastName},{ t.CClass},{ t.Section}");
                        break;
                    }
                }
                int count = 0;
                string[] arr = new string[listTeachers.Count];
                foreach (Teacher t1 in listTeachers)
                {
                    String s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                    arr[count] = s;
                    count++;
                }
                File.WriteAllLines(@"D:\Likhitha\Teacher projectfile.txt", arr);
            }
            static void create()
            {
                List<Teacher> listTeachers = getTeachers();
                string UIId = "";
                string UIFirstName = "";
                string UILastName = "";
                string UIClass = "";
                string UISection = "";
                using (FileStream fs = new FileStream(@"D:\Likhitha\Teacher projectfile.txt", FileMode.Append))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = UIId;
                    teacher.FirstName = UIFirstName;
                    teacher.LastName = UILastName;
                    teacher.CClass = UIClass;
                    teacher.Section = UISection;

                    Console.WriteLine("Enter additional data to create:");
                    Console.WriteLine("Enter the teacher Id: ");
                    UIId = Console.ReadLine();
                    Console.WriteLine("Enter the teacher first name: ");
                    UIFirstName = Console.ReadLine();
                    Console.WriteLine("Enter the teacher last name: ");
                    UILastName = Console.ReadLine();
                    Console.WriteLine("Enter the teacher class: ");
                    UIClass = Console.ReadLine();
                    Console.WriteLine("Enter the teacher section: ");
                    UISection = Console.ReadLine();
                    string fullText = (UIId + "," + UIFirstName + "," + UILastName + "," + UIClass + "," + UISection);
                    sw.WriteLine(fullText);
                    string[] arr = new string[listTeachers.Count];
                }
            }
            static void delete()
            {
                List<Teacher> listTeachers = getTeachers();

                string id;
                Console.WriteLine("Enter the id to delete:");
                id = Console.ReadLine();
                bool flag = false;
                foreach (Teacher t in listTeachers)
                {
                    if (t.Id == id) 
                    {
                        listTeachers.Remove(t);
                        flag = true;
                        break;
                    }

                }
                if (flag)
                {
                    Console.WriteLine("deletion of id line completed.");
                }
                else
                {
                    Console.WriteLine("id is not there");
                }
                int count = 0;
                string[] arr = new string[listTeachers.Count];
                foreach (Teacher t1 in listTeachers)
                {
                    string s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                    arr[count] = s;
                    count++;
                }
                File.WriteAllLines(@"D:\Likhitha\Teacher projectfile.txt", arr);
            }
            static void search()
            {
                List<Teacher> listTeachers = getTeachers();

                Console.WriteLine("Enter id:");
                string id = Console.ReadLine();
                bool flag = true;
                foreach (Teacher t in listTeachers)
                {
                    if (t.Id == id)
                    {
                        Console.WriteLine("given id is present in the given file");

                        Console.WriteLine($"{t.Id},{t.FirstName},{t.LastName},{t.CClass},{t.Section}");
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Sorry! Id not present");

                }
            }
            static List<Teacher> getTeachers()
            {
                List<Teacher> listTeachers = new List<Teacher>();
                string teacherfile = @"D:\Likhitha\Teacher projectfile.txt";
                string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);
                foreach (string line in arrteacher)
                {
                    string[] l = line.Split(',');
                    Teacher teacher = new Teacher();
                    teacher.Id = l[0];
                    teacher.FirstName = l[1];
                    teacher.LastName = l[2];
                    teacher.CClass = l[3];
                    teacher.Section = l[4];
                    listTeachers.Add(teacher);
                }
                return listTeachers;
            }
            static void display()
            {
                Console.WriteLine("Enter on Which basis:");
                string s = Console.ReadLine();
                sort(s);
            }
            static void sort(string s)
            {
                List<Teacher> listTeachers = getTeachers();

                Console.WriteLine("After Sorting by " + s + " : ");
                if (s == "FirstName")
                {
                    listTeachers.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
                }
                else if (s == "LastName") 
                {
                    listTeachers.Sort((a, b) => a.LastName.CompareTo(b.LastName));
                }
                else if (s == "id") 
                {
                    listTeachers.Sort((a,b) => a.Id.CompareTo(b.Id));

                    int count = 0;
                    string[] arr = new string[listTeachers.Count];
                    foreach (Teacher t1 in listTeachers)
                    {
                        string s1 = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                        arr[count] = s1;
                        count++;
                    }
                    File.WriteAllLines(@"D:\Likhitha\Teacher projectfile.txt", arr);
                }
                foreach (Teacher t in listTeachers)
                {
                    Console.WriteLine($"{ t.Id},{ t.FirstName},{ t.LastName},{ t.CClass},{ t.Section}");
                }
            }
            while (true)
            {
                int option;
                Console.WriteLine("Enter option you want to perform:");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        create();
                        break;
                    case 2:
                        update();
                        break;
                    case 3:
                        delete();
                        break;
                    case 4:
                        search();
                        break;
                    case 5:
                        display();
                        break;
                    default:
                        Console.WriteLine("Invalid Option:-1");
                        break;
                }

            }


        }
    }
}

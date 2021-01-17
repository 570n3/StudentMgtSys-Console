using System;

namespace StudentManagementSystem
{
    class internalAccess
    {

        internal string Title;
        public void print()
        {
            Console.WriteLine("\nKijani ki kori " + Title);
        }
    }
    class Program
    {
        struct Student

        {
            public string studentName;

            public string studentID;

            public string joiningBatch;

            public string dept;

            public string deg;

            public string courseID;

            public string courseName;

            public string insName;

            dynamic cHours;
  

        };

        enum Department
        {
            ComputerScience, BBA, English
        }

        enum Degree {
            BSC, BBA, BA, MSC, MBA, MA
        }
        static void Main(string[] args)
        {

            try
            {
                Student[] ppl = new Student[20];
                int c = 0;
                Display();
                int choice;
                string confirm;


                do
                {

                    Console.Write("Enter your choice(1-4):");

                    choice = int.Parse(Console.ReadLine());


                    switch (choice)
                    {

                        case 1: Add(ppl, ref c); break;
                        case 2: View(ppl, c); break;
                        case 3: Delete(ppl, ref c); break;
                        case 4: AddNewSem(ppl, ref c); break;


                        default: Console.WriteLine("invalid"); break;

                    }



                    Console.Write("Press Y to continue:");

                    confirm = Console.ReadLine().ToString();

                } while (confirm == "Y");



            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input");

                Console.ReadLine();

            }

            internalAccess ac = new internalAccess();
            ac.print();
            

            static void Courses(dynamic crs, ref int c)
            {


                Console.WriteLine();

                Console.Write("Enter Course ID:");
                crs[c].courseID = Console.ReadLine().ToString();

                Console.Write("Course Name:");
                crs[c].courseName = Console.ReadLine().ToString();

                Console.Write("Instructor Name:");
                crs[c].insName = Console.ReadLine().ToString();

                Console.Write("Number of Credits:", crs.GetType().ToString());

                c++;

            }

            static void AddNewSem(dynamic semester, ref int c) {

                Console.Write("Enter Department:", semester.GetType().ToString());

            }


            static void Display()
            {

                Console.WriteLine("=====================================================");

                Console.WriteLine(" MENU ");

                Console.WriteLine("=====================================================");

                Console.WriteLine(" 1.Add New Student");
                Console.WriteLine(" 2.View Student Details");
                Console.WriteLine(" 3.Delete Student");
                Console.WriteLine(" 4.Add New Semester");

            }
            static void Add(Student[] ppl, ref int c)
            {


            Again:
                Console.WriteLine();

                Console.Write("Enter Student's ID:");
                ppl[c].studentID = Console.ReadLine().ToString();
                if (Search(ppl, ppl[c].studentID, c) != -1)
                {

                    Console.WriteLine("This ID already exists.");
                    goto Again;

                }

                Console.Write("Enter Student's First Name:");
                String fname = Console.ReadLine();
                Console.Write("Enter Student's Middle Name:");
                String mname = Console.ReadLine();
                Console.Write("Enter Student's last Name:");
                String lname = Console.ReadLine();

                Console.Write("Student Name: {0} {1} {2} ", fname, mname, lname + "\n\nHit ENTER to continue");
                ppl[c].studentName = Console.ReadLine().ToString();

                Console.Write("Enter Joining Batch:");
                ppl[c].joiningBatch = Console.ReadLine().ToString();

                Console.Write("Enter Department:");
                ppl[c].dept = Console.ReadLine().ToString();

                Console.Write("Enter Degree:");
                ppl[c].deg = Console.ReadLine().ToString();



                c++;

                


            }
            static int Search(Student[] ppl, string id, int c)
            {
                int found = -1;
                for (int i = 0; i < c && found == -1; i++)
                {

                    if (ppl[i].studentID == id) found = i;

                    else found = -1;
                }

                return found;

            }

            static void View(Student[] ppl, int c)
            {

                int i = 0;

                Console.WriteLine("{0} {1} {2} {3} {4}", " 0                     ", "1           ", "       2                    ", "3                  ", "4");
                Console.WriteLine("{0} {1} {2} {3} {4}", "NAME                  ", "ID          ", "Joining Batch           ", "Department          ", "Degree");

                Console.WriteLine("========================================================================================================");

                while (i < c)
                {

                    if (ppl[i].studentID != null)
                    {

                        Console.Write("{0} {1} {2} {3} {4}", ppl[i].studentID, ppl[i].studentName, ppl[i].joiningBatch, ppl[i].dept, ppl[i].deg);

                        Console.Write("\n");
                    }

                    i++;

                    Find(ppl, c);


                }
            }

            static void Delete(Student[] ppl, ref int c)
            {
                string id;
                int index;
                if (c > 0)
                {
                    Console.Write("Enter Student's ID:");
                    id = Console.ReadLine();
                    index = Search(ppl, id.ToString(), c);

                    if ((index != -1) && (c != 0))
                    {
                        if (index == (c - 1))
                        {

                            Clean(ppl, index);
                            --c;

                            Console.WriteLine("The details was deleted.");
                        }
                        else
                        {
                            for (int i = index; i < c - 1; i++)
                            {
                                ppl[i] = ppl[i + 1];
                                Clean(ppl, c);
                                --c;
                            }

                        }

                    }
                    else Console.WriteLine("The details doesn't exist.Check the ID and try again.");


                }
                else Console.WriteLine("No details to Delete");
            }

            static void Find(Student[] ppl, int c)
            {
                string id;
                Console.Write("Enter Student's ID:");
                id = Console.ReadLine();

                int index = Search(ppl, id.ToString(), c);
                if (index != -1)
                {
                    Console.Write("{0,-5}{1,-20}{2,-5}", ppl[index].studentID, ppl[index].studentName, ppl[index].joiningBatch);

                    Console.Write("{0,-5}{1,-5}", ppl[index].dept, ppl[index].deg);

                }
                else Console.WriteLine("The details doesn't exits.");

            }
            static void Clean(Student[] ppl, int index)
            {
                ppl[index].studentID = null;
                ppl[index].studentName = null;
                ppl[index].joiningBatch = null;
                ppl[index].dept = null;
                ppl[index].deg = null;
            }


        }
    }
}
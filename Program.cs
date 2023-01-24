using System.Globalization;

namespace laboratory_2_v3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentRegistration app = new StudentRegistration();

            while (true)
            {
                try
                {

                    // TODO: Finish the program
                    Console.WriteLine("""
                        
                        AdDU's CLI Enrolment

                        1 => List all students
                        2 => Add a student
                        3 => Register a student
                        4 => Add a course to a registration
                        5 => Display a student's registration
                        6 => Exit

                        """);
                    Console.Write("What do you want to do? => ");

                    int selection = Convert.ToInt32(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            {
                                app.GetAllEnlistedStudents();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("""
                                    
                                    === Add a student ===
                                    """);

                                Console.Write("Student 6-digit ID => ");
                                int id = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Student surname => ");
                                string surname = Console.ReadLine();

                                Console.Write("Student first name => ");
                                string firstName = Console.ReadLine();

                                Console.Write("Student middle name => ");
                                string middleName = Console.ReadLine();

                                Console.Write("Student name suffix (Leave empty if none) => ");
                                string suffix = Console.ReadLine();

                                app.AddStudent(id, surname, firstName, middleName, suffix);

                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("""
                                    
                                    === Register a student ===
                                    """);

                                Console.Write("Student 6-digit ID => ");
                                int id = Convert.ToInt32(Console.ReadLine());

                                Console.Write("School year => ");
                                int schoolYear = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Semester => ");
                                string semester = Console.ReadLine();

                                Console.Write("Program => ");
                                string program = Console.ReadLine();

                                Console.Write("Year level => ");
                                int yearLevel = Convert.ToInt32(Console.ReadLine());

                                app.AddToEnlistment(id, schoolYear, semester, program, yearLevel);
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("""
                                    
                                    === Add a course to a registration ===
                                    """);

                                Console.Write("Student 6-digit ID => ");
                                int id = Convert.ToInt32(Console.ReadLine());

                                Console.Write("School year => ");
                                int schoolYear = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Semester => ");
                                int semester = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Class code => ");
                                string classCode = Console.ReadLine();

                                Console.Write("Course code => ");
                                int courseCode = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Schedule => ");
                                string schedule = Console.ReadLine();

                                app.RegisterStudent(id, schoolYear, semester, classCode, courseCode, schedule);
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("""
                                    
                                    === Display a student's registration ===
                                    """);

                                Console.Write("Student 6-digit ID => ");
                                int studentId = Convert.ToInt32(Console.ReadLine());

                                app.GetStudentRegistration(studentId);
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine($"\n{"*** EXIT ***",75}\n");
                                return;
                            }
                        default:
                            Console.WriteLine("\nInsert only values from 1 - 6\n");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nErrors has been thrown D:\n");
                }

            }
        }
    }
}
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_2_v3
{
    internal class StudentRegistration
    {
        //
        // Variables
        //
        private Course course = new Course();
        private Enlistment enlist = new Enlistment();

        private Dictionary<int, Course> courseList = new Dictionary<int, Course>()
        {
            { 156243, new Course("IT 110", "Programming Paradigms") },
            { 143220, new Course("CSC 101", "Introduction to C++ Programming") },
            { 172523, new Course("IT 124", "Web Development") }
        };

        private Dictionary<int, Student> studentList = new Dictionary<int, Student>();
        private Dictionary<KeyValuePair<int, Student>, Enlistment> enlistedStudents = new Dictionary<KeyValuePair<int, Student>, Enlistment>();
        private List<KeyValuePair<int, Registration>> registeredStudentCourse = new List<KeyValuePair<int, Registration>>();

        //
        // Setters and Getters
        //

        public void GetAllEnlistedStudents()
        {
            Console.WriteLine($"""
                
                List All Students

                =============================================================================================================================
                {"Student Name",-50} {"Latest Registration",-50} Number of Courses
                =============================================================================================================================
                """);

            foreach (var enlisted in enlistedStudents)
            {
                Console.WriteLine($"{enlisted.Key.Value.FullName,-50} {enlisted.Value.SchoolYear,-50} {GetCourseCount(enlisted.Key.Key)}");
            }

            Console.WriteLine($"\n{"*** NOTHING FOLLOWS ***",75}\n");
        }

        public KeyValuePair<int, Student> GetStudent(int studentId)
        {
            foreach (KeyValuePair<int, Student> entry in enlistedStudents.Keys)
            {
                if (entry.Key == studentId) return entry;
            }

            Console.WriteLine("\n!!! ERROR: STUDENT NOT FOUND IN ENLISTMENT !!!\n");
            throw new Exception("");
        }

        public Enlistment GetEnlistment(int studentId)
        {
            foreach (var entry in enlistedStudents)
            {
                if (entry.Key.Key == studentId) return entry.Value;
            }

            Console.WriteLine("\n!!! ERROR: ENLISTMENT NOT FOUND !!!\n");
            throw new Exception("");
        }

        public List<Registration> GetRegisteredCourses(int studentId)
        {
            List<Registration> enrolledCourses = new List<Registration>();

            foreach (var entry in registeredStudentCourse)
            {
                if (entry.Key == studentId) enrolledCourses.Add(entry.Value);
            }

            return enrolledCourses;

        }

        public Course GetCourse(int courseCode)
        {
            try
            {
                return courseList[courseCode];
            }
            catch (Exception)
            {
                Console.WriteLine("\n!!! ERROR: COURSE NOT FOUND !!!\n");
                throw new Exception("");
            }
        }

        public int GetCourseCount(int studentId)
        {
            int courseCount = 0;

            foreach (KeyValuePair<int, Registration> registerEntry in registeredStudentCourse)
            {
                if (registerEntry.Key == studentId)
                {
                    courseCount++;
                }
            }

            return courseCount;
        }

        public void GetStudentRegistration(int studentId)
        {
            KeyValuePair<int, Student> selectedStudent = GetStudent(studentId);
            Enlistment selectedEnlistment = GetEnlistment(studentId);
            List<Registration> studentRegistration = GetRegisteredCourses(studentId);

            Console.WriteLine($"""
                {studentId,-70} {selectedEnlistment.Term}
                {selectedStudent.Value.FullName,-70} {selectedEnlistment.Program}, Year {selectedEnlistment.Yearlevel}
                ============================================================================================================================================
                {"Class Code",-35} {"Course No.",-35} {"Course Description",-35} {"Schedule",-35}
                ============================================================================================================================================
                """);

            foreach (Registration registerEntry in studentRegistration)
            {
                string classCode = registerEntry.ClassCode;
                string courseId = registerEntry.CourseEntry.CourseIdentifier;
                string description = registerEntry.CourseEntry.CourseDescription;
                string schedule = registerEntry.Schedule;
                Console.WriteLine($"{classCode,-35} {courseId,-35} {description,-35} {schedule,-35}");
            }

            Console.WriteLine("\n*** NOTHING FOLLOWS ***\n");
        }

        public void AddStudent(int studentId, string surname, string firstName, string middleName, String suffix)
        {
            Student studentEntry = new Student();
            studentEntry.Surname = surname;
            studentEntry.FirstName = firstName;
            studentEntry.MiddleName = middleName;
            studentEntry.Suffix = suffix;

            foreach (Student listedStudent in studentList.Values) studentEntry.CheckUniqueness(listedStudent);

            IsValidId(studentId);
            studentList.Add(studentId, studentEntry);
        }

        public void AddToEnlistment(int studentId, int schoolYear, string semester, string program, int yearLevel)
        {
            try
            {
                KeyValuePair<int, Student> selectedStudent = new KeyValuePair<int, Student>(studentId, studentList[studentId]);

                Enlistment newEntry = new Enlistment();
                newEntry.SchoolYear = schoolYear;
                newEntry.Yearlevel = yearLevel;
                newEntry.Semester = semester;
                newEntry.Program = program;

                enlistedStudents.Add(selectedStudent, newEntry);
            }
            catch (Exception)
            {
                if (!studentList.ContainsKey(studentId)) Console.WriteLine("\n!!! ERROR: STUDENT DOES NOT EXIST !!!\n");
                else Console.WriteLine("\n!!! ERROR: STUDENT ALREADY EXISTS !!!\n");
            }
        }

        public void RegisterStudent(int studentId, int enrollYear, int semester, string classCode, int courseCode, string schedule)
        {
            Registration registerEntry = new Registration();
            registerEntry.EnrollYear = enrollYear;
            registerEntry.Semester = semester;
            registerEntry.ClassCode = classCode;
            registerEntry.Schedule = schedule;
            registerEntry.CourseEntry = GetCourse(courseCode);

            if (IsEnlistedStudentId(studentId)) registeredStudentCourse.Add(new KeyValuePair<int, Registration>(studentId, registerEntry));
        }

        //
        // Methods/Functions
        //
        private bool IsValidId(int id)
        {
            int idLength = 6;

            if (Convert.ToString(id).Length != idLength)
            {
                Console.WriteLine("\n!!! ERROR: STUDENT ID AND/OR SUBJECT CODE MUST BE 6 DIGITS !!!\n");
                throw new Exception("");
            }

            return true;
        }

        private bool IsEnlistedStudentId(int id)
        {
            List<KeyValuePair<int, Student>> enlistedStudentKeys = enlistedStudents.Keys.ToList();

            if (enlistedStudentKeys.Count > 0)
            {
                foreach (KeyValuePair<int, Student> keys in enlistedStudentKeys)
                {
                    if (keys.Key == id)
                    {
                        return true;
                    }
                }

                Console.WriteLine("\n!!! ERROR: STUDENT IS NOT REGISTERED !!!\n");
                throw new Exception("");
            }

            Console.WriteLine("\n!!! ERROR: NO STUDENTS ENROLLED !!!\n");
            throw new Exception("");
        }
    }
}

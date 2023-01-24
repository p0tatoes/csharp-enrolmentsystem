using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_2_v3
{
    internal class Registration
    {

        //
        // Variables
        //
        private Course courseEntry;

        private int enrollYear;
        private int semester;

        string schedule;
        private string classCode;

        //
        // Setters and Getters
        //
        public int EnrollYear
        {
            get => enrollYear;
            set => enrollYear = value;
        }
        
        public int Semester
        {
            get => semester;
            set
            {
                IsValidSemester(value);
                semester = value;
            }
        }

        public string ClassCode
        {
            get => classCode;
            set => classCode = value;
        }
        
        public string Schedule
        {
            get => schedule;
            set
            {
                IsNotNullOrWhiteSpace(value);
                schedule = value;
            }
        }

        public Course CourseEntry
        {
            get => courseEntry;
            set => courseEntry = value;
        }

        //
        // Methods/Functions
        //
        public void IsValidSemester(int semester)
        {
            List<int> semesters = new List<int> { 1, 2, 3 };

            if (!semesters.Contains(semester))
            {
                Console.WriteLine("\n!!! ERROR: PLEASE INPUT ONLY VALUES FROM 1 - 3 !!!\n");
                throw new Exception("");
            }
        }

        public void IsNotNullOrWhiteSpace(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new Exception("");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_2_v3
{
    internal class Enlistment
    {
        //
        // Variables
        //
        private int schoolYear;
        private int yearLevel;

        private string semester;
        private string program;

        //
        // Setters and Getters
        //
        public string Term
        {
            get
            {
                int nextYear = schoolYear + 1;
                return $"AY {schoolYear} - {nextYear}, {semester}";
            }
        }
        public int SchoolYear
        {
            get => schoolYear;
            set => schoolYear = value;
        }

        public int Yearlevel
        {
            get => yearLevel;
            set
            {
                if (value < 1 || value > 5)
                {
                    Console.WriteLine("\n!!! ERROR: YEAR LEVEL MUST BE BETWEEN 1 - 5 !!!\n");
                    throw new Exception("");
                }
                yearLevel = value;
            }
        }

        public string Semester
        {
            get => semester;
            set
            {
                isNumber(value);

                switch (Convert.ToInt32(value))
                {
                    case 1:
                        semester = "First Semester";
                        break;
                    case 2:
                        semester = "Second Semester";
                        break;
                    case 3:
                        semester = "Summer Semester";
                        break;
                    default:
                        Console.WriteLine("\n!!! ERROR: PLEASE INPUT ONLY VALUES FROM 1 - 3 !!!\n");
                        break;
                }
            }
        }

        public string Program
        {
            get => program;
            set
            {
                IsNotNullOrWhiteSpace(value, "program");
                program = value;
            }
        }

        //
        // Methods/Functions
        //
        public void isNumber(string value)
        {
            bool isNumber = int.TryParse(value, out _);

            if (!isNumber)
            {
                Console.WriteLine("\n!!! ERROR: SEMESTER IS NOT NUMBER !!!\n");
                throw new Exception("");
            }
        }

        public void IsNotNullOrWhiteSpace(string value, string inputField)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine($"\n!!! ERROR: {inputField.ToUpper()} IS EMPTY !!!\n");
                throw new Exception("");
            }
        }

        public bool Equals(Enlistment enlistment)
        {
            if(enlistment.SchoolYear == schoolYear && enlistment.Yearlevel ==
            yearLevel && enlistment.Semester == semester && enlistment.Program
            == program)
            {
                return true;
            }

            return false;
        }
    }
}

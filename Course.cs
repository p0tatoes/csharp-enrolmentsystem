using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_2_v3
{
    internal class Course
    {
        //
        // Variables
        //

        private int courseCode;
        private string courseIdentifier;
        private string courseDescription;

        //
        // Constructor/s
        //
        public Course() { }

        public Course(string courseIdentifier, string courseDescription)
        {
            IsNotNullOrWhiteSpace(courseIdentifier);
            this.courseIdentifier = courseIdentifier;

            IsNotNullOrWhiteSpace(courseDescription);
            this.courseDescription = courseDescription;
        }

        public Course(int courseCode, string courseIdentifier, string courseDescription)
        {
            this.courseCode = courseCode;

            IsNotNullOrWhiteSpace(courseIdentifier);
            this.courseIdentifier = courseIdentifier;

            IsNotNullOrWhiteSpace(courseDescription);
            this.courseDescription = courseDescription;
        }

        //
        // Setters and Getters
        //
        public int CourseCode
        {
            get => courseCode;
            set => courseCode = value;
        }

        public string CourseIdentifier
        {
            get => courseIdentifier;
            set
            {
                IsNotNullOrWhiteSpace(value);
                courseIdentifier = value;
            }
        }

        public string CourseDescription
        {
            get => courseDescription;
            set
            {
                IsNotNullOrWhiteSpace(value);
                courseDescription = value;
            }
        }

        //
        // Methods/Functions
        //
        public void IsNotNullOrWhiteSpace(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new Exception("");
        }

    }
}

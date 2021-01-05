using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_B.Models
{
    class Schoolclass
    {
        private Course _course;
        private List<Trainer> _trainer;
        private List<Student> _students;
        private List<Assignment> _assignment;

        public List<Trainer> Trainer
        {
            get { return (this._trainer); }
            set { this._trainer = value; }
        }
        public List<Student> Students
        {
            get { return (this._students); }
            set { this._students = value; }
        }
        public Course Course
        {
            get { return (this._course); }
            set { this._course = value; }
        }
        public List<Assignment> Assignment
        {
            get { return (this._assignment); }
            set { this._assignment = value; }
        }

        public override string ToString()
        {
            string trainers = string.Empty;
            foreach (var item in Trainer)
            {
                trainers += ",  " + (item);
            }
            string students = string.Empty;
            foreach (var item in Students)
            {
                students += ",  " + (item);
            }
            string assignments = string.Empty;
            foreach (var item in Assignment)
            {
                assignments += ",  " + (item);
            }

            return ($"The {Course} has the following trainers {trainers}. The students attending are {students} " +
                    $"and they have to complete these assignments {assignments}");
        }
    }
}

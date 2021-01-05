using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_B.Models;
using Part_B.Business_Logic;

namespace Part_B
{
    class InputData 
    {
        public InputData()
        {
            StartRecording();
        }
        private void StartRecording()
        {
            Schoolclass schoolclass = new Schoolclass();
            do
            {
                schoolclass.Course = GetCourseInfo();
                schoolclass.Trainer = GetTrainers(schoolclass.Course.Title);
                schoolclass.Students = GetStudents();
                schoolclass.Assignment = GetAssignments();

                SendingDataToDatabase sendingDataToDatabase = new SendingDataToDatabase(schoolclass);

            } while (AskUserToExitRecording());

        }

        //-----------------------------------------------------------------------COURSE--------------------------------------------------------------------------
        public Course GetCourseInfo()
        {
            Course course = new Course();

            Console.WriteLine("---- Recording Course Information ----");
            course.Stream = AskDetail("Please enter the stream: ");
            course.Type = AskDetail("Please enter the type: ");
            course.StartDate = Convert.ToDateTime(AskDetail("Please enter starting date: (i.e. 20/03/2000)"));
            course.EndDate = Convert.ToDateTime(AskDetail("Please enter ending date: (i.e. 20/03/2000)"));
            course.Title = course.Stream + " " + course.Type;
            return (course);
        }
        //-----------------------------------------------------------------------TRAINERS ----------------------------------------------------------------------
        /* Creating List of Trainers for ONE course */
        public List<Trainer> GetTrainers(string course)
        {
            List<Trainer> trainers = new List<Trainer>();
            Console.WriteLine("---- Recording Trainers Information for the course inserted ----");
            do
            {
                trainers.Add(GetTrainerInfo(course));
            }
            while (AskUserToExitRecording());
            return (trainers);
        }
        /* Creating one list item type TRAINER */
        private Trainer GetTrainerInfo(string course)
        {
            Trainer trainer = new Trainer();
            trainer.FirstName = AskDetail("Please enter the first name: ");
            trainer.LastName = AskDetail("Please enter the last name: ");
            trainer.Subject = course;
            return (trainer);
        }
        //-----------------------------------------------------------------------ASSIGNMENT----------------------------------------------------------------------

        public List<Assignment> GetAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            Console.WriteLine("---- Recording Assignment Information for the course inserted----");
            do
            {
                assignments.Add(GetAssignmentInfo());
            }
            while (AskUserToExitRecording());
            return (assignments);
        }

        private Assignment GetAssignmentInfo()
        {
            Assignment assignment = new Assignment();
            assignment.Title = AskDetail("Please enter title: ");
            assignment.Description = AskDetail("Please enter description: ");
            assignment.SubDateTime = Convert.ToDateTime(AskDetail("Please enter submission date: (i.e. 20/03/2000)"));
            assignment.OralMark = (float)Convert.ToDouble(AskDetail($"Please enter Oral's weight factor: "));
            assignment.TotalMark = (float)Convert.ToDouble(AskDetail($"Please enter Mark's weight factor: "));
            return (assignment);
        }

        //-----------------------------------------------------------------------STUDENT-------------------------------------------------------------------------

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            Console.WriteLine("---- Recording Student Information ----");
            do
            {
                students.Add(GetStudentInfo());
            }
            while (AskUserToExitRecording());
            return (students);
        }

        private Student GetStudentInfo()
        {
            Student student = new Student();
            student.FirstName = AskDetail("Please enter the first name: ");
            student.LastName = AskDetail("Please enter the last name: ");
            student.DateOfBirth = Convert.ToDateTime(AskDetail("Please enter the date of birth: "));
            student.TuitionFees = Convert.ToDouble(AskDetail("Please enter the tuition fees: "));
            return (student);
        }
        //-----------------------------------------------------------------------OTHER---------------------------------------------------------------------------
        public bool AskUserToExitRecording()
        {
            bool decideAboutRecording;
            Console.WriteLine("Press any key to continue or ESCAPE to exit recording");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                decideAboutRecording = false;
            }
            else
            {
                decideAboutRecording = true;
            }
            return (decideAboutRecording);
        }
        public string AskDetail(string message, List<string> subjects = null)
        {
            Console.Write(message);
            string result = Console.ReadLine();
            return (result);
        }
    }
}

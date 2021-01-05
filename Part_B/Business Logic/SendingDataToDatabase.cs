using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_B.Models;
using Part_B.Business_Logic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Part_B.Business_Logic
{
    class SendingDataToDatabase
    {
        public SendingDataToDatabase(Schoolclass schoolclass)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection("Data Source = LAPTOP-0D53CULI\\SQLEXPRESS;Initial Catalog = School;Integrated Security = True"))
            {
                conn.Open();
                //sending course data
                using (SqlCommand command = new SqlCommand($"INSERT INTO Courses (Stream, TypeOfCourse, StartDate, EndDate) VALUES ('{schoolclass.Course.Stream}', '{schoolclass.Course.Type}', '{schoolclass.Course.StartDate}', '{schoolclass.Course.EndDate}')", conn))
                {

                    command.ExecuteNonQuery();
                }
                //sending trainers data
                for (i = 0; i < schoolclass.Trainer.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand($"INSERT INTO Trainers (FirstName, LastName, CourseID) VALUES ('{schoolclass.Trainer[i].FirstName}', '{schoolclass.Trainer[i].LastName}', (SELECT TOP 1 CourseID FROM Courses ORDER BY CourseID DESC))", conn))
                    {

                        command.ExecuteNonQuery();
                    }
                }
                //sending students data
                for (i = 0; i < schoolclass.Students.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand($"INSERT INTO Students (FirstName, LastName, TutionFees, DateOfBirth) VALUES ('{schoolclass.Students[i].FirstName}','{schoolclass.Students[i].LastName}', '{schoolclass.Students[i].TuitionFees}', '{schoolclass.Students[i].DateOfBirth}')", conn))
                    {

                        command.ExecuteNonQuery();
                    }
                }
                //sending assignment data
                for (i = 0; i < schoolclass.Assignment.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand($"INSERT INTO Assignments (Title, DescriptionOfAssignment, SubmissionDate, OralMark, TotalMark, CourseID) VALUES ('{schoolclass.Assignment[i].Title}', '{schoolclass.Assignment[i].Description}', '{schoolclass.Assignment[i].SubDateTime}','{schoolclass.Assignment[i].OralMark}', '{schoolclass.Assignment[i].TotalMark}', (SELECT TOP 1 CourseID FROM Courses ORDER BY CourseID DESC))", conn))
                    {

                        command.ExecuteNonQuery();
                    }
                }
                //sending data to the junction table
                using (SqlCommand command1 = new SqlCommand($"SELECT TOP 1 StudentID FROM Students ORDER BY StudentID DESC ", conn))
                {

                    int studentsNum = Convert.ToInt32(command1.ExecuteNonQuery());
                    for (i = 0; i < schoolclass.Students.Count; i++)
                    {
                        using (SqlCommand command = new SqlCommand($"INSERT INTO Student_Course (CourseID, StudentID) VALUES ((SELECT TOP 1 CourseID FROM Courses ORDER BY CourseID DESC), (SELECT StudentID FROM Students WHERE Students.StudentID = '{studentsNum - i}'))", conn))
                        {

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

    }
}

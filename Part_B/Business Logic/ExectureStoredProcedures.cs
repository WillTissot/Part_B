using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using Part_B.Business_Logic;

namespace Part_B.Models
{
    class ConnectionDB
    {
        public ConnectionDB()
        {
            StartPrinting();
        }

        private void StartPrinting()
        {
            //creating a list with all the procedures I want to execute
            List<string> procedures = new List<string>()
            {
                "PrintAllStudents", "PrintAllAssignments", "PrintAllCourses", "PrintAllTrainers", 
                "PrintStudentsPerCourse", "PrintTrainersPerCourse", "PrintAssignmentsPerCourse",
                "PrintStudentsAttendingMoreThanOneCourse", "PrintAssignmentPerCoursePerStudent"
            };
            PrintRequestedQueries(procedures);

            Console.WriteLine("Do you want to insert more data to the existing tables? (Y/N)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                InputData inputData = new InputData();
            }
            else
            {
                Console.WriteLine("Terminating Program");
            }
            
        }

        private void PrintRequestedQueries(List<string> procedures)
        {
            foreach (var item in procedures) //iterate depending on the count of the procedures
            {
                using (SqlConnection conn = new SqlConnection("Data Source = LAPTOP-0D53CULI\\SQLEXPRESS;Initial Catalog = School;Integrated Security = True"))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(item, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr != null)
                            {
                                Console.WriteLine($"Do you want to {item}? (Y/N) "); //asking whether user wants to print
                                string answer = Console.ReadLine();
                                if (answer.ToLower() == "y")
                                {
                                    for (int i = 0; i < rdr.FieldCount; i++)
                                    {
                                        Console.Write($"{rdr.GetName(i), -15} \t"); //printing the field names of the retrieved table from db
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    while (rdr.Read())
                                    {
                                        for (int i = 0; i < rdr.FieldCount; i++)
                                        {
                                            Console.Write($"{rdr[i], -15} \t");//printing the values of the table
                                        }
                                        Console.WriteLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Proceeding...");
                                }
                                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

                            }
                        }
                    }
                }

            }
        }
    }
}

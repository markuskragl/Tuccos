using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    internal class CalculationController : AndritzHydro.Core.Data.SqlBaseController
    {


        /// <summary>
        /// Returns the projects.
        /// </summary>
        public Calculations GetCalculations(string projectId, int? subAssemblyId)
        {
            var result = new Calculations();

            //First: A connection is needed
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                //Second: A command is needed
                using (var command = new System.Data.SqlClient.SqlCommand("GetCalculations", connection))
                {
                    //Configure the command
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@SubAssemblyId", subAssemblyId);
                    //command.Parameters.AddWithValue();

                    //The Sql Server should cache the procedure...
                    command.Prepare();

                    //Don't forget:
                    connection.Open();

                    //Third: (Not needed with INSERT, UPDATE or DELETE: command.ExecuteNonQuery() is used)
                    // - only with SELECT
                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        //Map the data to the data transfer objects
                        while (reader.Read())
                        {
                            result.Add(new Calculation
                            {
                                ProjectId = reader["ProjectId"].ToString(),
                                SubAssemblyId = (int)reader["SubAssemblyId"],
                                CalculationId = (int)reader["CalculationId"],
                                CalculationType = reader["CalculationType"].ToString(),
                            });
                        }
                    }
                }
            }

#if DEBUG
            //for testing multithreading
            System.Threading.Thread.Sleep(this.Context.Random.Next(3000));
#endif
            return result;
        }



        /// <summary>
        /// Adds a project to the database.
        /// </summary>
        /// <param name="project">The project which
        /// should be added.</param>
        public virtual void AddCalculation(Calculation calculation)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("AddCalculation", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProjectId", calculation.ProjectId);
                    command.Parameters.AddWithValue("@SubAssemblyId", calculation.SubAssemblyId);
                    command.Parameters.AddWithValue("@CalculationId", calculation.CalculationId);
                    command.Parameters.AddWithValue("@CalculationType", calculation.CalculationType);

                    command.Prepare();

                    connection.Open();

                    //To ensure that changes only are
                    //saved, if all statements are successfully,
                    //use "Database Transactions" 
                    command.Transaction = connection.BeginTransaction();

                    command.ExecuteNonQuery();

                    //A loop for the rows
                    command.Parameters.Clear();

                    //If the code reaches this line,
                    //every statement was successfully
                    //and can be saved in the database
                    command.Transaction.Commit();
                }
            }
        }



        /// <summary>
        /// Deletes a calculation to the database.
        /// </summary>
        /// <param name="calculation">The project which
        /// should be deleted.</param>
        public virtual void DeleteCalculation(Calculation calculation)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("DeleteCalculation", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CalculationId", calculation.CalculationId);


                    command.Prepare();

                    connection.Open();

                    //To ensure that changes only are
                    //saved, if all statements are successfully,
                    //use "Database Transactions" 
                    command.Transaction = connection.BeginTransaction();

                    command.ExecuteNonQuery();

                    //A loop for the rows
                    command.Parameters.Clear();

                    //If the code reaches this line,
                    //every statement was successfully
                    //and can be saved in the database
                    command.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Returns the orifice calculations.
        /// </summary>
        public Calculations GetOrificeCalculation(int? calcId)
        {
            var result = new Calculations();

            //First: A connection is needed
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                //Second: A command is needed
                using (var command = new System.Data.SqlClient.SqlCommand("GetOrificeCalculation", connection))
                {
                    //Configure the command
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@calculationId", calcId);
                   
                    //command.Parameters.AddWithValue();

                    //The Sql Server should cache the procedure...
                    command.Prepare();

                    //Don't forget:
                    connection.Open();

                    //Third: (Not needed with INSERT, UPDATE or DELETE: command.ExecuteNonQuery() is used)
                    // - only with SELECT
                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        //Map the data to the data transfer objects
                        while (reader.Read())
                        {
                            result.Add(new Calculation
                            {

                             
                                CalculationId = (int)reader["calculationId"],

      



                            });
                        }
                    }
                }
            }

#if DEBUG
            //for testing multithreading
            System.Threading.Thread.Sleep(this.Context.Random.Next(3000));
#endif
            return result;
        }
    }
}

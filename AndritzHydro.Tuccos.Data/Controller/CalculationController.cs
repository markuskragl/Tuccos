using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    internal class CalculationController : AndritzHydro.Core.Data.SqlBaseController
    {

        #region GetCalculation
        /// <summary>
        /// Returns the calculations.
        /// </summary>
        public Calculations GetCalculations(string projectId, int? subAssemblyId)
        {
            var result = new Calculations();

            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("GetCalculations", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@SubAssemblyId", subAssemblyId);

                    command.Prepare();

                    connection.Open();

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
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
            System.Threading.Thread.Sleep(this.Context.Random.Next(3000));
#endif
            return result;
        }


        #endregion GetCalculation

        #region AddCalculation
        /// <summary>
        /// Adds a calculation to the database.
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

                    command.Transaction = connection.BeginTransaction();

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    //If the code reaches this line,
                    //every statement was successfully
                    //and can be saved in the database
                    command.Transaction.Commit();
                }
            }
        }

        #endregion AddCalculation

        #region DeleteCalculation
        /// <summary>
        /// Deletes a calculation to the database.
        /// </summary>
        /// <param name="calculation">The calculation which
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

                    command.Transaction = connection.BeginTransaction();

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    command.Transaction.Commit();
                }
            }
        }

        #endregion DeleteCalculation

        #region GetParameter
        /// <summary>
        /// Returns the orifice calculations.
        /// </summary>
        public Parameters GetParameters(int? calcId)
        {
            var result = new Parameters();

            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                //Second: A command is needed
                using (var command = new System.Data.SqlClient.SqlCommand("GetParameter", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@calculationId", calcId);

                    command.Prepare();

                    connection.Open();

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            result.Add(new Parameter
                            {


                                CalculationId = (int)reader["CalculationId"],
                                ParameterType = reader["ParameterType"].ToString(),
                                ParameterValue = (double)reader["ParameterValue"],
                                ParameterUnit = reader["ParameterUnit"].ToString(),

                            });
                        }
                    }
                }
            }

#if DEBUG
            System.Threading.Thread.Sleep(this.Context.Random.Next(3000));
#endif
            return result;
        }

        #endregion GetParameter

        #region AddParameter
        /// <summary>
        /// Adds a project to the database.
        /// </summary>
        /// <param name="project">The project which
        /// should be added.</param>
        public virtual void AddParameter(Parameter parameter)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("AddParameter", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@CalculationId", parameter.CalculationId);
                    command.Parameters.AddWithValue("@ParameterType", parameter.ParameterType);
                    command.Parameters.AddWithValue("@ParameterValue", parameter.ParameterValue);
                    command.Parameters.AddWithValue("@ParameterUnit", parameter.ParameterUnit);

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
        #endregion AddParameter
    }
}

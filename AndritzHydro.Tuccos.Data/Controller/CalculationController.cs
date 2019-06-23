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

                    command.Transaction.Commit();
                }
            }
        }

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

        /// <summary>
        /// Returns the orifice calculations.
        /// </summary>
        public Calculations GetOrificeCalculation(int? calcId)
        {
            var result = new Calculations();

            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("GetOrificeCalculation", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@calculationId", calcId);

                    command.Prepare();

                    connection.Open();

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
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
            System.Threading.Thread.Sleep(this.Context.Random.Next(3000));
#endif
            return result;
        }
    }
}

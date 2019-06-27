using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    internal class ExampleCalculationController : AndritzHydro.Core.Data.SqlBaseController
    {
        /// <summary>
        /// Returns the Example calculation.
        /// </summary>
        public ExampleCalculations GetExampleCalculations(string calculationId)
        {
            var result = new ExampleCalculations();

            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("GetExampleCalculations", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CalculationId", calculationId);

                    command.Prepare();

                    connection.Open();

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            result.Add(new ExampleCalculation
                            {
                                ProjectId = reader["ProjectId"].ToString(),
                                SubAssemblyId = (int)reader["SubAssemblyId"],
                                CalculationId = reader["CalculationId"].ToString(),
                                CalculationType = reader["CalculationType"].ToString(),
                                CalculationDescription = reader["CalculationDescription"].ToString(),
                                Parametera = (int)reader["Parametera"],
                                Parameterb = (int)reader["Parameterb"],
                                Resultc = (int)reader["Resultc"]
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
        /// Adds a Example Calculation to the database.
        /// </summary>
        /// <param name="exampleCalculation">The exampleCalculation which
        /// should be added.</param>
        public virtual void AddExampleCalculation(ExampleCalculation exampleCalculation)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("AddExampleCalculation", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CalculationId", exampleCalculation.CalculationId);
                    command.Parameters.AddWithValue("@CalculationDescription", exampleCalculation.CalculationDescription);
                    command.Parameters.AddWithValue("@Parametera", exampleCalculation.Parametera);
                    command.Parameters.AddWithValue("@Parameterb", exampleCalculation.Parameterb);
                    command.Parameters.AddWithValue("@Resultc", exampleCalculation.Resultc);

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
        /// Saves a Example Calculation to the database.
        /// </summary>
        /// <param name="exampleCalculation">The exampleCalculation which
        /// should be added.</param>
        public virtual void SaveExampleCalculation(ExampleCalculation exampleCalculation)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("SaveExampleCalculation", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CalculationId", exampleCalculation.CalculationId);
                    command.Parameters.AddWithValue("@CalculationDescription", exampleCalculation.CalculationDescription);
                    command.Parameters.AddWithValue("@Parametera", exampleCalculation.Parametera);
                    command.Parameters.AddWithValue("@Parameterb", exampleCalculation.Parameterb);
                    command.Parameters.AddWithValue("@Resultc", exampleCalculation.Resultc);

                    command.Prepare();

                    connection.Open();

                    command.Transaction = connection.BeginTransaction();

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    command.Transaction.Commit();
                }
            }
        }
    }
}

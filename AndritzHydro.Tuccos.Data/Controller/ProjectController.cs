using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    internal class ProjectController : AndritzHydro.Core.Data.SqlBaseController
    {
        /// <summary>
        /// Returns the supported countries.
        /// </summary>
        /// <param name="language">Code of the language that should be used.</param>
        /// <remarks>Shows how to call a stored procedure.</remarks>
        public Countries GetCountries(string language)
        {
            var result = new Countries();

            //First: A connection is needed
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                //Second: A command is needed
                using (var command = new System.Data.SqlClient.SqlCommand("GetCountries", connection))
                {
                    //Configure the command
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@language", language);

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
                            result.Add(new Country
                            {
                                Code = reader["ISO"].ToString(),
                                Name = reader["Name"].ToString(),
                                MaxNumber = (int)reader["MaxNumber"],
                                NumberCount = (int)reader["NumberCount"]
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

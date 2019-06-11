using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    internal class SubAssemblyController : AndritzHydro.Core.Data.SqlBaseController
    {
        /// <summary>
        /// Returns the projects.
        /// </summary>
        public SubAssemblies GetSubAssemblies()
        {
            var result = new SubAssemblies();

            //First: A connection is needed
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                //Second: A command is needed
                using (var command = new System.Data.SqlClient.SqlCommand("GetSubAssemblies", connection))
                {
                    //Configure the command
                    command.CommandType = System.Data.CommandType.StoredProcedure;
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
                            result.Add(new SubAssembly
                            {
                                SubAssemblyId = (int)reader["SubAssemblyId"],
                                SubAssemblyName = reader["SubAssemblyName"].ToString(),
                                RngNr = (int)reader["RngNr"]
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

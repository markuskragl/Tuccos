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
        /// Returns the subassemblies.
        /// </summary>
        public SubAssemblies GetSubAssemblies()
        {
            var result = new SubAssemblies();

            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("GetSubAssemblies", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Prepare();

                    connection.Open();

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            result.Add(new SubAssembly
                            {
                                SubAssemblyId = (int)reader["SubAssemblyId"],
                                SubAssemblyName = reader["SubAssemblyName"].ToString(),
                                SubAssemblyRngNr = (int)reader["SubAssemblyRngNr"]
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

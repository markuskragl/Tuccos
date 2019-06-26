using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    internal class CalculationTemplateController : AndritzHydro.Core.Data.SqlBaseController
    {
        /// <summary>
        /// Returns the calculation templates.
        /// </summary>
        public CalculationTemplates GetCalculationTemplates(int? SubAssemblyId)
        {
            var result = new CalculationTemplates();

            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("GetCalculationTemplates", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SubAssemblyId", SubAssemblyId);

                    command.Prepare();

                    connection.Open();

                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            result.Add(new CalculationTemplate
                            {
                                CalculationTemplateId = (int)reader["CalculationTemplateId"],
                                SubAssemblyId = (int)reader["SubAssemblyId"],
                                CalculationType = reader["CalculationType"].ToString()
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

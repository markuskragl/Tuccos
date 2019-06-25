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
        /// Returns the projects.
        /// </summary>
        public Projects GetProjectList()
        {
            var result = new Projects();

            //First: A connection is needed
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                //Second: A command is needed
                using (var command = new System.Data.SqlClient.SqlCommand("GetProjectList", connection))
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
                            result.Add(new Project
                            {
                                ProjectId = reader["ProjectId"].ToString(),
                                ProjectName = reader["ProjectName"].ToString(),
                                ProjectYear = (int)reader["ProjectYear"]
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
        public virtual void SaveProject(Project project)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("AddProject", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@ProjectId", project.ProjectId);
                    command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    command.Parameters.AddWithValue("@ProjectYear", project.ProjectYear);

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
        /// Deletes a project to the database.
        /// </summary>
        /// <param name="project">The project which
        /// should be deleted.</param>
        public virtual void DeleteProject(Project project)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand("DeleteProject", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProjectId", project.ProjectId);

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
    }
}

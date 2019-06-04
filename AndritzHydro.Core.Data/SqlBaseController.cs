using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data
{
    /// <summary>
    /// Provides base utilities for creating a Sql Server Controller.
    /// </summary>
    public abstract class SqlBaseController : DataApplicationObject
    {

        /// <summary>
        /// String needed to connect to the database.
        /// </summary>
        private static string _ConnectionString = null;

        /// <summary>
        /// Gets the connection object initialized with
        /// the information provided by the application context.
        /// </summary>
        protected string ConnectionString
        {
            get
            {
                if (SqlBaseController._ConnectionString == null)
                {
                    var builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

                    if (this.Context.DatabasePath == string.Empty)
                    {
                        //The database is attached to the server
                        builder.InitialCatalog = System.IO.Path.GetFileNameWithoutExtension(this.Context.Database);
                    }
                    else
                    {
                        //The database is dynamically attached
                        builder.AttachDBFilename = System.IO.Path.Combine(this.Context.DatabasePath, this.Context.Database);
                    }

                    builder.DataSource = this.Context.SqlServer;

                    //The databases users are managed by the Active Directory,
                    //so no password is needed. Always use this technique.
                    //Only using Microsoft Cloud Azure you need user and password
                    builder.IntegratedSecurity = true;

                    SqlBaseController._ConnectionString = builder.ConnectionString;
                    this.Context.Log.WriteEntry($"{SqlBaseController._ConnectionString} cached...");
                }

                return SqlBaseController._ConnectionString;
            }
        }
    }
}

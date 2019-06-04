using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data
{
    /// <summary>
    /// Provides the infrastructure of database application to other objects.
    /// </summary>
    public class DataApplicationContext : AndritzHydro.Core.ApplicationContext
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private LogManager _Log = null;

        /// <summary>
        /// Gets the application's log manager.
        /// </summary>
        public LogManager Log
        {
            get
            {
                if (this._Log == null)
                {
                    //Because it's an application object, no
                    //this._Log = new LogManager();
                    //-------

                    this._Log = this.Create<LogManager>();
                }

                return this._Log;
            }
        }


        /// <summary>
        /// Returns an inialized application object.
        /// </summary>
        /// <typeparam name="T">Type of the needed object.</typeparam>
        /// <remarks>A log entry is created.</remarks>
        public override T Create<T>()
        {
            var newObject = base.Create<T>();

            //The new entry is not allowed
            //if the LogManager is created,
            //because of there's a recursion...

            if (!(newObject is LogManager))
            {
                this.Log.WriteEntry(
                    $"{newObject} is initialized...",
                    LogEntryType.NewObject);

                //Attach an event handler to ErrorOccurred...
                var errorObject = newObject as AndritzHydro.Core.ApplicationObject;
                if (errorObject != null)
                {
                    errorObject.ErrorOccurred += (sender, e)
                        => this.Log.WriteEntry($"ERROR: {sender}\r\n{e.Reason.Message}", LogEntryType.Error);

                    this.Log.WriteEntry($"{errorObject} handles ErrorOccurred");
                }
            }

            return newObject;
        }

        /// <summary>
        /// Gets or sets the path where the dabasebase file is saved.
        /// </summary>
        /// <remarks>Leave this setting empty 
        /// if it's an attached Sql Server Database.</remarks>
        public string DatabasePath { get; set; }

        /// <summary>
        /// Gets or sets the address of the used sql server.
        /// </summary>
        /// <remarks>Use (LocalDB)\MSSQLLocalDB it the
        /// datebase is attached by the current application.</remarks>
        public string SqlServer { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <remarks>Include the extension, if the
        /// database is attached by the current application.</remarks>
        public string Database { get; set; }

        /// <summary>
        /// Internal field to store the application startup path.
        /// </summary>
        private static string _StartupPath = null;

        /// <summary>
        /// Gets the folder where the application is started from.
        /// </summary>
        public string StartupPath
        {
            get
            {
                if (DataApplicationContext._StartupPath == null)
                {
                    DataApplicationContext._StartupPath
                        = System.IO.Path.GetDirectoryName(
                            System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                }

                return DataApplicationContext._StartupPath;
            }
        }

        /// <summary>
        /// Internal cache for the Create(Type) method.
        /// </summary>
        private System.Reflection.MethodInfo _GenericCreate = null;

        /// <summary>
        /// Returns an inialized application object.
        /// </summary>
        /// <param name="type">Type of the needed object</param>
        public virtual object Create(System.Type type)
        {
            if (this._GenericCreate == null)
            {
                this._GenericCreate = this.GetType().GetMethod("Create", new Type[] { });
                this.Log.WriteEntry("Generic Create<T>() cached...");
            }

            return this._GenericCreate.MakeGenericMethod(type).Invoke(this, null);
        }

        /// <summary>
        /// Gets or set the dispatcher for thread safety in WPF applications.
        /// </summary>
        public object Dispatcher { get; set; }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private static System.Random _Random = null;

        /// <summary>
        /// Gets the application's random generator.
        /// </summary>
        public System.Random Random
        {
            get
            {
                if (DataApplicationContext._Random == null)
                {
                    DataApplicationContext._Random = new System.Random();
                    this.Log.WriteEntry(
                        "The applications random generator was created...", 
                        LogEntryType.NewObject);
                }

                return DataApplicationContext._Random;
            }
        }
    }
}
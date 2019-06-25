using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AndritzHydro.Core.Data;
using AndritzHydro.Tuccos.Data;
using AndritzHydro.Tuccos.Data.Controller;

namespace andritzhydro.web
{
    /// <summary>
    /// Publishes the project logic from Tuccos Data.
    /// </summary>
    public class ProjectsView : System.Web.Services.WebService, IProject
    {
        /// <summary>
        /// Gets the name of the cache used for the web service infrastructure.
        /// </summary>
        private const string AppContextCache = "AppContext";


        /// <summary>
        /// Gets the infrastructure of the web service application.
        /// </summary>
        protected AndritzHydro.Core.Data.DataApplicationContext AppContext
        {
            get
            {
                var appContext = this.Application[ProjectsView.AppContextCache] as AndritzHydro.Core.Data.DataApplicationContext;

                if (appContext == null)
                {
                    appContext = new AndritzHydro.Core.Data.DataApplicationContext();
                    //appContext.Log.Path = System.Web.Configuration.WebConfigurationManager.AppSettings["LogPath"];
                    //              ^-> now, e.g. is ~/app_data/..."
                    //This path is needed locally
                    appContext.Log.Path
                        = this.Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LogPath"]);

                    //Compress and delete old log versions...
                    appContext.Log.CleanUp(5);

                    appContext.Log.WriteEntry("The project web service has been started...");

                    //Map the Database configuration...
                    appContext.Database = System.Web.Configuration.WebConfigurationManager.AppSettings["Database"];
                    appContext.SqlServer = System.Web.Configuration.WebConfigurationManager.AppSettings["SqlServer"];

                    appContext.DatabasePath = System.Web.Configuration.WebConfigurationManager.AppSettings["DatabasePath"];
                    if (appContext.DatabasePath != string.Empty)
                    {
                        appContext.DatabasePath = this.Server.MapPath(appContext.DatabasePath);
                    }

                    //caching of the infrastructure in the web application
                    this.Application[ProjectsView.AppContextCache] = appContext;
                }

                return appContext;
            }
        }

        /// <summary>
        /// Writes an used entry to the log.
        /// </summary>
        /// <param name="caller">Default the calling member</param>
        protected void WriteLogEntry([System.Runtime.CompilerServices.CallerMemberName]string caller = "")
        {
            //this.AppContext.Log.WriteEntry($"{caller} used from {this.Context.Request.UserHostAddress}...");
        }


    #region Project

        /// <summary>
        /// Gets the name of the cache used for the manager providing the project.
        /// </summary>
        private const string ProjectManagerCache = "ProjectManager";

        /// <summary>
        /// Gets the object providing the projects.
        /// </summary>
        protected AndritzHydro.Tuccos.Data.Controller.ProjectManager ProjectManager
        {
            get
            {
                var manager = this.Application[ProjectsView.ProjectManagerCache] as AndritzHydro.Tuccos.Data.Controller.ProjectManager;

                if (manager == null)
                {
                    manager = this.AppContext.Create<AndritzHydro.Tuccos.Data.Controller.ProjectManager>();

                    this.Application[ProjectsView.ProjectManagerCache] = manager;
                    this.AppContext.Log.WriteEntry($"{manager} has been cached...");
                }

                return manager;
            }
        }



        public Projects GetProjectList()
        {
            this.WriteLogEntry();
            return this.ProjectManager.GetProjectList();
        }

        /// <summary>
        /// Add a project to the database.
        /// </summary>
        /// <param name="project">The project which should be saved.</param>
        public void SaveProject(Project project)
        {
            this.WriteLogEntry();
            this.ProjectManager.SaveProject(project);
        }

        /// <summary>
        /// Delete a project from the database.
        /// </summary>
        /// <param name="project">The project which should be deleted.</param>
        public void DeleteProject(Project project)
        {
            this.WriteLogEntry();
            this.ProjectManager.DeleteProject(project);
        }
    #endregion Project


    #region SubAssembly
        /// <summary>
        /// Gets the name of the cache used for the manager providing the SubAssembly.
        /// </summary>
        private const string SubAssemblyManagerCache = "SubAssemblyManager";


        /// <summary>
        /// Gets the object providing the SubAssembly.
        /// </summary>
        protected AndritzHydro.Tuccos.Data.Controller.SubAssemblyManager SubAssemblyManager
        {
            get
            {
                var manager = this.Application[ProjectsView.SubAssemblyManagerCache] as AndritzHydro.Tuccos.Data.Controller.SubAssemblyManager;

                if (manager == null)
                {
                    manager = this.AppContext.Create<AndritzHydro.Tuccos.Data.Controller.SubAssemblyManager>();

                    this.Application[ProjectsView.SubAssemblyManagerCache] = manager;
                    this.AppContext.Log.WriteEntry($"{manager} has been cached...");
                }

                return manager;
            }
        }


        public SubAssemblies GetSubAssemblies()
        {
            this.WriteLogEntry();
            return this.SubAssemblyManager.GetSubAssemblies();
        }

    #endregion SubAssembly


    #region CalculationTemplates
            /// <summary>
            /// Gets the name of the cache used for the manager providing the calculation templates.
            /// </summary>
            private const string CalculationTemplateManagerCache = "CalculationTemplateManager";
            /// <summary>
            /// Gets the object providing the projects.
            /// </summary>
            protected AndritzHydro.Tuccos.Data.Controller.CalculationTemplateManager CalculationTemplateManager
            {
                get
                {
                    var manager = this.Application[ProjectsView.SubAssemblyManagerCache] as AndritzHydro.Tuccos.Data.Controller.CalculationTemplateManager;

                    if (manager == null)
                    {
                        manager = this.AppContext.Create<AndritzHydro.Tuccos.Data.Controller.CalculationTemplateManager>();

                        this.Application[ProjectsView.SubAssemblyManagerCache] = manager;
                        this.AppContext.Log.WriteEntry($"{manager} has been cached...");
                    }

                    return manager;
                }
            }

            /// <summary>
            /// Gets all CalculationTemplates to the database.
            /// </summary>
            /// <param name="SubId">The calculation template which should be provided with this subassembly.</param>
            public CalculationTemplates GetCalculationTemplates(int? subId)
            {
                this.WriteLogEntry();
                return this.CalculationTemplateManager.GetCalculationTemplates(subId);
            }

        #endregion CalculationTemplates


    #region Calculation
        /// <summary>
        /// Gets the name of the cache used for the manager providing the Calculation.
        /// </summary>
        private const string CalculationManagerCache = "CalculationManager";


        /// <summary>
        /// Gets the object providing the calculations.
        /// </summary>
        protected AndritzHydro.Tuccos.Data.Controller.CalculationManager CalculationManager
        {
            get
            {
                var manager = this.Application[ProjectsView.SubAssemblyManagerCache] as AndritzHydro.Tuccos.Data.Controller.CalculationManager;

                if (manager == null)
                {
                    manager = this.AppContext.Create<AndritzHydro.Tuccos.Data.Controller.CalculationManager>();

                    this.Application[ProjectsView.SubAssemblyManagerCache] = manager;
                    this.AppContext.Log.WriteEntry($"{manager} has been cached...");
                }

                return manager;
            }
        }


        /// <summary>
        /// Gets all Calculations to the database.
        /// </summary>
        /// <param name="subassemblyId">The calculation which should be provided with this project & subassembly id.</param>
        public Calculations GetCalculations(string projectId, int? subassemblyId)
        {
            this.WriteLogEntry();
            return this.CalculationManager.GetCalculations(projectId, subassemblyId);
        }


        /// <summary>
        /// Add a project to the database.
        /// </summary>
        /// <param name="project">The project which should be saved.</param>
        public void AddCalculation(Calculation calculation)
        {
            this.WriteLogEntry();
            this.CalculationManager.AddCalculation(calculation);
        }


        /// <summary>
        /// Deletes a calculation from the database.
        /// </summary>
        /// <param name="calculation">The Calculation which should be deleted.</param>
        public void DeleteCalculation(Calculation calculation)
        {
            this.WriteLogEntry();
            this.CalculationManager.DeleteCalculation(calculation);
        }


        /// <summary>
        /// Gets all OrificeCalculations to the database.
        /// </summary>
        /// <param name="calcId">The Ocalculation which should be provided with this calcualtion id.</param>
        public Calculations GetOrificeCalculation(int? calcId)
        {
            this.WriteLogEntry();
            return this.CalculationManager.GetOrificeCalculation(calcId);
        }


        #endregion Calculation



        /// <summary>
        /// Gets the name of the cache used for the manager providing the calculation templates.
        /// </summary>
        private const string ExampleCalculationManagerCache = "ExampleCalculationManager";
        /// <summary>
        /// Gets the object providing the projects.
        /// </summary>
        protected AndritzHydro.Tuccos.Data.Controller.ExampleCalculationManager ExampleCalculationManager
        {
            get
            {
                var manager = this.Application[ProjectsView.SubAssemblyManagerCache] as AndritzHydro.Tuccos.Data.Controller.ExampleCalculationManager;

                if (manager == null)
                {
                    manager = this.AppContext.Create<AndritzHydro.Tuccos.Data.Controller.ExampleCalculationManager>();

                    this.Application[ProjectsView.SubAssemblyManagerCache] = manager;
                    this.AppContext.Log.WriteEntry($"{manager} has been cached...");
                }

                return manager;
            }
        }

        /// <summary>
        /// Gets all ExampleCalculations to the database.
        /// </summary>
        /// <param name="calcId">The calculation which should be provided with this calcualtion id.</param>
        public ExampleCalculations GetExampleCalculations(int calcId)
        {
            this.WriteLogEntry();
            return this.ExampleCalculationManager.GetExampleCalculations(calcId);
        }


        /// <summary>
        /// Gets all ExampleCalculations to the database.
        /// </summary>
        /// <param name="a, b">The calculation which should be provided with this calcualtion id.</param>
        public int ExampleCalculationSum(int a, int b)
        {
            this.WriteLogEntry();
            var execalc = new AndritzHydro.Tuccos.Data.Controller.ExampleCalculationExecute();

            return execalc.ExampleCalculationSum(a, b);
        }

        public void AddExampleCalculation(ExampleCalculation exampleCalculation)
        {
            this.WriteLogEntry();
            this.ExampleCalculationManager.AddExampleCalculation(exampleCalculation);
        }
    }
}

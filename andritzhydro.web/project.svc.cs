using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AndritzHydro.Core.Data;
using AndritzHydro.Tuccos.Data;

namespace andritzhydro.web
{
    /// <summary>
    /// Publishes the lottery logic from Part Two Data.
    /// </summary>
    public class ProjectsView : System.Web.Services.WebService, IProject
    {
        /// <summary>
        /// Gets the name of the cache used for the web service infrastructure.
        /// </summary>
        private const string AppContextCache = "AppContext";

        /// <summary>
        /// Gets the name of the cache used for the manager providing the lottery game.
        /// </summary>
        private const string ManagerCache = "LotteryManager";

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

                    appContext.Log.WriteEntry("The lottery web service has been started...");

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
        /// Gets the object providing the lottery game.
        /// </summary>
        protected AndritzHydro.Tuccos.Data.Controller.ProjectManager Manager
        {
            get
            {
                var manager = this.Application[ProjectsView.ManagerCache] as AndritzHydro.Tuccos.Data.Controller.ProjectManager;

                if (manager == null)
                {
                    manager = this.AppContext.Create<AndritzHydro.Tuccos.Data.Controller.ProjectManager>();

                    this.Application[ProjectsView.ManagerCache] = manager;
                    this.AppContext.Log.WriteEntry($"{manager} has been cached...");
                }

                return manager;
            }
        }


        /// <summary>
        /// Returns the supported countries.
        /// </summary>
        /// <param name="language">Microsoft code of the used language.</param>
        public Countries GetCountries(string language)
        {
            this.WriteLogEntry();
            return this.Manager.GetCountries(language);
        }




        /// <summary>
        /// Writes an used entry to the log.
        /// </summary>
        /// <param name="caller">Default the calling member</param>
        protected void WriteLogEntry([System.Runtime.CompilerServices.CallerMemberName]string caller = "")
        {
            this.AppContext.Log.WriteEntry($"{caller} used from {this.Context.Request.UserHostAddress}...");
        }

    }
}

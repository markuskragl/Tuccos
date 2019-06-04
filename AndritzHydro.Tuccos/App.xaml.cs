using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

//To access our extensions...
using AndritzHydro.Core.Extensions;
using AndritzHydro.Core.Data.Extensions;

namespace AndritzHydro.Tuccos
{
    /// <summary>
    /// Controls the AndritzHydro Part Two Client/Server Application.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The main entry point.
        /// </summary>
        [System.STAThread()]
        private static void Main()
        {
            //Start up the infrastructure...
            var appContext = new AndritzHydro.Core.Data.DataApplicationContext();
            appContext.Log.WriteEntry($"The {appContext.GetTitle()} is starting...");

            //#region Map configuration setting to the infrastructure

            //if (!AndritzHydro.Tuccos.Properties.Settings.Default.UseWebService)
            //{
            //    appContext.Database = AndritzHydro.Tuccos.Properties.Settings.Default.Database;
            //    appContext.SqlServer = AndritzHydro.Tuccos.Properties.Settings.Default.SqlServer;

            //    var databasePath = AndritzHydro.Tuccos.Properties.Settings.Default.DatabasePath;

            //    if (databasePath != string.Empty && !System.IO.Path.IsPathRooted(databasePath))
            //    {
            //        databasePath = appContext.StartupPath.CreatePath(databasePath);
            //    }

            //    appContext.DatabasePath = databasePath;

            //    const string logPattern = "Database Settings:\r\n Sql Server: {0}\r\n Database: {1}\r\n {2}";
            //    appContext.Log.WriteEntry(
            //        string.Format(
            //            logPattern,
            //            appContext.SqlServer,
            //            appContext.Database,
            //            appContext.DatabasePath != string.Empty ? appContext.DatabasePath : string.Empty
            //            ),
            //        Core.Data.LogEntryType.Busy);
            //}

            //#endregion

            appContext.Language.Current
                = appContext.Language.List.Find(
                    AndritzHydro.Tuccos.Properties.Settings.Default.CurrentLanguage);

            var originalLanguage = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

            //To change the language for the user interface...
            System.Threading.Thread.CurrentThread.CurrentUICulture
                = new System.Globalization.CultureInfo(appContext.Language.Current.Code);
            //To change number formatting also...
            System.Threading.Thread.CurrentThread.CurrentCulture
                = System.Threading.Thread.CurrentThread.CurrentUICulture;

            if (originalLanguage != appContext.Language.Current.Code)
            {
                //We have to empty the language cache
                //for using the same language as in the new UICulture
                appContext.Log.WriteEntry("Empty the language cache to translate the languages...");
                appContext.Language.Refresh();
                appContext.Log.WriteEntry("Infrastructure languages translated...");
            }

            appContext.Log.WriteEntry($"The UI language set to \"{appContext.Language.Current.Name}\".");

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name !=
                System.Threading.Thread.CurrentThread.CurrentCulture.Name)
            {
                appContext.Log.WriteEntry(
                    "UI Culture is different to the number formatting culture!",
                    Core.Data.LogEntryType.Warning);
            }

            //Necessary to read the resources...
            var mvvmApp = new AndritzHydro.Tuccos.App();
            mvvmApp.InitializeComponent();
            appContext.Log.WriteEntry("App resources initialized...");

            //To ensure thread safety...
            appContext.Dispatcher = mvvmApp.Dispatcher;

            var viewModel = appContext.Create<ViewModels.WindowManager>();
            viewModel.StartUp<MainWindow>();

            //Save the changed configuration content
            AndritzHydro.Tuccos.Properties.Settings.Default.CurrentLanguage
                = appContext.Language.Current.Code;
            AndritzHydro.Tuccos.Properties.Settings.Default.Save();

            //Shutdown the infrastructure...
            appContext.Shutdown();
        }
    }
}

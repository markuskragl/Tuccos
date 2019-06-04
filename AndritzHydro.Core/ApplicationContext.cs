using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//To active extension the using - directive keyword is needed
using AndritzHydro.Core.Extensions;

namespace AndritzHydro.Core
{
    /// <summary>
    /// Provides the infrastructer of 
    /// the application to other objects.
    /// </summary>
    /// <remarks>This should be the first object which is initialized by an application.</remarks>
    public class ApplicationContext
    {
        /// <summary>
        /// Internal field for the Language Manager of the application.
        /// </summary>
        private LanguageManager _Language = null;

        /// <summary>
        /// Gets the Language Manager of the application.
        /// </summary>
        public LanguageManager Language
        {
            get
            {
                if (this._Language == null)
                {
                    /*
                    this._Language = new LanguageManager();
                    this._Language.Context = this;
                    */
                    this._Language = this.Create<LanguageManager>();
                }

                return this._Language;
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private WindowManager _Windows = null;

        /// <summary>
        /// Gets the window manager of the application.
        /// </summary>
        public WindowManager Windows
        {
            get
            {
                if (this._Windows == null)
                {
                    /*
                    this._Windows = new WindowManager();
                    this._Windows.Context = this;
                    */
                    this._Windows = this.Create<WindowManager>();
                }

                return this._Windows;
            }
        }

        //We want a special method to create other application objects
        //We don't want to this
        //public object Create(Type className)...
        //          ^-> "late binding" and casting is needed

        //This can't be done...
        //public WindowManager CreateWindowManager...
        //public LanguageManager CreateLanguageManger...
        //          ^-> we don't know which other types are needed

        //Solution:

        /// <summary>
        /// Returns an inialized application object.
        /// </summary>
        /// <typeparam name="T">Type of the needed object</typeparam>
        /// <returns>An object where the Context property 
        /// is set to this ApplicationContext object</returns>
        //public T Create<T>() where T: AndritzHydro.Core.ApplicationObject, new()
        //                                          ^-> Problem, if a class provides the Context property but
        //                                              it's no extension of Application
        //                                              Solution: work with an interface
        public virtual T Create<T>() where T : AndritzHydro.Core.IApplicationObject, new()
        //      ^-> 12/19/2018 needed in AndritzHydro.Core.Data to override this member
        {
            //It's not possible until "new()" constraint...
            var result = new T();

            //This works...
            //var result = System.Activator.CreateInstance<T>();

#if DEBUG
            System.Console.WriteLine(result.GetType().FullName + " initialized...");
#endif

            //Because of the implementation of IApplicationObject interface
            result.Context = this;

            //Because of many Objects can implement IApplicationObject 
            //but have no ErrorOccurred Event...
            if (result is ApplicationObject)
            {
                //automatically add an event handler to ErrorOccurred
                //with an anonymous  method
                var applicationObject = result as AndritzHydro.Core.ApplicationObject;

                applicationObject.ErrorOccurred
                    += (sender, e) => System.Console.WriteLine("ERROR: " + e.Reason.Message);
            }


            return result;
            //return default(T);
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private static string _AppDataLocal = null;

        /// <summary>
        /// Gets the users local AppData folder
        /// to save files without asking the user.
        /// </summary>
        public  string AppDataLocal
        {
            get
            {

                if (ApplicationContext._AppDataLocal == null)
                {
                    ApplicationContext._AppDataLocal 
                        = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                    //Convention in AppData: Add:
                    // - Company
                    // - Application
                    // - Version
                    ApplicationContext._AppDataLocal 
                        = System.IO.Path.Combine(
                            ApplicationContext._AppDataLocal, 
                            this.GetCompany(),
                            this.GetTitle(),
                            this.GetVersion());

                    System.Console.WriteLine("ApplicationContext chached the AppDataLocal folder...");
                }

                //To ensure the existence of the folder
                System.IO.Directory.CreateDirectory(ApplicationContext._AppDataLocal);

                return ApplicationContext._AppDataLocal;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private static string _AppData = null;

        /// <summary>
        /// Gets the users roaming AppData folder
        /// to save files without asking the user.
        /// </summary>
        public string AppData
        {
            get
            {

                if (ApplicationContext._AppData == null)
                {
                    ApplicationContext._AppData
                        = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    //Convention in AppData: Add:
                    // - Company
                    // - Application
                    // - Version
                    ApplicationContext._AppData
                        = System.IO.Path.Combine(
                            ApplicationContext._AppData,
                            this.GetCompany(),
                            this.GetTitle(),
                            this.GetVersion());

                    System.Console.WriteLine("ApplicationContext chached the AppData folder...");
                }

                //To ensure the existence of the folder
                System.IO.Directory.CreateDirectory(ApplicationContext._AppData);

                return ApplicationContext._AppData;
            }
        }

        /// <summary>
        /// Performs needed actions if the application quits.
        /// </summary>
        /// <remarks>e.g. The window list is saved into a file.</remarks>
        public void Shutdown()
        {
            //Don't use this.Windows because of 
            //a new object is initialized but not needed
            if (this._Windows != null)
            {
                this._Windows.Save();
            }

            //Add more needed calls here
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private static string _AppPath = null;

        /// <summary>
        /// Gets the startup folder of the application.
        /// </summary>
        public string AppPath
        {
            get
            {
                if (ApplicationContext._AppPath == null)
                {
                    ApplicationContext._AppPath 
                        = System.IO.Path.GetDirectoryName(
                            System.Diagnostics.Process.GetCurrentProcess()
                                .MainModule.FileName);
                }

                return ApplicationContext._AppPath;
            }
        }

    }
}

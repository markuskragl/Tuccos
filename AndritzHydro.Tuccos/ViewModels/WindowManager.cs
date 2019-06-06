using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.ViewModels
{
    /// <summary>
    /// Controls the views of the 
    /// AndritzHydro C# Part Two Client - Server Application.
    /// </summary>
    public class WindowManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        /// <summary>
        /// Used for the window manager.
        /// </summary>
        private const string _WindowName = "MainWindow";

        /// <summary>
        /// Internal field to remember the type of StartUp
        /// </summary>
        private System.Type _MainWindowType = null;

        /// <summary>
        /// Gets or set the type of a new window.
        /// </summary>
        public System.Type MainWindowType
        {
            get
            {
                return this._MainWindowType;
            }
            set
            {
                this._MainWindowType = value;
            }
        }

        /// <summary>
        /// Initializes the user interfaces
        /// showing the main window.
        /// </summary>
        /// <param name="mainUI">WPF Window bound to this window manager.</param>
        public void StartUp<T>() where T : System.Windows.Window, new()
        {

            this.SetBusyOn();

            //Save the type to the field
            //if there are new windows to open
            this._MainWindowType = typeof(T);

            var w = new T();

            //Because of there are troubles formatting dates
            //in XML, don't forget to set the Language in XAML...
            w.Language
                = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentCulture.IetfLanguageTag);

            //To link the view to the view model
            w.DataContext = this;

            //Set the current Task to the configuration value...
            //this.SetCurrentTask(Properties.Settings.Default.DefaultTask);

            this.InitializeWindow(w);

            this.SetBusyOff();
            System.Windows.Application.Current.Run(w);
        }

        /// <summary>
        /// Prepare an application window
        /// </summary>
        /// <param name="window">WPF Window to be prepared.</param>
        protected void InitializeWindow(System.Windows.Window window)
        {
            this.SetBusyOn();
            //Search the first free number in the opened windows...
            //(from w in System.Windows.Application.Current.Windows)
            //                                                 ^-> here's no implementation for LINQ
            //Therefore build a help array
            var allWindows = new System.Collections.ArrayList(System.Windows.Application.Current.Windows.Count);
            foreach (System.Windows.Window w in System.Windows.Application.Current.Windows)
            {
                allWindows.Add(w.Name);
            }
            var firstFreeNumber = 1;

            while (allWindows.Contains(WindowManager._WindowName + firstFreeNumber))
            {
                firstFreeNumber++;
            }

            //For the window manager
            window.Name = WindowManager._WindowName + firstFreeNumber;

            this.RestorePosition(window);
            window.Closing += (sender, e) =>
            {
                this.SavePosition(window);

                //For not creating memory leaks, we
                //have to release the datacontext...
                window.DataContext = null;
                //No the Garbage Collection is able
                //to dispose our window and demand of memory
                //should decrease...
            };

            this.SetBusyOff();
        }

        /// <summary>
        /// Restores the old window position and state.
        /// </summary>
        /// <param name="window">Reference to the window
        /// which postion is to be restore</param>
        protected virtual void RestorePosition(System.Windows.Window window)
        {
            var p = this.Context.Windows.GetPosition(window.Name);

            if (p != null)
            {
                window.Left = p.Left.HasValue ? p.Left.Value : window.Left;
                window.Top = p.Top.HasValue ? p.Top.Value : window.Top;

                window.Width = p.Width.HasValue ? p.Width.Value : window.Width;
                window.Height = p.Heigth.HasValue ? p.Heigth.Value : window.Height;

                if ((System.Windows.WindowState)p.State == System.Windows.WindowState.Maximized)
                {
                    window.WindowState = System.Windows.WindowState.Maximized;
                }
                else
                {
                    window.WindowState = System.Windows.WindowState.Normal;
                }

                this.Context.Log.WriteEntry($"{window.Name}: Old window position and state restored...");
            }
        }

        /// <summary>
        /// Stores the current size and state in the window manager.
        /// </summary>
        /// <param name="window">Reference to the window which
        /// position has to be saved.</param>
        protected virtual void SavePosition(System.Windows.Window window)
        {
            var p = new AndritzHydro.Core.Data.Window();

            p.Name = window.Name;
            p.State = (int)window.WindowState;

            if (window.WindowState == System.Windows.WindowState.Normal)
            {
                p.Left = (int)window.Left;
                p.Top = (int)window.Top;
                p.Width = (int)window.Width;
                p.Heigth = (int)window.Height;
            }

            this.Context.Windows.SetPosition(p);

            this.Context.Log.WriteEntry($"{window.Name}: State and size of the window saved...");
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Tuccos.Helpers.Command _NewWindow = null;

        /// <summary>
        /// Gets the command to open a new window.
        /// </summary>
        public AndritzHydro.Tuccos.Helpers.Command NewWindow
        {
            get
            {
                if (this._NewWindow == null)
                {
                    this._NewWindow = new AndritzHydro.Tuccos.Helpers.Command(this.NewWindowExecute);
                    this.Context.Log.WriteEntry(
                        "NewWindow Command",
                        Core.Data.LogEntryType.NewObject);
                }

                return this._NewWindow;
            }
        }

        /// <summary>
        /// Opens a new main window
        /// </summary>
        /// <param name="parameter">Data of data binding</param>
        protected virtual void NewWindowExecute(object parameter)
        {
            this.SetBusyOn();
            var w = System.Activator.CreateInstance(this._MainWindowType)
                    as System.Windows.Window;

            var vm = this.Context.Create<ViewModels.WindowManager>();
            vm.MainWindowType = this._MainWindowType;

            //To help XAML for correct data formatting...
            w.Language
                = System.Windows.Markup.XmlLanguage.GetLanguage(
                    System.Threading.Thread.CurrentThread.CurrentCulture.IetfLanguageTag);

            w.DataContext = vm;
            vm.SetCurrentTask(Properties.Settings.Default.DefaultTask);

            this.InitializeWindow(w);

            w.Show();
            this.SetBusyOff();
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Tuccos.Helpers.Command _CloseWindows = null;

        /// <summary>
        /// Gets the command to close all open windows.
        /// </summary>
        /// <remarks>Only possible, if more than one window is open.</remarks>
        public AndritzHydro.Tuccos.Helpers.Command CloseWindows
        {
            get
            {
                if (this._CloseWindows == null)
                {
                    this._CloseWindows
                        = new AndritzHydro.Tuccos.Helpers.Command(
                            this.CloseWindowsExecute,
                            this.CloseWindowsCanExecute);
                    this.Context.Log.WriteEntry(
                        "CloseWindows Command",
                        Core.Data.LogEntryType.NewObject);
                }

                return this._CloseWindows;
            }
        }

        /// <summary>
        /// Closes all open windows
        /// </summary>
        /// <param name="parameter">Data from data binding</param>
        protected virtual void CloseWindowsExecute(object parameter)
        {
            var answer = System.Windows.MessageBox.Show(
                AndritzHydro.Tuccos.Properties.Strings.CloseWindowsQuestion,
                AndritzHydro.Tuccos.Properties.Strings.AppTitle,
                System.Windows.MessageBoxButton.YesNo,
                System.Windows.MessageBoxImage.Question);

            if (answer == System.Windows.MessageBoxResult.Yes)
            {
                foreach (System.Windows.Window w in System.Windows.Application.Current.Windows)
                {
                    w.Close();
                }
            }
        }

        /// <summary>
        /// Returns a bool if CloseWindows is allowed. 
        /// </summary>
        /// <param name="parameter">Data from data binding</param>
        /// <returns>True if there are more than one windows open.</returns>
        protected virtual bool CloseWindowsCanExecute(object parameter)
        {
            return System.Windows.Application.Current.Windows.Count > 1;
        }

        /// <summary>
        /// Gets or sets the current language of the applicaiton.
        /// </summary>
        /// <remarks>If the language is changed an information
        /// to restart is shown.</remarks>
        public AndritzHydro.Core.Data.Language CurrentLanguage
        {
            get
            {
                return this.Context.Language.Current;
            }
            set
            {
                if (this.Context.Language.Current != value)
                {
                    this.Context.Language.Current = value;

                    System.Windows.MessageBox.Show(
                        AndritzHydro.Tuccos.Properties.Strings.RestartApp,
                        AndritzHydro.Tuccos.Properties.Strings.AppTitle,
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Information);

                    this.Context.Log.WriteEntry(
                        $"Restart the application switching to {value.Name}!",
                        Core.Data.LogEntryType.Error);

                    //We have to inform WPF that the
                    //property was changed
                    this.OnPropertyChanged("CurrentLanguage");
                }
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Model.TaskManager _Tasks = null;

        /// <summary>
        /// Gets the Task manager of the application.
        /// </summary>
        public Model.TaskManager Tasks
        {
            get
            {
                if (this._Tasks == null)
                {
                    this._Tasks = this.Context.Create<Model.TaskManager>();
                }

                return this._Tasks;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Model.Task _CurrentTask = null;

        /// <summary>
        /// Gets or set the task which the user has selected.
        /// </summary>
        public Model.Task CurrentTask
        {
            get
            {
                if (this._CurrentTask == null && this.Tasks.List.Count > 0)
                {
                    this._CurrentTask = this.Tasks.List[0];
                }

                return this._CurrentTask;
            }
            set
            {
                if (this._CurrentTask != value)
                {
                    this._CurrentTask = value;
                    this.Context.Log.WriteEntry($"Task \"{this._CurrentTask.Title}\" is selected...");

                    //if the new current task is the Log Viewer we'll switch off unread errors
                    //to switch of the error LED
                    if (this._CurrentTask.ViewerType == typeof(LogViewer))
                    {
                        this.Context.Log.UnreadError = false;
                    }

                    this.OnPropertyChanged("Countries");
                    this.OnPropertyChanged("CurrentTask");
                    this.OnPropertyChanged("CurrentViewer");
                }
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Windows.Controls.UserControl _CurrentViewer = null;

        /// <summary>
        /// Gets the viewer used for the current task.
        /// </summary>
        public System.Windows.Controls.UserControl CurrentViewer
        {
            get
            {

                if (this._CurrentViewer == null
                    || (this._CurrentViewer.GetType() != this.CurrentTask.ViewerType
                    && this.CurrentTask.Viewer == null))
                {
                    this._CurrentViewer = System.Activator.CreateInstance(this.CurrentTask.ViewerType)
                        as System.Windows.Controls.UserControl;

                    this.CurrentTask.Viewer = this._CurrentViewer;
                }
                else
                {
                    this._CurrentViewer = this.CurrentTask.Viewer;
                }
                return this.CurrentTask.Viewer;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Tuccos.Helpers.Command _CloseOtherWindows = null;

        /// <summary>
        /// Gets the command to close all other windows.
        /// </summary>
        public AndritzHydro.Tuccos.Helpers.Command CloseOtherWindows
        {
            get
            {
                if (this._CloseOtherWindows == null)
                {
                    this.SetBusyOn();

                    this._CloseOtherWindows = new AndritzHydro.Tuccos.Helpers.Command(data =>
                    {
                        this.SetBusyOn();

                        foreach (System.Windows.Window w in System.Windows.Application.Current.Windows)
                        {
                            if (w != data)
                            {
                                w.Close();
                            }
                        }

                        this.SetBusyOff();
                    }, data => System.Windows.Application.Current.Windows.Count > 1);

                    this.SetBusyOff();
                }

                return this._CloseOtherWindows;
            }
        }



        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private ProjectManager _Project = null;

        /// <summary>
        /// Gets the view model to control the lottery UI.
        /// </summary>
        public ProjectManager Project
        {
            get
            {

                if (this._Project == null)
                {
                    this.SetBusyOn();

                    this._Project = this.Context.Create<ProjectManager>();
                    this._Project.Owner = this;

                    this.SetBusyOff();
                }
                this.OnPropertyChanged("CurrentTask");
                this.OnPropertyChanged("CurrentViewer");
                return this._Project;
            }
        }

        /// <summary>
        /// Sets the task with the index as current task.
        /// </summary>
        /// <param name="index">Index of the task that should be selected.</param>
        public void SetCurrentTask(int index)
        {
            if (index >= 0 && index < this.Tasks.List.Count)
            {
                this.CurrentTask = this.Tasks.List[index];
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Tuccos.Helpers.Command _SetDefaulTask = null;

        /// <summary>
        /// Gets the command to set the selected task as default task.
        /// </summary>
        public AndritzHydro.Tuccos.Helpers.Command SetDefaultTask
        {
            get
            {
                if (this._SetDefaulTask == null)
                {
                    this.SetBusyOn();
                    this._SetDefaulTask = new AndritzHydro.Tuccos.Helpers.Command(
                        data =>
                        {
                            this.SetBusyOn();

                            Properties.Settings.Default.DefaultTask = this.Tasks.List.IndexOf(this.CurrentTask);
                            this.Context.Log.WriteEntry($"{this.CurrentTask.Title} set as default task");

                            this.SetBusyOff();
                        });
                    this.SetBusyOff();
                }

                return this._SetDefaulTask;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core
{
    /// <summary>
    /// Manages the applications window list.
    /// </summary>
    public class WindowManager : AndritzHydro.Core.ApplicationObject
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        /// <summary>
        /// Gets the suffix for the window names
        /// depanding on multiple monitors environment.
        /// </summary>
        protected string MonitorKey
        {
            get
            {
                const int SM_CMONITORS = 80;

                return $"_M{WindowManager.GetSystemMetrics(SM_CMONITORS)}";
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Data.WindowList _Windows = null;

        /// <summary>
        /// Gets the managed window list.
        /// </summary>
        protected Data.WindowList Windows
        {
            get
            {
                if (this._Windows == null)
                {
                    this._Windows = this.Read();
#if DEBUG
                    System.Console.WriteLine(this.GetType().FullName + " initialized the window list...");
#endif
                }

                return this._Windows;
            }
        }

        /// <summary>
        /// Adds or refreshes the window in the managers window list.
        /// </summary>
        /// <param name="window">Window object to use</param>
        /// <remarks>window.Name is used as key</remarks>
        public void SetPosition(Data.Window window)
        {
            //Is there an entry for the window?
            var w = this.Windows.Find(window.Name + this.MonitorKey);

            //If not, we have to add the window
            if (w == null)
            {
                window.Name += this.MonitorKey;
                this.Windows.Add(window);
            }
            //Else we have to refresh the properties
            else
            {
                //Left, Top, Width and Height only should
                //be changed, if a new value is available...
                w.Left = window.Left.HasValue ? window.Left : w.Left;
                w.Top = window.Top.HasValue ? window.Top : w.Top;
                w.Width = window.Width.HasValue ? window.Width : w.Width;
                w.Heigth = window.Heigth.HasValue ? window.Heigth : w.Heigth;

                w.State = window.State;
            }
        }

        /// <summary>
        /// Returns the object with the 
        /// information of the postion from the window.
        /// </summary>
        /// <param name="name">Key to find the window</param>
        /// <returns>null, if no window with this name exists.</returns>
        public Data.Window GetPosition(string name)
        {
            return this.Windows.Find(name + this.MonitorKey);
        }

        /// <summary>
        /// Writes the information from the windows 
        /// into a file on the disk.
        /// </summary>
        /// <remarks>DefaultPath is used.</remarks>
        public void Save()
        {
            this.Controller.SaveAsXml(this.Windows, this.DefaultPath);
        }

        /// <summary>
        /// Restores the internal window list
        /// from a file on the disk.
        /// </summary>
        /// <remarks>DefaultPath is used.</remarks>
        protected Data.WindowList Read()
        {
            return this.Controller.ReadXml(this.DefaultPath);
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private string _DefaultPath = null;

        /// <summary>
        /// Gets the filename where the window list is saved.
        /// </summary>
        /// <remarks>It's the users default local AppData folder.</remarks>
        public string DefaultPath
        {
            get
            {
                if (this._DefaultPath == null)
                {
                    this._DefaultPath 
                        = System.IO.Path.Combine(
                            this.Context.AppDataLocal, 
                            "Window List.xml");
                }

                return this._DefaultPath;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Core.Controller.WindowController _Controller = null;

        /// <summary>
        /// Gets the Xml Controller to get or write the window list to a file.
        /// </summary>
        /// <remarks>Because of the "private" WindowController this
        /// property also has to be private (Security).</remarks>
        private AndritzHydro.Core.Controller.WindowController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Context.Create<AndritzHydro.Core.Controller.WindowController>();
                    System.Console.WriteLine("WindowManager created and cached the controller...");
                }

                return this._Controller;
            }
        }
    }
}

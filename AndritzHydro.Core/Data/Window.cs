using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data
{
    /// <summary>
    /// Stores the windows of an application
    /// </summary>
    public class WindowList : System.Collections.Generic.List<Window>
    {
        /// <summary>
        /// Returns the window with the given name.
        /// </summary>
        /// <param name="name">The name of the window which is needed.</param>
        /// <returns>null, if the window doesn't exist</returns>
        /// <remarks>Here a "Lambda Expression Tree" is used.</remarks>
        public Window Find(string name)
        {
            /*
            //               "anonymous method"
            //               |-Expression tree-|
            return this.Find(w => w.Name == name);
            //                    |------------|
            //                      the body of the method
            //                 ^-> the "Lambda operator" "goes to"
            //               ^-> the interface of the method
            //                   called "Lambda"
            */

            //Case insensitiv version...
            return this.Find(w => string.Compare(w.Name, name, ignoreCase: true) == 0);
        }
    }

    /// <summary>
    /// Contains information about an applications window.
    /// </summary>
    /// <remarks>Such a class is called "Data Transfer Object (DTO)"</remarks>
    public class Window
    {
        /// <summary>
        /// Internal field for the property
        /// </summary>
        private string _Name = null;

        /// <summary>
        /// Gets or set the internal name of the window
        /// </summary>
        /// <remarks>This information is used as a key information to find the window</remarks>
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                //Todo: raise OnPropertyChanged("Name") event for Windows Presentation Foundation (WPF)
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int _State = 0;

        /// <summary>
        /// Gets or set the window state.
        /// </summary>
        /// <remarks>Either System.Windows.Forms.WindowState 
        /// or System.Windows.WindowState (WPF) enumeration values.</remarks>
        public int State
        {
            get
            {
                return this._State;
            }
            set
            {
                this._State = value;
                //TODO: OnPropertyChanged("State")
            }
        }

        //Problem:
        //private int _Left;
        //          ^-> value type which can't be "null"
        //              We don't know if 0 (the number)
        //              is valid or not
        //Solution:
        //=> Nullable value types

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        //private System.Nullable<int> _Left = null;
        //        |-> there's a suffix for System.Nullable<T>
        //            The question mark

        private int? _Left = null;

        /// <summary>
        /// Gets or set the left postion of the window
        /// </summary>
        public int? Left
        {
            get
            {
                return this._Left;
            }
            set
            {
                this._Left = value;
                //OnPropertyChanged("Left");
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int? _Top = null;

        /// <summary>
        /// Gets or set the upper position of the window
        /// </summary>
        public int? Top
        {
            get
            {
                return this._Top;
            }
            set
            {
                this._Top = value;
                //OnPropertyChanged("Top");
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private int? _Width = null;

        /// <summary>
        /// Gets or set the width of the window.
        /// </summary>
        public int? Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this._Width = value;
                //OnPropertyChanged("Width");
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private int? _Heigth = null;

        /// <summary>
        /// Gets or set the height of the window.
        /// </summary>
        public int? Heigth
        {
            get
            {
                return this._Heigth;
            }
            set
            {
                this._Heigth = value;
                //OnPropertyChanged("Heigth");
            }
        }
    }
}

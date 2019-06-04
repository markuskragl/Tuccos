using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Model
{
    /// <summary>
    /// Proivides a list containing task objects.
    /// </summary>
    public class TaskList : System.Collections.ObjectModel.ObservableCollection<Task>
    {

    }

    /// <summary>
    /// Describes an application feature.
    /// </summary>
    public class Task
    {

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private string _Title = string.Empty;

        /// <summary>
        /// Gets the text shown the user.
        /// </summary>
        public string Title
        {
            get
            {
                return this._Title;
            }
        }

        /// <summary>
        /// Initializes a new task.
        /// </summary>
        /// <param name="titel">The text shown to the user</param>
        /// <param name="viewerType">The type of the viewer for this task</param>
        /// <remarks>You should use an System.Windows.UserControl as a type.</remarks>
        public Task(string titel, System.Type viewerType)
        {
            this._Title = titel;
            this._ViewerType = viewerType;
        }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <remarks>This has to be Wingdings char.</remarks>
        public string WingdingsIcon { get; set; }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Type _ViewerType = null;

        /// <summary>
        /// Gets the type of the viewer used for this task.
        /// </summary>
        public System.Type ViewerType
        {
            get
            {
                return this._ViewerType;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Windows.Controls.UserControl _Viewer = null;

        /// <summary>
        /// Gets or set the UI control used by this task.
        /// </summary>
        public System.Windows.Controls.UserControl Viewer
        {
            get
            {
                return this._Viewer;
            }
            set
            {
                this._Viewer = value;
            }
        }
    }
}

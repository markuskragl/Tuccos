using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data
{
    /// <summary>
    /// Provides a list of projects.
    /// </summary>
    public class Projects : System.Collections.Generic.List<Project>
    {

    }

    /// <summary>
    /// Provides the project infomation
    /// </summary>
    //[System.Runtime.Serialization.DataContract]
    public class Project : INotifyPropertyChanged
    {
        void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Internal field for the property
        /// </summary>
        private string _ProjectId;
        /// <summary>
        /// Gets or sets the readable name of the ProjectId.
        /// </summary>
        public string ProjectId
        {
            get
            {
                return _ProjectId;
            }
            set
            {
                if (_ProjectId != value)
                {
                    _ProjectId = value;
                    OnPropertyChanged("ProjectId");
                }
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private string _ProjectName;
        /// <summary>
        /// Gets or sets the readable name of the project.
        /// </summary>
        public string ProjectName
        {
            get
            {
                return _ProjectName;
            }
            set
            {
                if (_ProjectName != value)
                {
                    _ProjectName = value;
                    OnPropertyChanged("ProjectName");
                }
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int _ProjectYear;
        /// <summary>
        /// Gets or sets the project year.
        /// </summary>
        public int ProjectYear
        {
            get
            {
                return _ProjectYear;
            }
            set
            {
                if (_ProjectYear != value)
                {
                    _ProjectYear = value;
                    OnPropertyChanged("ProjectYear");
                }
            }
        }
    }
}

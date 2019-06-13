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
        /// Gets or set the Id code of the project.
        /// </summary>
        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }



        /// <summary>
        /// Gets or sets the readable name of the project.
        /// </summary>
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Gets or sets the highest project number in this Year.
        /// </summary>
        private int _Year;
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                if (_Year != value)
                {
                    _Year = value;
                    OnPropertyChanged("Year");
                }
            }
        }


        //private System.Collections.Generic.List<object> _Subassembly = new List<object>();

        //public List<object> Subassembly
        //{
        //    get
        //    {
        //        _Subassembly.Add("Valve 1");
        //        _Subassembly.Add("GVM 2");
        //        return this._Subassembly;
        //    }

        //    set
        //    {
        //        this._Subassembly = value;
        //    }
        //}
    }
}

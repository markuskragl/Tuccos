using System;
using System.Collections.Generic;
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
    public class Project
    {
        /// <summary>
        /// Gets or set the Id code of the project.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the readable name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the highest lottery number in this Year.
        /// </summary>
        public int Year { get; set; }


        private System.Collections.Generic.List<object> _Subassembly = new List<object>();

        public List<object> Subassembly
        {
            get
            {
                _Subassembly.Add("Valve 1");
                _Subassembly.Add("GVM 2");
                return this._Subassembly;
            }

            set
            {
                this._Subassembly = value;
            }
        }
    }
}

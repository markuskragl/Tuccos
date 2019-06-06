using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data

{
    /// <summary>
    /// Provides the data for the subassembly
    /// </summary>
    public class Subassembly : Project
    {
        private string _Type = null;

        /// <summary>
        /// Gets or sets the type of the subassembly
        /// </summary>
        public string Type
        {
            get
            {
                return this._Type;
            }

            set
            {
                this._Type = value;
            }
        }
        private int? _RngNr = null;

        /// <summary>
        /// Gets or sets the running number of the subassembly
        /// </summary>
        public int? RngNr
        {
            get
            {
                return this._RngNr;
            }

            set
            {
                this._RngNr = value;
            }
        }

        private string _Project = null;
        /// <summary>
        /// Gets or sets the project which the subassembly belongs to
        /// </summary>
        public string Project
        {
            get
            {
                return this._Project;
            }

            set
            {
                this._Project = value;
            }
        }

        private System.Collections.Generic.List<object> _Calculations = new List<object>();

        /// <summary>
        /// Gets or sets a list of calculations belonging to the subassembly
        /// </summary>
        public List<object> Calculations
        {
            get
            {
            
                return this._Calculations;
            }

            set
            {
                this._Calculations = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data

{

    /// <summary>
    /// Provides a list of SubAssemblies.
    /// </summary>
    public class SubAssemblies : System.Collections.Generic.List<SubAssembly>
    {

    }
    /// <summary>
    /// Provides the number of the subassembly
    /// </summary>
    public class SubAssembly : Project
    {


        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int? _SubAssemblyId= null;

        /// <summary>
        /// Gets or sets the type of the subassembly
        /// </summary>
        public int? SubAssemblyId
        {
            get
            {
                return this._SubAssemblyId;
            }

            set
            {
                this._SubAssemblyId = value;
            }
        }



        /// <summary>
        /// Internal field for the property
        /// </summary>
        private string _SubAssemblyName = null;
        /// <summary>
        /// Gets or sets the name of a subassembly
        /// </summary>
        public string SubAssemblyName
        {
            get
            {
                return this._SubAssemblyName;
            }

            set
            {
                this._SubAssemblyName = value;
            }
        }


        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int? _SubAssemblyRngNr = null;

        /// <summary>
        /// Gets or sets the running number of the subassembly
        /// </summary>
        public int? SubAssemblyRngNr
        {
            get
            {
                return this._SubAssemblyRngNr;
            }

            set
            {
                this._SubAssemblyRngNr = value;
            }
        }
    }
}

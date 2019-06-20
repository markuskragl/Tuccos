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
    public class CalculationTemplates : System.Collections.Generic.List<CalculationTemplate>
    {

    }
    /// <summary>
    /// Provides the number of the subassembly
    /// </summary>
    public class CalculationTemplate : Calculation
    {


        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int? _CalculationTemplateId= null;

        /// <summary>
        /// Gets or sets the type of the CalculationTemplateId
        /// </summary>
        public int? CalculationTemplateId
        {
            get
            {
                return this._CalculationTemplateId;
            }

            set
            {
                this._CalculationTemplateId = value;
            }
        }
    }
}

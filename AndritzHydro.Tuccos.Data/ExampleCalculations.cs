using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data
{
    /// <summary>
    /// Provides a list of ExampleCalculation.
    /// </summary>
    public class ExampleCalculations : System.Collections.Generic.List<ExampleCalculation>
    {

    }

    /// <summary>
    /// Provides the number of the ExampleCalculation
    /// </summary>
    public class ExampleCalculation : Calculation
    {
        /// <summary>
        /// Internal field for the property
        /// </summary>
        private string _CalculationDescription= null;
        /// <summary>
        /// Gets or sets the type of the CalculationDescriptions
        /// </summary>
        public string CalculationDescription
        {
            get
            {
                return this._CalculationDescription;
            }
            set
            {
                this._CalculationDescription = value;
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int _Parametera = 0;
        /// <summary>
        /// Gets or sets the type of the Parametera
        /// </summary>
        public int Parametera
        {
            get
            {
                return this._Parametera;
            }
            set
            {
                this._Parametera = value;
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int _Parameterb = 0;
        /// <summary>
        /// Gets or sets the type of the Parameterb
        /// </summary>
        public int Parameterb
        {
            get
            {
                return this._Parameterb;
            }
            set
            {
                this._Parameterb = value;
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private int _Resultc = 0;
        /// <summary>
        /// Gets or sets the type of the Resultc
        /// </summary>
        public int Resultc
        {
            get
            {
                return this._Resultc;
            }
            set
            {
                this._Resultc = value;
            }
        }

    }
}
